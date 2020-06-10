using SecuritySystemListImplement.Implements;
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
        public List<Storage> Storages { get; set; }
        public List<StorageDevices> StorageDevices { get; set; }

        private DataListSingleton()
        {
            Components = new List<Device>();
            Orders = new List<Order>();
            Products = new List<Equipment>();
            ProductComponents = new List<EquipmentDevice>();
            Storages = new List<Storage>();
            StorageDevices = new List<StorageDevices>();
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
