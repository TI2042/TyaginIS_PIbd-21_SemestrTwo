using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.HelperModels;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySystemBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IDeviceLogic deviceLogic;
        private readonly IEquipmentLogic equipmentLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IEquipmentLogic productLogic, IDeviceLogic componentLogic, IOrderLogic orderLLogic)
        {
            this.equipmentLogic = productLogic;
            this.deviceLogic = componentLogic;
            this.orderLogic = orderLLogic;
        }

        // Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportDeviceEquipmentViewModel> GetProductComponent()
        {
            var components = deviceLogic.Read(null);
            var products = equipmentLogic.Read(null);
            var list = new List<ReportDeviceEquipmentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportDeviceEquipmentViewModel
                {
                    DeviceName = component.DeviceName,
                    Equipments = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var product in products)
                {
                    if (product.EquipmentDevices.ContainsKey(component.Id))
                    {
                        record.Equipments.Add(new Tuple<string, int>(product.EquipmentName, product.EquipmentDevices[component.Id].Item2));
                        record.TotalCount += product.EquipmentDevices[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportEquipmentDeviceViewModel> GetEquipmentDevices()
        {
            List<ReportEquipmentDeviceViewModel> reports = new List<ReportEquipmentDeviceViewModel>();
            foreach (var equipment in equipmentLogic.Read(null))
            {
                foreach (var device in equipment.EquipmentDevices)
                {
                    reports.Add(new ReportEquipmentDeviceViewModel()
                    {
                        EquipmentName = equipment.EquipmentName,
                        DeviceName = device.Value.Item1,
                        DeviceCount = device.Value.Item2
                    });
                }
            }
            return reports;
        }

        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                EquipmentName = x.EquipmentName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        //скорее всего надо будет переработать
        public List<ReportOrdersViewModel> GetOrders()
        {
            return orderLogic.Read(null)
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                EquipmentName = x.EquipmentName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        // Сохранение компонент в файл-Word
        public void SaveEquipmentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Комплектации",
                Equipments = equipmentLogic.Read(null)
            });
        }

        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SaveProductComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Заказы",
                Orders = GetOrders()
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveEquipmentDevicesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Комплектации",
                Equipments = GetEquipmentDevices()
            });
        }
    }
}
