
using SecuritySystemListImplement.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Enums;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecuritySystemListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;

        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order
            {
                Id = 1
            };
            foreach (var order in source.Orders)
            {

                if (!model.Id.HasValue && order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
                else if (model.Id.HasValue && order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null && order.Id == model.Id
                    || model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo && order.ClientId == model.ClientId
                )
                {
                    if (model != null)
                    {
                        if (order.Id == model.Id && model.Id.HasValue)
                        {
                            result.Add(CreateViewModel(order));
                            break;
                        }
                        else if (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate >= model.DateFrom &&
                          order.DateCreate <= model.DateTo)
                            result.Add(CreateViewModel(order));
                        else if (model.ClientId.HasValue && order.ClientId == model.ClientId)
                            result.Add(CreateViewModel(order));
                        else if (model.FreeOrder.HasValue && model.FreeOrder.Value && !(order.ImplementerFIO != null))
                            result.Add(CreateViewModel(order));
                        else if (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId.Value && order.Status == OrderStatus.Выполняется)
                            result.Add(CreateViewModel(order));
                        continue;
                    }
                    result.Add(CreateViewModel(order));
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.Count = model.Count;
            order.ClientId = model.ClientId.Value;
            order.ClientFIO = model.ClientFIO;
            order.DateCreate = model.DateCreate;
            order.ImplementerId = model.ImplementerId;
            order.ImplementerFIO = model.ImplementerFIO;
            order.DateImplement = model.DateImplement;
            order.EquipmentId = model.EquipmentId;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.ClientId = model.ClientId;
            order.ClientFIO = model.ClientFIO;
            return order;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            var equipmentName = source.Equipments.FirstOrDefault((n) => n.Id == order.EquipmentId).EquipmentName;
            return new OrderViewModel
            {
                Id = order.Id,
                Count = order.Count,
                ClientId = order.ClientId,
                ClientFIO = order.ClientFIO,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                EquipmentName = equipmentName,
                EquipmentId = order.EquipmentId,
                Status = order.Status,
                Sum = order.Sum,
            };
        }
    }
}
