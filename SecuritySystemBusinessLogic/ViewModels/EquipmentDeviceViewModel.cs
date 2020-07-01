using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SecuritySystemBusinessLogic.ViewModels
{
    public class EquipmentDeviceViewModel
    {
        public int Id { get; set; }
        public int EqupmentId { get; set; }
        public int DeviceId { get; set; }
        [DisplayName("Умтройство")]
        public string DeviceName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
