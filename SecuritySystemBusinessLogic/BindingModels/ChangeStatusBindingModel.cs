using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.BindingModels
{
    public class ChangeStatusBindingModel
    {
        public int OrderId { get; set; }
        public int? ImplementerId { get; set; }
        public string ImplementerFIO { set; get; }
    }
}
