using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<EquipmentViewModel> Equipments { get; set; }
    }
}
