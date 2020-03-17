using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SecuritySystemsBusinessLogic.ViewModels
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название комплектации")]
        public string EquipmentName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public List<EquipmentDeviceViewModel> ProductComponents { get; set; }
    }
}
