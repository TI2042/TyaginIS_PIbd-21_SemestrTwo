using SecuritySystemBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SecuritySystemBusinessLogic.ViewModels
{
    public class ImplementerViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Время работы", width: 100)]
        public int WorkingTime { get; set; }
        [DataMember]
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ImplementerFIO", "WorkingTime", "PauseTime" };
    }
}
