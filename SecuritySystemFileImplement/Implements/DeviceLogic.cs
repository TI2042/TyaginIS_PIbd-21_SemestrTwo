using SecuritySystemFileImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecuritySystemFileImplement.Implements
{
    public class DeviceLogic : IDeviceLogic
    {
        private readonly FileDataListSingleton source;

        public DeviceLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(DeviceBindingModel model)
        {
            Device element = source.Devices.FirstOrDefault(rec => rec.DeviceName == model.DeviceName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Devices.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Devices.Count > 0 ? source.Devices.Max(rec => rec.Id) : 0;
                element = new Device { Id = maxId + 1 };
                source.Devices.Add(element);
            }
            element.DeviceName = model.DeviceName;
        }
        public void Delete(DeviceBindingModel model)
        {
            Device element = source.Devices.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Devices.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<DeviceViewModel> Read(DeviceBindingModel model)
        {
            return source.Devices
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new DeviceViewModel
            {
                Id = rec.Id,
                DeviceName = rec.DeviceName
            })
            .ToList();
        }
    }
}
