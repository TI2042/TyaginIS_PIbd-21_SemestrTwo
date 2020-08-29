using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.BusinessLogic;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecuritySystemBusinessLogic.BusinessLogic
{
    public class WorkModeling
    {
        private readonly IImplementerLogic implementerLogic;
        private readonly IOrderLogic orderLogic;
        private readonly MainLogic mainLogic;
        private readonly Random rnd;

        public WorkModeling(IImplementerLogic implementerLogic, IOrderLogic orderLogic, MainLogic mainLogic)
        {
            this.implementerLogic = implementerLogic;
            this.orderLogic = orderLogic;
            this.mainLogic = mainLogic;
            rnd = new Random(1000);
        }

        public void DoWork()
        {
            var implementers = implementerLogic.Read(null);
            var orders = orderLogic.Read(new OrderBindingModel { FreeOrder = true });
            foreach (var implementer in implementers)
            {
                WorkerWorkAsync(implementer, orders);
            }
        }

        private async void WorkerWorkAsync(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {
            // ищем заказы, которые уже в работе (вдруг исполнителя прервали)
            var runOrders = await Task.Run(() => orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id
            }));
            foreach (var order in runOrders)
            {
                // делаем работу заново
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                mainLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = order.Id
                });
                // отдыхаем
                Thread.Sleep(implementer.PauseTime);
            }
            await Task.Run(() =>
            {
                foreach (var order in orders)
                {
                    // пытаемся назначить заказ на исполнителя
                    try
                    {
                        mainLogic.TakeOrderInWork(new ChangeStatusBindingModel
                        {
                            OrderId = order.Id,
                            ImplementerId = implementer.Id,
                            ImplementerFIO = implementer.ImplementerFIO
                        });
                        // делаем работу
                        Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                        mainLogic.FinishOrder(new ChangeStatusBindingModel
                        {
                            OrderId = order.Id
                        });
                        // отдыхаем
                        Thread.Sleep(implementer.PauseTime);
                    }
                    catch (Exception) { }
                }
            });
        }
    }
}
