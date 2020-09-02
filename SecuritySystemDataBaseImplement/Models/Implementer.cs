using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecuritySystemDataBaseImplement.Models
{
    public class Implementer
    {
        public int Id { set; get; }
        public string ImplementerFIO { set; get; }
        [Required]
        public int WorkTime { set; get; }
        [Required]
        public int PauseTime { set; get; }
        public virtual List<Order> Orders { set; get; }
    }
}
