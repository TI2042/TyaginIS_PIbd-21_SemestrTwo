using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.Interfaces
{
    public interface IEquipmentLogic
    {
        List<EquipmentViewModel> GetList();

        EquipmentViewModel GetElement(int id);

        void AddElement(EquipmentBindingModel model);

        void UpdElement(EquipmentBindingModel model);

        void DelElement(int id);
    }
}
