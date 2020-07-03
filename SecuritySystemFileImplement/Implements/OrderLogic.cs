using SecuritySystemFileImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Enums;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecuritySystemFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;

        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order order;
            if (model.Id.HasValue)
            {
                order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                    throw new Exception("Заказ не найден");
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
                order = new Order { Id = maxId + 1 };
                source.Orders.Add(order);
            }
            order.EquipmentId = model.EquipmentId;
            order.ClientFIO = model.ClientFIO;
            order.ClientId = (int)model.ClientId;
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.ImplementerFIO = model.ImplementerFIO;
            order.ImplementerId = model.ImplementerId;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            order.Sum = model.Sum;
        }

        public void Delete(OrderBindingModel model)
        {
            Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
            .Where(rec => model == null 
            || model.Id.HasValue && rec.Id == model.Id && rec.ClientId == model.ClientId 
            ||(model.DateTo.HasValue && model.DateFrom.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) 
            || (model.ClientId.HasValue && rec.ClientId == model.ClientId)
            ||(model.FreeOrder.HasValue && model.FreeOrder.Value && !(rec.ImplementerFIO != null)) 
            ||(model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == OrderStatus.Выполняется))
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                EquipmentId = rec.EquipmentId,
                EquipmentName = source.Equipments.FirstOrDefault((r) => r.Id == rec.EquipmentId).EquipmentName,
                ClientFIO = rec.ClientFIO,
                ClientId = rec.ClientId,
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
