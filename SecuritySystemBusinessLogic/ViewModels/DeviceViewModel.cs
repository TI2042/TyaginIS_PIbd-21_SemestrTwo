using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SecuritySystemsBusinessLogic.ViewModels
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название устройства")]
        public string DeviceName { get; set; }
    }
}
