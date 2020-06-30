using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemFileImplement.Models;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySystemFileImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataFileSingleton source;
        public StorageLogic()
        {
            source = DataFileSingleton.GetInstance();
        }
        public void CreateOrUpdate(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(s => s.StorageName == model.StorageName && s.Id != model.Id);
            if (element != null)
                throw new Exception("Уже есть компонент с таким названием");
            if (model.Id.HasValue)
            {
                element = source.Storages.FirstOrDefault(s => s.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Storages.Count > 0 ? source.Storages.Max(s => s.Id) : 0;
                element = new Storage { Id = maxId + 1 };
                source.Storages.Add(element);
            }
            element.StorageName = model.StorageName;
        }
        public void Delete(StorageBindingModel model)
        {
            Storage storage = source.Storages.FirstOrDefault(s => s.Id == model.Id);
            if (storage != null)
            {
                source.Storages.Remove(storage);
            }
            else
            {
                throw new Exception("Склад не найден");
            }
        }
        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            return source.Storages
            .Where(s => model == null || s.Id == model.Id)
            .Select(s => new StorageViewModel
            {
                Id = s.Id,
                StorageName = s.StorageName,
                StorageDevices = source.StorageDevices
                    .Where(sm => sm.StorageId == s.Id)
                    .ToDictionary(k => source.Devices.FirstOrDefault(m => m.Id == k.DeviceId).DeviceName, k => k.Count)
            })
            .ToList();
        }

        public void AddDeviceToStorage(AddDeviceInStorageBindingModel model)
        {
            if (source.StorageDevices.Count == 0)
            {
                source.StorageDevices.Add(new StorageDevice()
                {
                    Id = 1,
                    DeviceId = model.DeviceId,
                    StorageId = model.StorageId,
                    Count = model.Count
                });
            }
            else
            {
                var ingredient = source.StorageDevices.FirstOrDefault(sm => sm.StorageId == model.StorageId && sm.DeviceId == model.DeviceId);
                if (ingredient == null)
                {
                    source.StorageDevices.Add(new StorageDevice()
                    {
                        Id = source.StorageDevices.Max(sm => sm.Id) + 1,
                        DeviceId = model.DeviceId,
                        StorageId = model.StorageId,
                        Count = model.Count
                    });
                }
                else
                    ingredient.Count += model.Count;
            }
        }

        private bool CheckingStoragedDevices(OrderViewModel order)
        {
            var equipmentDevice = source.EquipmentDevices.Where(dm => dm.EquipmentId == order.EquipmentId);
            var ingredientStorage = new Dictionary<int, int>();
            foreach (var sm in source.StorageDevices)
            {
                if (ingredientStorage.ContainsKey(sm.DeviceId))
                    ingredientStorage[sm.DeviceId] += sm.Count;
                else
                    ingredientStorage.Add(sm.DeviceId, sm.Count);
            }

            foreach (var dm in equipmentDevice)
            {
                if (!ingredientStorage.ContainsKey(dm.DeviceId) || ingredientStorage[dm.DeviceId] < dm.Count * order.Count)
                    return false;
            }

            return true;
        }

        public bool RemoveDevices(OrderViewModel order)
        {
            if (CheckingStoragedDevices(order))
            {
                var equipmentDevice = source.EquipmentDevices.Where(dm => dm.EquipmentId == order.EquipmentId);
                foreach (var dm in equipmentDevice)
                {
                    int IngrCount = dm.Count * order.Count;
                    foreach (var sm in source.StorageDevices)
                    {
                        if (sm.DeviceId == dm.DeviceId && sm.Count >= IngrCount)
                        {
                            sm.Count -= IngrCount;
                            break;
                        }
                        else if (sm.DeviceId == dm.DeviceId && sm.Count < IngrCount)
                        {
                            IngrCount -= sm.Count;
                            sm.Count = 0;
                        }
                    }
                }
                return true;
            }
            else
                return false;
        }
    }
}
