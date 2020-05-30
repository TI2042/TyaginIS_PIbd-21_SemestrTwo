using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.ViewModels
{
    public class ReportDeviceEquipmentViewModel
    {
        public string DeviceName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Equipments { get; set; }
    }
}
