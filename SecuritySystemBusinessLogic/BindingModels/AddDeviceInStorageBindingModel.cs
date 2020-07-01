using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.BindingModels
{
    public class AddDeviceInStorageBindingModel
    {
        public int StorageId { set; get; }
        public int DeviceId { set; get; }
        public int Count { set; get; }
    }
}
