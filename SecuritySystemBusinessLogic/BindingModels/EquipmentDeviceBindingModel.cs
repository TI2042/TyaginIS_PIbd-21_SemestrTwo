using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.BindingModels
{
    public class EquipmentDeviceBindingModel
    {
        public int Id { get; set; }

        public int EquipmentId { get; set; }

        public int DeviceId { get; set; }

        public int Count { get; set; }
    }
}
