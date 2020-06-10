using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int? Id { set; get; }
        public string StorageName { set; get; }

        public Dictionary<string, int> StorageDevices { get; set; }

    }
}
