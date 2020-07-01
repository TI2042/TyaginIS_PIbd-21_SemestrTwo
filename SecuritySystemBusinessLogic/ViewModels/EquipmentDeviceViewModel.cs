using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SecuritySystemBusinessLogic.ViewModels
{
    public class EquipmentDeviceViewModel
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int DeviceId { get; set; }
        [DisplayName("Уcтройство")]
        public string DeviceName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
