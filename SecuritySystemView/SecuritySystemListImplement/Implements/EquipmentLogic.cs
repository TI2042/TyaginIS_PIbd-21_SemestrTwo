using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using SecuritySystemListImplement.Models;
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

        public List<EquipmentViewModel> GetList()
        {
            List<EquipmentViewModel> result = new List<EquipmentViewModel>();
            for (int i = 0; i < source.Equipments.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество                
                List<EquipmentDeviceViewModel> productComponents = new List<EquipmentDeviceViewModel>();
                for (int j = 0; j < source.EquipmentDevices.Count; ++j)
                {
                    if (source.EquipmentDevices[j].EquipmentId == source.Equipments[i].Id)
                    {
                        string deviceName = string.Empty;
                        for (int k = 0; k < source.Devices.Count; ++k)
                        {
                            if (source.EquipmentDevices[j].DeviceId == source.Devices[k].Id)
                            {
                                deviceName = source.Devices[k].DeviceName;
                                break;
                            }
                        }
                        productComponents.Add(new EquipmentDeviceViewModel
                        {
                            Id = source.EquipmentDevices[j].Id,
                            EquipmentId = source.EquipmentDevices[j].EquipmentId,
                            DeviceId = source.EquipmentDevices[j].DeviceId,
                            DeviceName = deviceName,
                            Count = source.EquipmentDevices[j].Count
                        });
                    }
                }
                result.Add(new EquipmentViewModel
                {
                    Id = source.Equipments[i].Id,
                    EquipmentName = source.Equipments[i].EquipmentName,
                    Price = source.Equipments[i].Price,
                    ProductComponents = productComponents
                });
            }
            return result;
        }

        public EquipmentViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Equipments.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество            
                List<EquipmentDeviceViewModel> productComponents = new List<EquipmentDeviceViewModel>();
                for (int j = 0; j < source.EquipmentDevices.Count; ++j)
                {
                    if (source.EquipmentDevices[j].EquipmentId == source.Equipments[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Devices.Count; ++k)
                        {
                            if (source.EquipmentDevices[j].DeviceId == source.Devices[k].Id)
                            {
                                componentName = source.Devices[k].DeviceName;
                                break;
                            }
                        }
                        productComponents.Add(new EquipmentDeviceViewModel
                        {
                            Id = source.EquipmentDevices[j].Id,
                            EquipmentId = source.EquipmentDevices[j].EquipmentId,
                            DeviceId = source.EquipmentDevices[j].DeviceId,
                            DeviceName = componentName,
                            Count = source.EquipmentDevices[j].Count
                        });
                    }
                }
                if (source.Equipments[i].Id == id)
                {
                    return new EquipmentViewModel
                    {
                        Id = source.Equipments[i].Id,
                        EquipmentName = source.Equipments[i].EquipmentName,
                        Price = source.Equipments[i].Price,
                        ProductComponents = productComponents
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(EquipmentBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Equipments.Count; ++i)
            {
                if (source.Equipments[i].Id > maxId)
                {
                    maxId = source.Equipments[i].Id;
                }
                if (source.Equipments[i].EquipmentName == model.EquipmentName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Equipments.Add(new Equipment { Id = maxId + 1, EquipmentName = model.EquipmentName, Price = model.Price });
            // компоненты для изделия           
            int maxPCId = 0;
            for (int i = 0; i < source.EquipmentDevices.Count; ++i)
            {
                if (source.EquipmentDevices[i].Id > maxPCId)
                {
                    maxPCId = source.EquipmentDevices[i].Id;
                }
            }
            // убираем дубли по компонентам       
            for (int i = 0; i < model.EquipmentDevices.Count; ++i)
            {
                for (int j = 1; j < model.EquipmentDevices.Count; ++j)
                {
                    if (model.EquipmentDevices[i].DeviceId == model.EquipmentDevices[j].DeviceId)
                    {
                        model.EquipmentDevices[i].Count += model.EquipmentDevices[j].Count;
                        model.EquipmentDevices.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты         
            for (int i = 0; i < model.EquipmentDevices.Count; ++i)
            {
                source.EquipmentDevices.Add(new EquipmentDevice
                {
                    Id = ++maxPCId,
                    EquipmentId = maxId + 1,
                    DeviceId = model.EquipmentDevices[i].DeviceId,
                    Count = model.EquipmentDevices[i].Count
                });
            }
        }

        public void UpdElement(EquipmentBindingModel model)
        {
            int index = -1; for (int i = 0; i < source.Equipments.Count; ++i)
            {
                if (source.Equipments[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Equipments[i].EquipmentName == model.EquipmentName && source.Equipments[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Equipments[index].EquipmentName = model.EquipmentName;
            source.Equipments[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.EquipmentDevices.Count; ++i)
            {
                if (source.EquipmentDevices[i].Id > maxPCId)
                {
                    maxPCId = source.EquipmentDevices[i].Id;
                }
            }
            // обновляем существуюущие компоненты     
            for (int i = 0; i < source.EquipmentDevices.Count; ++i)
            {
                if (source.EquipmentDevices[i].EquipmentId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.EquipmentDevices.Count; ++j)
                    {
                        // если встретили, то изменяем количество   
                        if (source.EquipmentDevices[i].Id == model.EquipmentDevices[j].Id)
                        {
                            source.EquipmentDevices[i].Count = model.EquipmentDevices[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем             
                    if (flag)
                    {
                        source.EquipmentDevices.RemoveAt(i--);
                    }
                }
            }
            // новые записи     
            for (int i = 0; i < model.EquipmentDevices.Count; ++i)
            {
                if (model.EquipmentDevices[i].Id == 0)
                {
                    // ищем дубли  
                    for (int j = 0; j < source.EquipmentDevices.Count; ++j)
                    {
                        if (source.EquipmentDevices[j].EquipmentId == model.Id && source.EquipmentDevices[j].DeviceId == model.EquipmentDevices[i].DeviceId)
                        {
                            source.EquipmentDevices[j].Count += model.EquipmentDevices[i].Count;
                            model.EquipmentDevices[i].Id = source.EquipmentDevices[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись             
                    if (model.EquipmentDevices[i].Id == 0)
                    {
                        source.EquipmentDevices.Add(new EquipmentDevice
                        {
                            Id = ++maxPCId,
                            EquipmentId = model.Id,
                            DeviceId = model.EquipmentDevices[i].DeviceId,
                            Count = model.EquipmentDevices[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            // удаляем записи по компонентам при удалении изделия    
            for (int i = 0; i < source.EquipmentDevices.Count; ++i)
            {
                if (source.EquipmentDevices[i].EquipmentId == id)
                {
                    source.EquipmentDevices.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Equipments.Count; ++i)
            {
                if (source.Equipments[i].Id == id)
                {
                    source.Equipments.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
