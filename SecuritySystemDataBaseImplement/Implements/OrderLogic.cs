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
                        Order order;
                        if (model.Id.HasValue)
                        {
                            order = context.Orders.ToList().FirstOrDefault(rec => rec.Id == model.Id);
                            if (order == null)
                                throw new Exception("Элемент не найден");                        
                        }
                        else
                        {
                            order = new Order();
                            context.Orders.Add(order);
                        }
                        order.ClientFIO = model.ClientFIO;
                        order.ClientId = model.ClientId;
                        order.EquipmentId = model.EquipmentId;
                        order.Count = model.Count;
                        order.DateCreate = model.DateCreate;
                        order.DateImplement = model.DateImplement;
                        order.Status = model.Status;
                        order.Sum = model.Sum;
                        order.ImplementerId = model.ImplementerId;
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
                return context.Orders.Where(rec => model == null || rec.Id == model.Id || (rec.DateCreate >= model.DateFrom)
                && (rec.DateCreate <= model.DateTo) || (model.ClientId == rec.ClientId) ||
                (model.FreeOrder.HasValue && model.FreeOrder.Value && !rec.ImplementerId.HasValue) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == OrderStatus.Выполняется))
                .Include(ord => ord.Equipment)
                .Include(ord => ord.Implementer)
                .Select(rec => new OrderViewModel()
                {
                    Id = rec.Id,
                    EquipmentId = rec.EquipmentId,
                    EquipmentName = context.Equipments.FirstOrDefault((r) => r.Id == rec.EquipmentId).EquipmentName,
                    ClientFIO = rec.ClientFIO,
                    ClientId = rec.ClientId,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ImplementorId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer.ImplementerFIO,
                    Status = rec.Status,
                    Sum = rec.Sum
                }).ToList();
            }
        }
    }
}
