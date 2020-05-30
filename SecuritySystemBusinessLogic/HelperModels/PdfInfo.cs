using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportEquipmentDeviceViewModel> Equipments { get; set; }
    }
}
