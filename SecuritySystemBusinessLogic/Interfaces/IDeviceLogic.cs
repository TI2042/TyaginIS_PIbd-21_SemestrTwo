using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemsBusinessLogic.Interfaces
{
    public interface IDeviceLogic
    {
        List<DeviceViewModel> Read(DeviceBindingModel model);
        void CreateOrUpdate(DeviceBindingModel model);
        void Delete(DeviceBindingModel model);
    }
}
