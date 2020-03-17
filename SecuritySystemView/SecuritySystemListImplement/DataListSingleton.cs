using SecuritySystemListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Device> Devices { get; set; }

        public List<Order> Orders { get; set; }

        public List<Equipment> Equipments { get; set; }

        public List<EquipmentDevice> EquipmentDevices { get; set; }

        private DataListSingleton()
        {
            Devices = new List<Device>();
            Orders = new List<Order>();
            Equipments = new List<Equipment>();
            EquipmentDevices = new List<EquipmentDevice>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null) { instance = new DataListSingleton(); }

            return instance;
        }
    }
}
