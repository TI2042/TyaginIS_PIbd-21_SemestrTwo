using SecuritySystemBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SecuritySystemBusinessLogic.ViewModels
{
    public abstract class BaseViewModel
    {
        [Column(visible: false)]
        [DataMember]
        public int Id { set; get; }
        public abstract List<string> Properties();
    }
}
