using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.Interfaces
{
    public interface IEquipmentLogic
    {
        List<EquipmentViewModel> Read(EquipmentBindingModel model);
        void CreateOrUpdate(EquipmentBindingModel model);
        void Delete(EquipmentBindingModel model);
    }
}
