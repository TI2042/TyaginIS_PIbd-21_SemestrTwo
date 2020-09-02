using Microsoft.AspNetCore.Mvc;
using SecuritySystemRestApi.Models;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.BusinessLogic;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuritySystemRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IEquipmentLogic _equipment;
        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IEquipmentLogic product, MainLogic main)
        {
            _order = order;
            _equipment = product;
            _main = main;
        }

        [HttpGet]
        public List<Equipment> GetEquipmentList() => _equipment.Read(null)?.Select(rec => Convert(rec)).ToList();

        [HttpGet]
        public Equipment GetEquipment(int equipmentId) => Convert(_equipment.Read(new EquipmentBindingModel
        {
            Id = equipmentId
        })?[0]);

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        {
            ClientId = clientId
        });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);

        private Equipment Convert(EquipmentViewModel model)
        {
            if (model == null) return null;
            return new Equipment
            {
                Id = model.Id,
                EquipmentName = model.EquipmentName,
                Price = model.Price
            };
        }
    }
}
