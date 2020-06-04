using SecuritySystemsBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecuritySystemDataBaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int ClientId { set; get; }
        [Required]
        public string ClientFIO { set; get; }
        public int EquipmentId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public int? ImplementerId { set; get; }
        public string ImplementerFIO { set; get; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Client Client { set; get; }
        public virtual Equipment Equipment { get; set; }
        public virtual Implementer Implementer { set; get; }
    }
}
