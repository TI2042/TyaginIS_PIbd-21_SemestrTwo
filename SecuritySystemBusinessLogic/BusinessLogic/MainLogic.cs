using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Enums;
using SecuritySystemsBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IStorageLogic storageLogic;
        private readonly IEquipmentLogic equipmentLogic;
        public MainLogic(IOrderLogic orderLogic, IEquipmentLogic equipmentLogic, IStorageLogic storageLogic)
        {
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
            this.equipmentLogic = equipmentLogic;

        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                EquipmentId = model.EquipmentId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (storageLogic.RemoveDevices(order))
            {
                if (order.Status != OrderStatus.Принят)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }
                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    EquipmentId = order.EquipmentId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now,
                    Status = OrderStatus.Выполняется
                });
            }
            else
            {
                throw new Exception("Не хватает устройств на складах!");
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                EquipmentId = order.EquipmentId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                EquipmentId = order.EquipmentId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
       
        public void AddDevices(AddDeviceInStorageBindingModel model)
        {
            storageLogic.AddDeviceToStorage(model);
        }
    }
}
