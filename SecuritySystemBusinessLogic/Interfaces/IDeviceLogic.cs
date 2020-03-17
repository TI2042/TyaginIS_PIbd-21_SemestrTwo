using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.Interfaces
{
    public interface IDeviceLogic
    {
        List<DeviceViewModel> GetList();

        DeviceViewModel GetElement(int id);

        void AddElement(DeviceBindingModel model);

        void UpdElement(DeviceBindingModel model);

        void DelElement(int id);
    }
}
