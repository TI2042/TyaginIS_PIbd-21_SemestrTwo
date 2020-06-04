using SecuritySystemListImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecuritySystemFileImplement.Implements
{
    public class EquipmentLogic : IEquipmentLogic
    {
        private readonly FileDataListSingleton source;
        public EquipmentLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(EquipmentBindingModel model)
        {
            Equipment element = source.Equipments.FirstOrDefault(rec => rec.EquipmentName == model.EquipmentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Equipments.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Equipments.Count > 0 ? source.Devices.Max(rec => rec.Id) : 0;
                element = new Equipment { Id = maxId + 1 };
                source.Equipments.Add(element);
            }
            element.EquipmentName = model.EquipmentName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.EquipmentDevices.RemoveAll(rec => rec.EquipmentId == model.Id && !model.EquipmentDevices.ContainsKey(rec.DeviceId));
            // обновили количество у существующих записей
            var updateComponents = source.EquipmentDevices.Where(rec => rec.EquipmentId == model.Id && model.EquipmentDevices.ContainsKey(rec.DeviceId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.EquipmentDevices[updateComponent.DeviceId].Item2;
                model.EquipmentDevices.Remove(updateComponent.DeviceId);
            }
            // добавили новые
            int maxPCId = source.EquipmentDevices.Count > 0 ? source.EquipmentDevices.Max(rec => rec.Id) : 0;
            foreach (var pc in model.EquipmentDevices)
            {
                source.EquipmentDevices.Add(new EquipmentDevice
                {
                    Id = ++maxPCId,
                    EquipmentId = element.Id,
                    DeviceId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(EquipmentBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.EquipmentDevices.RemoveAll(rec => rec.EquipmentId == model.Id);
            Equipment element = source.Equipments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Equipments.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<EquipmentViewModel> Read(EquipmentBindingModel model)
        {
            return source.Equipments
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new EquipmentViewModel
            {
                Id = rec.Id,
                EquipmentName = rec.EquipmentName,
                Price = rec.Price,
                EquipmentDevices = source.EquipmentDevices
                .Where(recPC => recPC.EquipmentId == rec.Id)
                .ToDictionary(recPC => recPC.DeviceId,
                              recPC => (source.Devices.FirstOrDefault(recC => recC.Id == recPC.DeviceId)?.DeviceName, recPC.Count))
            })
            .ToList();
        }
    }
}
