using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.Interfaces
{
    public interface IEquipmentLogic
    {
        List<EquipmentViewModel> Read(EquipmentBindingModel model);
        void CreateOrUpdate(EquipmentBindingModel model);
        void Delete(EquipmentBindingModel model);
    }
}
