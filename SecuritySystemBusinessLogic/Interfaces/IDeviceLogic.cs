using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.Interfaces
{
    public interface IDeviceLogic
    {
        List<DeviceViewModel> Read(DeviceBindingModel model);
        void CreateOrUpdate(DeviceBindingModel model);
        void Delete(DeviceBindingModel model);
    }
}
