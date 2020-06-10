﻿using SecuritySystemListImplement.Models;
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
        public void CreateOrUpdate(DeviceBindingModel model)
        {
            Device tempComponent = model.Id.HasValue ? null : new Device
            {
                Id = 1
            };
            foreach (var component in source.Components)
            {
                if (component.DeviceName == model.DeviceName && component.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть ингредиент с таким названием");
                }
                if (!model.Id.HasValue && component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
                else if (model.Id.HasValue && component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempComponent == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempComponent);
            }
            else
            {
                source.Components.Add(CreateModel(model, tempComponent));
            }
        }
        public void Delete(DeviceBindingModel model)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == model.Id.Value)
                {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<DeviceViewModel> Read(DeviceBindingModel model)
        {
            List<DeviceViewModel> result = new List<DeviceViewModel>();
            foreach (var component in source.Components)
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

