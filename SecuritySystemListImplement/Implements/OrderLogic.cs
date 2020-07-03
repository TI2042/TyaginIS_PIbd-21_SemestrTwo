
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
                    throw new Exception("Заказ не найден");
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
            throw new Exception("Заказ не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null)
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
            Equipment Equipment = null;
            foreach (Equipment b in source.Equipments)
            {
                if (b.Id == model.EquipmentId)
                {
                    Equipment = b;
                    break;
                }
            }
            Client client = null;
            foreach (Client c in source.Clients)
            {
                if (c.Id == model.ClientId)
                {
                    client = c;
                    break;
                }
            }
            Implementer implementer = null;
            foreach (Implementer i in source.Implementers)
            {
                if (i.Id == model.ImplementerId)
                {
                    implementer = i;
                    break;
                }
            }
            if (Equipment == null || client == null || model.ImplementerId.HasValue && implementer == null)
            {
                throw new Exception("Элемент не найден");
            }
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
            Equipment Equipment = null;
            foreach (Equipment b in source.Equipments)
            {
                if (b.Id == order.EquipmentId)
                {
                    Equipment = b;
                    break;
                }
            }
            Client client = null;
            foreach (Client c in source.Clients)
            {
                if (c.Id == order.ClientId)
                {
                    client = c;
                    break;
                }
            }
            Implementer implementer = null;
            foreach (Implementer i in source.Implementers)
            {
                if (i.Id == order.ImplementerId)
                {
                    implementer = i;
                    break;
                }
            }
            if (Equipment == null || client == null || order.ImplementerId.HasValue && implementer == null)
            {
                throw new Exception("Элемент не найден");
            }
            return new OrderViewModel
            {
                Id = order.Id,
                EquipmentId = order.EquipmentId,
                EquipmentName = Equipment.EquipmentName,
                ClientId = order.ClientId,
                ClientFIO = client.ClientFIO,
                ImplementorId = order.ImplementerId,
                ImplementerFIO = implementer.ImplementerFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
