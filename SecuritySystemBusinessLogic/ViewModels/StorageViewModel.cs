using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SecuritySystemBusinessLogic.ViewModels
{
    public class StorageViewModel
    {
        public int Id { set; get; }
        [DisplayName("Склад")]
        public string StorageName { set; get; }
        public Dictionary<string, int> StorageDevices { get; set; }
    }
}
