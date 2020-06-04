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
        public List<IGrouping<string, ReportOrdersViewModel>> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .ToList()
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                EquipmentName = x.EquipmentName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .GroupBy(x => x.DateCreate.ToShortDateString())
           .ToList();
        }

        // Сохранение компонент в файл-Word
        public void SaveEquipmentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Комплектация",
                Equipments = equipmentLogic.Read(null)
            });
        }

        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Заказы",
                Orders = GetOrders(model)
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveEquipmentDevicesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Комплектация",
                Equipments = GetEquipmentDevices()
            });
        }
    }
}
