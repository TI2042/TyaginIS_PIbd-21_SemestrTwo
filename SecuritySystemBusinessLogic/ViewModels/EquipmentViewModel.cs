using SecuritySystemBusinessLogic.Attributes;
using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SecuritySystemsBusinessLogic.ViewModels
{
    [DataContract]
    public class EquipmentViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Комплектация", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string EquipmentName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> EquipmentDevices { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "EquipmentName", "Price" };
    }
}
