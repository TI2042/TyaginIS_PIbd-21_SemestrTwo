using SecuritySystemListImplement.Models;
using System;
using System.Collections.Generic;

namespace SecuritySystemListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Device> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Equipment> Products { get; set; }
        public List<EquipmentDevice> ProductComponents { get; set; }
        public List<Client> Clients { set; get; }

        private DataListSingleton()
        {
            Components = new List<Device>();
            Orders = new List<Order>();
            Products = new List<Equipment>();
            ProductComponents = new List<EquipmentDevice>();
            Clients = new List<Client>();
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
