using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySystemBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<IGrouping<string, ReportOrdersViewModel>> Orders { get; set; }
    }
}
