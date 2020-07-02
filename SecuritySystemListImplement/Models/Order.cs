using SecuritySystemsBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemListImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? ClientId { set; get; }
        public string ClientFIO { set; get; }

        public int EquipmentId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
        public int? ImplementerId { set; get; }
        public string ImplementerFIO { set; get; }
        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
    }
}
