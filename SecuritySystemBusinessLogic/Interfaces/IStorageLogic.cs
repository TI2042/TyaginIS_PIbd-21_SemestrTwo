using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.Interfaces
{
    public interface IStorageLogic
    {
        List<StorageViewModel> Read(StorageBindingModel model);
        void CreateOrUpdate(StorageBindingModel model);
        void Delete(StorageBindingModel model);
        void AddDeviceToStorage(AddDeviceInStorageBindingModel model);
    }
}
