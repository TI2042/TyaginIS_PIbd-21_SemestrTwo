using SecuritySystemListImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (var product in source.Products)
            {
                if (product.EquipmentName == model.EquipmentName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
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
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Products.Add(CreateModel(model, tempProduct));
            }
        }

        public void Delete(EquipmentBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].EquipmentId == model.Id)
                {
                    source.ProductComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Equipment CreateModel(EquipmentBindingModel model, Equipment product)
        {
            product.EquipmentName = model.EquipmentName;
            product.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].Id;
                }
                if (source.ProductComponents[i].EquipmentId == product.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.EquipmentDevices.ContainsKey(source.ProductComponents[i].DeviceId))
                    {
                        // обновляем количество
                        source.ProductComponents[i].Count =
                        model.EquipmentDevices[source.ProductComponents[i].DeviceId].Item2;
                        // из модели убираем эту запись, чтобы остались только не
                        //просмотренные
                        model.EquipmentDevices.Remove(source.ProductComponents[i].DeviceId);
                    }
                    else
                    {
                        source.ProductComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.EquipmentDevices)
            {
                source.ProductComponents.Add(new EquipmentDevice
                {
                    Id = ++maxPCId,
                    EquipmentId = product.Id,
                    DeviceId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }

        public List<EquipmentViewModel> Read(EquipmentBindingModel model)
        {
            List<EquipmentViewModel> result = new List<EquipmentViewModel>();
            foreach (var component in source.Products)
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
            // требуется дополнительно получить список компонентов для изделия с
            // названиями и их количество
            Dictionary<int, (string, int)> equipmentDevices = new Dictionary<int, (string, int)>();
            foreach (var dm in source.ProductComponents)
            {
                if (dm.EquipmentId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
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

