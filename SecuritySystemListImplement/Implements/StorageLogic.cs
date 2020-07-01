using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemListImplement.Models;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySystemListImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataListSingleton source;
        public StorageLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(StorageBindingModel storage)
        {
            Storage tempStorage = storage.Id.HasValue ? null : new Storage
            {
                Id = 1
            };
            foreach (var s in source.Storages)
            {
                if (s.StorageName == storage.StorageName && s.Id != storage.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                if (!storage.Id.HasValue && s.Id >= tempStorage.Id)
                {
                    tempStorage.Id = s.Id + 1;
                }
                else if (storage.Id.HasValue && s.Id == storage.Id)
                {
                    tempStorage = s;
                }
            }
            if (storage.Id.HasValue)
            {
                if (tempStorage == null)
                {
                    throw new Exception("Элемент не найден");
                }
                tempStorage.StorageName = storage.StorageName;
            }
            else
            {
                source.Storages.Add(new Storage()
                {
                    Id = tempStorage.Id,
                    StorageName = storage.StorageName
                });
            }
        }
        public void Delete(StorageBindingModel model)
        {
            for (int i = 0; i < source.StorageDevices.Count; ++i)
            {
                if (source.StorageDevices[i].StorageId == model.Id)
                {
                    source.StorageDevices.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            foreach (var storage in source.Storages)
            {
                if (model != null)
                {
                    if (storage.Id == model.Id)
                    {
                        result.Add(new StorageViewModel()
                        {
                            Id = storage.Id,
                            StorageName = storage.StorageName,
                            StorageDevices = source.StorageDevices.Where(sm => sm.StorageId == storage.Id)
                            .ToDictionary(sm => source.Devices.FirstOrDefault(c => c.Id == sm.DeviceId).DeviceName, sm => sm.Count)
                        });
                        break;
                    }
                    continue;
                }
                result.Add(new StorageViewModel()
                {
                    Id = storage.Id,
                    StorageName = storage.StorageName,
                    StorageDevices = source.StorageDevices.Where(sm => sm.StorageId == storage.Id)
                           .ToDictionary(sm => source.Devices.FirstOrDefault(c => c.Id == sm.StorageId).DeviceName, sm => sm.Count)
                });
            }
            return result;
        }
        public void AddDeviceToStorage(AddDeviceInStorageBindingModel model)
        {
            if (source.StorageDevices.Count == 0)
            {
                source.StorageDevices.Add(new StorageDevices()
                {
                    Id = 1,
                    DeviceId = model.DeviceId,
                    StorageId = model.StorageId,
                    Count = model.Count
                });
            }
            else
            {
                var device = source.StorageDevices.FirstOrDefault(sm => sm.StorageId == model.StorageId && sm.DeviceId == model.DeviceId);
                if (device == null)
                {
                    source.StorageDevices.Add(new StorageDevices()
                    {
                        Id = source.StorageDevices.Max(sm => sm.Id) + 1,
                        DeviceId = model.DeviceId,
                        StorageId = model.StorageId,
                        Count = model.Count
                    });
                }
                else
                    device.Count += model.Count;
            }
        }

        bool IStorageLogic.RemoveDevices(OrderViewModel order)
        {
            throw new NotImplementedException();
        }
    }
}
