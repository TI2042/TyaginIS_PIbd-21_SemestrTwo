using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);

        void CreateOrUpdate(OrderBindingModel model);

        void Delete(OrderBindingModel model);
    }
}
