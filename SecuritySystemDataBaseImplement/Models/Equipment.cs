using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecuritySystemDataBaseImplement.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public string EquipmentName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual List<EquipmentDevice> EquipmentDevices { get; set; }
    }
}
