using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using SecuritySystemDataBaseImplement.Implements;
using SecuritySystemBusinessLogic.BusinessLogic;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.HelperModels;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemBusinessLogic.Attributes;

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

            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
            });

            var timer = new System.Threading.Timer(new TimerCallback(MailCheck), new MailCheckInfo
            {
                PopHost = ConfigurationManager.AppSettings["PopHost"],
                PopPort = Convert.ToInt32(ConfigurationManager.AppSettings["PopPort"]),
                Logic = container.Resolve<IMessageInfoLogic>()
            }, 0, 100000);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IDeviceLogic, DeviceLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEquipmentLogic, EquipmentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IImplementerLogic, ImplementerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<WorkModeling>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMessageInfoLogic, MessageInfoLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<BackUpAbstractLogic, BackUpLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
        public static void ConfigGrid<T>(List<T> data, DataGridView grid)
        {
            var type = typeof(T);
            if (type.BaseType == typeof(BaseViewModel))
            {
                object obj = Activator.CreateInstance(type);
                var method = type.GetMethod("Properties");
                var config = (List<string>)method.Invoke(obj, null);
                grid.Columns.Clear();
                foreach (var conf in config)
                {
                    var prop = type.GetProperty(conf);
                    if (prop != null)
                    {
                        var attributes = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
                        if (attributes != null && attributes.Length > 0)
                        {
                            foreach (var attr in attributes)
                            {
                                // ищем нужный нам атрибут
                                if (attr is ColumnAttribute columnAttr)
                                {
                                    var column = new DataGridViewTextBoxColumn
                                    {
                                        Name = conf,
                                        ReadOnly = true,
                                        HeaderText = columnAttr.Title,
                                        Visible = columnAttr.Visible,
                                        Width = columnAttr.Width
                                    };
                                    if (columnAttr.GridViewAutoSize != GridViewAutoSize.None)
                                    {
                                        column.AutoSizeMode = (DataGridViewAutoSizeColumnMode)Enum.Parse(typeof(DataGridViewAutoSizeColumnMode),
                                       columnAttr.GridViewAutoSize.ToString());
                                    }
                                    grid.Columns.Add(column);
                                }
                            }
                        }
                    }
                }
                // добавляем строки
                foreach (var elem in data)
                {
                    List<object> objs = new List<object>();
                    foreach (var conf in config)
                    {
                        var value = elem.GetType().GetProperty(conf).GetValue(elem);
                        objs.Add(value);
                    }
                    grid.Rows.Add(objs.ToArray());
                }
            }
        }
    }
}
