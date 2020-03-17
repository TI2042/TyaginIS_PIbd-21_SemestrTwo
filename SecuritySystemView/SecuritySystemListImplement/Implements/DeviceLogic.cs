using SecuritySystemListImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemListImplement.Implements
{
    public class DeviceLogic : IDeviceLogic
    {
        private readonly DataListSingleton source;

        public DeviceLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<DeviceViewModel> GetList()
        {
            List<DeviceViewModel> result = new List<DeviceViewModel>();
            for (int i = 0; i < source.Devices.Count; ++i)
            {
                result.Add(new DeviceViewModel
                {
                    Id = source.Devices[i].Id,
                    DeviceName = source.Devices[i].DeviceName
                });
            }
            return result;
        }

        public DeviceViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Devices.Count; ++i)
            {
                if (source.Devices[i].Id == id)
                {
                    return new DeviceViewModel
                    {
                        Id = source.Devices[i].Id,
                        DeviceName = source.Devices[i].DeviceName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DeviceBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Devices.Count; ++i)
            {
                if (source.Devices[i].Id > maxId)
                {
                    maxId = source.Devices[i].Id;
                }
                if (source.Devices[i].DeviceName == model.DeviceName)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            source.Devices.Add(new Device
            {
                Id = maxId + 1,
                DeviceName = model.DeviceName
            });
        }

        public void UpdElement(DeviceBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Devices.Count; ++i)
            {
                if (source.Devices[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Devices[i].DeviceName == model.DeviceName && source.Devices[i].Id != model.Id)
                {
                    throw new Exception("Уже есть устройство с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Devices[index].DeviceName = model.DeviceName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Devices.Count; ++i)
            {
                if (source.Devices[i].Id == id)
                {
                    source.Devices.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
