using SecuritySystemFileImplement.Models;
using SecuritySystemsBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SecuritySystemFileImplement
{
    public class DataFileSingleton
    {
        private static DataFileSingleton instance;
        private readonly string DeviceFileName = "Device.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string EquipmentFileName = "Equipment.xml";
        private readonly string EquipmentDeviceFileName = "EquipmentDevice.xml";
        private readonly string StorageFileName = "Storage.xml";
        private readonly string StorageDeviceFileName = "StorageDevice.xml";
        public List<Device> Devices { get; set; }
        public List<Order> Orders { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<EquipmentDevice> EquipmentDevices { get; set; }
        public List<Storage> Storages { get; set; }

        public List<StorageDevice> StorageDevices { get; set; }
        private DataFileSingleton()
        {
            Devices = LoadDevices();
            Orders = LoadOrders();
            Equipments = LoadEquipments();
            EquipmentDevices = LoadEquipmentDevices();
            Storages = LoadStorages();
            StorageDevices = LoadStorageDevices();
        }

        public static DataFileSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataFileSingleton();
            }
            return instance;
        }

        ~DataFileSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveProducts();
            SaveProductComponents();
            SaveStorages();
            SaveStorageDevices();
        }

        private List<Device> LoadDevices()
        {
            var list = new List<Device>();
            if (File.Exists(DeviceFileName))
            {
                XDocument xDocument = XDocument.Load(DeviceFileName);
                var xElements = xDocument.Root.Elements("Device").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Device
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DeviceName = elem.Element("DeviceName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                if (xElements != null)
                {
                    foreach (var elem in xElements)
                    {
                        list.Add(new Order
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            EquipmentId = Convert.ToInt32(elem.Element("EquipmentId").Value),
                            Count = Convert.ToInt32(elem.Element("Count").Value),
                            Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                            Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                            DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                            DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                        });
                    }
                }
            }
            return list;
        }

        private List<Equipment> LoadEquipments()
        {
            var list = new List<Equipment>();
            if (File.Exists(EquipmentFileName))
            {
                XDocument xDocument = XDocument.Load(EquipmentFileName);
                var xElements = xDocument.Root.Elements("Equipment").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Equipment
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EquipmentName = elem.Element("EquipmentName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<Storage> LoadStorages()
        {
            var list = new List<Storage>();
            if (File.Exists(StorageFileName))
            {
                XDocument xDocument = XDocument.Load(StorageFileName);
                var xElements = xDocument.Root.Elements("Storage").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Storage
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StorageName = elem.Element("StorageName").Value
                    });
                }
            }
            return list;
        }

        private List<EquipmentDevice> LoadEquipmentDevices()
        {
            var list = new List<EquipmentDevice>();
            if (File.Exists(EquipmentDeviceFileName))
            {
                XDocument xDocument = XDocument.Load(EquipmentDeviceFileName);
                var xElements = xDocument.Root.Elements("EquipmentDevice").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new EquipmentDevice
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EquipmentId = Convert.ToInt32(elem.Element("EquipmentId").Value),
                        DeviceId = Convert.ToInt32(elem.Element("DeviceId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private List<StorageDevice> LoadStorageDevices()
        {
            var list = new List<StorageDevice>();
            if (File.Exists(StorageDeviceFileName))
            {
                XDocument xDocument = XDocument.Load(StorageDeviceFileName);
                var xElements = xDocument.Root.Elements("StorageDevice").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new StorageDevice
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StorageId = Convert.ToInt32(elem.Element("StorageId").Value),
                        DeviceId = Convert.ToInt32(elem.Element("DeviceId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Devices != null)
            {
                var xElement = new XElement("Devices");
                foreach (var component in Devices)
                {
                    xElement.Add(new XElement("Device",
                    new XAttribute("Id", component.Id),
                    new XElement("DeviceName", component.DeviceName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(DeviceFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("EquipmentId", order.EquipmentId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveProducts()
        {
            if (Equipments != null)
            {
                var xElement = new XElement("Equipments");
                foreach (var product in Equipments)
                {
                    xElement.Add(new XElement("Equipment",
                    new XAttribute("Id", product.Id),
                    new XElement("EquipmentName", product.EquipmentName),
                    new XElement("Price", product.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(EquipmentFileName);
            }
        }
        private void SaveStorages()
        {
            if (Storages != null)
            {
                var xElement = new XElement("Storages");
                foreach (var Storage in Storages)
                {
                    xElement.Add(new XElement("Storage",
                    new XAttribute("Id", Storage.Id),
                    new XElement("StorageName", Storage.StorageName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StorageFileName);
            }
        }

        private void SaveStorageDevices()
        {
            if (StorageDevices != null)
            {
                var xElement = new XElement("StorageDevices");
                foreach (var StorageDevice in StorageDevices)
                {
                    xElement.Add(new XElement("StorageDevice",
                    new XAttribute("Id", StorageDevice.Id),
                    new XElement("StorageId", StorageDevice.StorageId),
                    new XElement("DeviceId", StorageDevice.DeviceId),
                    new XElement("Count", StorageDevice.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StorageDeviceFileName);
            }
        }

        private void SaveProductComponents()
        {
            if (EquipmentDevices != null)
            {
                var xElement = new XElement("EquipmentDevices");
                foreach (var productComponent in EquipmentDevices)
                {
                    xElement.Add(new XElement("EquipmentDevice",
                    new XAttribute("Id", productComponent.Id),
                    new XElement("EquipmentId", productComponent.EquipmentId),
                    new XElement("DeviceId", productComponent.DeviceId),
                    new XElement("Count", productComponent.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(EquipmentDeviceFileName);
            }
        }
    }
}
