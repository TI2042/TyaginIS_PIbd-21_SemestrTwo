using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemFileImplement.Models
{
    public class Implementer
    {
        public int Id { set; get; }
        public string ImplementerFIO { set; get; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
