using Microsoft.EntityFrameworkCore;
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
    public class EquipmentLogic : IEquipmentLogic
    {
        public void CreateOrUpdate(EquipmentBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Equipment element = context.Equipments.FirstOrDefault(rec => rec.EquipmentName == model.EquipmentName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть комплектация с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Equipments.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Equipment();
                            context.Equipments.Add(element);
                        }
                        element.EquipmentName = model.EquipmentName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.EquipmentDevices.Where(rec => rec.EquipmentId == model.Id.Value).ToList();
                            context.EquipmentDevices.RemoveRange(productComponents.Where(rec => !model.EquipmentDevices.ContainsKey(rec.DeviceId)).ToList());
                            context.SaveChanges();
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count = model.EquipmentDevices[updateComponent.DeviceId].Item2;
                                model.EquipmentDevices.Remove(updateComponent.DeviceId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.EquipmentDevices)
                        {
                            context.EquipmentDevices.Add(new EquipmentDevice
                            {
                                EquipmentId = element.Id,
                                DeviceId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(EquipmentBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.EquipmentDevices.RemoveRange(context.EquipmentDevices.Where(rec => rec.EquipmentId == model.Id));
                        Equipment element = context.Equipments.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Equipments.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Комплектация не найдена");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<EquipmentViewModel> Read(EquipmentBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                return context.Equipments.Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new EquipmentViewModel
                {
                    Id = rec.Id,
                    EquipmentName = rec.EquipmentName,
                    Price = rec.Price,
                    EquipmentDevices = context.EquipmentDevices.Include(recPC => recPC.Device)
                                                           .Where(recPC => recPC.EquipmentId == rec.Id)
                                                           .ToDictionary(recPC => recPC.DeviceId, recPC => (recPC.Device?.DeviceName, recPC.Count))
                }).ToList();
            }
        }
    }
}
