using SecuritySystemListImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace SecuritySystemListImplement.Implements
{
    public class EquipmentLogic : IEquipmentLogic
    {
        private readonly DataListSingleton source;

        public EquipmentLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(EquipmentBindingModel model)
        {
            Equipment tempProduct = model.Id.HasValue ? null : new Equipment { Id = 1 };
            foreach (var product in source.Equipments)
            {
                if (product.EquipmentName == model.EquipmentName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть комплектация с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                {
                    throw new Exception("комплектация не найдена");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Equipments.Add(CreateModel(model, tempProduct));
            }
        }

        public void Delete(EquipmentBindingModel model)
        {
            for (int i = 0; i < source.EquipmentDevices.Count; ++i)
            {
                if (source.EquipmentDevices[i].EquipmentId == model.Id)
                {
                    source.EquipmentDevices.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Equipments.Count; ++i)
            {
                if (source.Equipments[i].Id == model.Id)
                {
                    source.Equipments.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("комплектация не найдена");
        }

        private Equipment CreateModel(EquipmentBindingModel model, Equipment product)
        {
            product.EquipmentName = model.EquipmentName;
            product.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.EquipmentDevices.Count; ++i)
            {
                if (source.EquipmentDevices[i].Id > maxPCId)
                {
                    maxPCId = source.EquipmentDevices[i].Id;
                }
                if (source.EquipmentDevices[i].EquipmentId == product.Id)
                {
                    if
                    (model.EquipmentDevices.ContainsKey(source.EquipmentDevices[i].DeviceId))
                    {
                        source.EquipmentDevices[i].Count =
                        model.EquipmentDevices[source.EquipmentDevices[i].DeviceId].Item2;
                        model.EquipmentDevices.Remove(source.EquipmentDevices[i].DeviceId);
                    }
                    else
                    {
                        source.EquipmentDevices.RemoveAt(i--);
                    }
                }
            }
            foreach (var pc in model.EquipmentDevices)
            {
                source.EquipmentDevices.Add(new EquipmentDevice
                {
                    Id = ++maxPCId,
                    DeviceId = product.Id,
                    EquipmentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }

        public List<EquipmentViewModel> Read(EquipmentBindingModel model)
        {
            List<EquipmentViewModel> result = new List<EquipmentViewModel>();
            foreach (var component in source.Equipments)
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

        private EquipmentViewModel CreateViewModel(Equipment product)
        {
            Dictionary<int, (string, int)> equipmentDevices = new Dictionary<int, (string, int)>();
            foreach (var dm in source.EquipmentDevices)
            {
                if (dm.EquipmentId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Devices)
                    {
                        if (dm.DeviceId == component.Id)
                        {
                            componentName = component.DeviceName;
                            break;
                        }
                    }
                    equipmentDevices.Add(dm.DeviceId, (componentName, dm.Count));
                }
            }
            return new EquipmentViewModel
            {
                Id = product.Id,
                EquipmentName = product.EquipmentName,
                Price = product.Price,
                EquipmentDevices = equipmentDevices
            };
        }
    }
}

