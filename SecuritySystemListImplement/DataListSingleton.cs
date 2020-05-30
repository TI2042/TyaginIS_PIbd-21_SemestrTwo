using SecuritySystemFileImplement.Models;
using System;
using System.Collections.Generic;

namespace SecuritySystemFileImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Device> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Equipment> Products { get; set; }
        public List<EquipmentDevice> ProductComponents { get; set; }

        private DataListSingleton()
        {
            Components = new List<Device>();
            Orders = new List<Order>();
            Products = new List<Equipment>();
            ProductComponents = new List<EquipmentDevice>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
