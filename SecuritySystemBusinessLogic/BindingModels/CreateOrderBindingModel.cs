using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int EquipmentId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
