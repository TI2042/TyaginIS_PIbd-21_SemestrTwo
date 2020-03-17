using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.BindingModels
{
    public class EquipmentBindingModel
    {
        public int Id { get; set; }

        public string EquipmentName { get; set; }

        public decimal Price { get; set; }

        public List<EquipmentDeviceBindingModel> EquipmentDevices { get; set; }
    }
}
