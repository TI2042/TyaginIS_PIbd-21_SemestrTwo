using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.HelperModels;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
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
        public List<IGrouping<DateTime, ReportOrdersViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
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
            .GroupBy(x => x.DateCreate.Date)
           .ToList();
        }
            return list;
        }

        public void SaveEquipmentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Комплектации",
                Equipments = equipmentLogic.Read(null)
            });
        }

        public void SaveProductComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Заказы",
                DateTo = model.DateTo,
                DateFrom = model.DateFrom,
                Orders = GetOrders(model)
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
