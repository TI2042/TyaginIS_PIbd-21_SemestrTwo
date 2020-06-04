using SecuritySystemBusinessLogic.Attributes;
using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SecuritySystemsBusinessLogic.ViewModels
{
    public class DeviceViewModel : BaseViewModel
    {
        [Column(title: "Устройство", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DeviceName { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "DeviceName" };
    }
}
