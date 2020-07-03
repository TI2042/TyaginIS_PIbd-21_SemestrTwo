using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemDataBaseImplement.Models;
using SecuritySystemsBusinessLogic.ViewModels;
using SecuritySystemsBusinessLogic.Enums;

namespace SecuritySystemDataBaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = context.Orders.ToList().FirstOrDefault(rec => rec.Id == model.Id);
                        if (model.Id.HasValue)
                        {
                            if (order == null)
                                throw new Exception("Элемент не найден");
                        }
                        else
                        {
                            order = new Order();
                            context.Orders.Add(order);
                        }
                        order.EquipmentId = model.EquipmentId;
                        order.ClientFIO = model.ClientFIO;
                        order.ClientId = model.ClientId;
                        order.ImplementerFIO = model.ImplementerFIO;
                        order.ImplementerId = model.ImplementerId;
                        order.Count = model.Count;
                        order.DateCreate = model.DateCreate;
                        order.DateImplement = model.DateImplement;
                        order.Status = model.Status;
                        order.Sum = model.Sum;
                        context.SaveChanges();
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

        public void Delete(OrderBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                        if (order != null)
                        {
                            context.Orders.Remove(order);
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        context.SaveChanges();
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

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new SecuritySystemDataBase())
            {
                return context.Orders.Where(rec => model == null 
                || rec.Id == model.Id 
                || (rec.DateCreate >= model.DateFrom) && (rec.DateCreate <= model.DateTo)
                || (model.ClientId == rec.ClientId)
                || (model.FreeOrder.HasValue && model.FreeOrder.Value && !(rec.ImplementerFIO != null)) 
                || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == OrderStatus.Выполняется))
               .Include(ord => ord.Equipment)
               .Select(rec => new OrderViewModel()
               {
                   Id = rec.Id,
                   EquipmentId = rec.EquipmentId,
                   ClientFIO = rec.ClientFIO,
                   ClientId = rec.ClientId,
                   EquipmentName = rec.Equipment.EquipmentName,
                   ImplementorId = rec.ImplementerId,
                   ImplementerFIO = !string.IsNullOrEmpty(rec.ImplementerFIO) ? rec.ImplementerFIO : string.Empty,
                   Count = rec.Count,
                   DateCreate = rec.DateCreate,
                   DateImplement = rec.DateImplement,
                   Status = rec.Status,
                   Sum = rec.Sum
               }).ToList();
            }
        }
    }
}
