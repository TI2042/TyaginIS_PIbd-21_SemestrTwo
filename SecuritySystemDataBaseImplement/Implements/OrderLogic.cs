using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemDataBaseImplement.Models;
using SecuritySystemsBusinessLogic.ViewModels;


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
                        Order order= context.Orders.ToList().FirstOrDefault(rec => rec.Id == model.Id);
                        if (model.Id.HasValue)
                        {
                            if (order == null)
                                throw new Exception("Элемент не найден");                           
                        }
                        else
                        {                           
                            context.Orders.Add(order);
                        }
                        order.EquipmentId = model.EquipmentId;
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
                return context.Orders
                    .Where(
                        rec => model == null
                        || (rec.Id == model.Id && model.Id.HasValue)
                        || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                    )
                    .Include(rec => rec.Equipment)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        EquipmentName = rec.Equipment.EquipmentName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                    })
            .ToList();
            }
        }
    }
}
