
﻿using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using SecuritySystemListImplement.Models;
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

        public void CreateOrUpdate(DeviceBindingModel model)
        {
            Device tempComponent = model.Id.HasValue ? null : new Device
            {
                Id = 1
            };
            foreach (var device in source.Devices)
            {
                if (device.DeviceName == model.DeviceName && device.Id != model.Id)
                {
                    throw new Exception("Уже есть устройство с таким названием");
                }
                if (!model.Id.HasValue && device.Id >= tempComponent.Id)
                {
                    tempComponent.Id = device.Id + 1;
                }
                else if (model.Id.HasValue && device.Id == model.Id)
                {
                    tempComponent = device;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempComponent == null)
                {
                    throw new Exception("устройство не найдено");
                }
                CreateModel(model, tempComponent);
            }
            else
            {
                source.Devices.Add(CreateModel(model, tempComponent));
            }
        }

        public void Delete(DeviceBindingModel model)
        {
            for (int i = 0; i < source.Devices.Count; ++i)
            {
                if (source.Devices[i].Id == model.Id.Value)
                {
                    source.Devices.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("устройство не найдено");
        }

        public List<DeviceViewModel> Read(DeviceBindingModel model)
        {
            List<DeviceViewModel> result = new List<DeviceViewModel>();
            foreach (var component in source.Devices)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }

        private Device CreateModel(DeviceBindingModel model, Device component)
        {
            component.DeviceName = model.DeviceName;
            return component;
        }

        private DeviceViewModel CreateViewModel(Device component)
        {
            return new DeviceViewModel
            {
                Id = component.Id,
                DeviceName = component.DeviceName
            };
        }
    }
}

