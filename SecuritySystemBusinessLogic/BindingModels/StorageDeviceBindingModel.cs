using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.BindingModels
{
    public class StorageDeviceBindingModel
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int DeviceId { get; set; }

        public int Count { get; set; }
    }
}
