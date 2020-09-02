using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecuritySystemDataBaseImplement.Models
{
    public class EquipmentDevice
    {
        public int Id { get; set; }

        public int EquipmentId { get; set; }

        public int DeviceId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Device Device { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
