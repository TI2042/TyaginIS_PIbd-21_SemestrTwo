using SecuritySystemListImplement.Implements;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using SecuritySysytemImplement.Implements;

namespace SecuritySystemView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IDeviceLogic, DeviceLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEquipmentLogic, EquipmentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
