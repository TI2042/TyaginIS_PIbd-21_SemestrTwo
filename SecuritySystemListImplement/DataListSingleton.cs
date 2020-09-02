using SecuritySystemListImplement.Models;
using System.Collections.Generic;

namespace SecuritySystemListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Device> Devices { get; set; }

        public List<Order> Orders { get; set; }

        public List<Equipment> Equipments { get; set; }

        public List<EquipmentDevice> EquipmentDevices { get; set; }

        public List<Client> Clients { set; get; }
        public List<Implementer> Implementers { set; get; }
        public List<MessageInfo> MessageInfoes { get; set; }

        private DataListSingleton()
        {
            Devices = new List<Device>();
            Orders = new List<Order>();
            Equipments = new List<Equipment>();
            EquipmentDevices = new List<EquipmentDevice>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfoes = new List<MessageInfo>();
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
