using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuritySystemRestApi.Models
{
    public class Equipment
    {
        public int Id { set; get; }
        public string EquipmentName { set; get; }
        public decimal Price { set; get; }
    }
}
