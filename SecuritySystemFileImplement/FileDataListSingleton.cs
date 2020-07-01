using SecuritySystemFileImplement.Models;
using SecuritySystemsBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SecuritySystemFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string DeviceFileName = "Device.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string EquipmentFileName = "Equipment.xml";
        private readonly string EquipmentDeviceFileName = "EquipmentDevice.xml";
        public List<Device> Devices { get; set; }
        public List<Order> Orders { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<EquipmentDevice> EquipmentDevices { get; set; }

        private FileDataListSingleton()
        {
            Devices = LoadDevices();
            Orders = LoadOrders();
            Equipments = LoadEquipments();
            EquipmentDevices = LoadEquipmentDevices();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveProducts();
            SaveProductComponents();
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
