using SecuritySystemDataBaseImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySystemDataBaseImplement.Implements
{
    public class DeviceLogic : IDeviceLogic
    {
        public void CreateOrUpdate(DeviceBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                Device element = context.Devices.FirstOrDefault(rec =>
               rec.DeviceName == model.DeviceName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Devices.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Device();
                    context.Devices.Add(element);
                }
                element.DeviceName = model.DeviceName;
                context.SaveChanges();
            }
        }
        public void Delete(DeviceBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                Device element = context.Devices.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Devices.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<DeviceViewModel> Read(DeviceBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                return context.Devices
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
}
