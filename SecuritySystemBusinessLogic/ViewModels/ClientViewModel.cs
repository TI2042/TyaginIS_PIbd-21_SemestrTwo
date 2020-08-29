using SecuritySystemBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SecuritySystemBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { set; get; }
        [DataMember]
        public string Login { set; get; }
        [DataMember]
        public string Password { set; get; }

        public override List<string> Properties() => new List<string> { "Id", "ClientFIO" };
    }
}
