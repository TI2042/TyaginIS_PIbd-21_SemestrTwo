using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemsBusinessLogic.BusinessLogic;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecuritySystemView
{
    public partial class FormStorageAddDevcies : Form
    {
        private readonly MainLogic mainLogic;
        private readonly IStorageLogic storageLogic;
        private readonly IDeviceLogic DeviceLogic;
        private List<StorageViewModel> storageViews;
        private List<DeviceViewModel> DeviceViews;
        public FormStorageAddDevcies(MainLogic mainLogic, IStorageLogic storageLogic, IDeviceLogic DeviceLogic)
        {
            InitializeComponent();
            this.mainLogic = mainLogic;
            this.storageLogic = storageLogic;
            this.DeviceLogic = DeviceLogic;
            LoadData();
        }
        private void LoadData()
        {
            storageViews = storageLogic.Read(null);
            if (storageViews != null)
            {
                comboBoxStorage.DataSource = storageViews;
                comboBoxStorage.DisplayMember = "StorageName";
            }
            DeviceViews = DeviceLogic.Read(null);
            if (DeviceViews != null)
            {
                comboBoxDevice.DataSource = DeviceViews;
                comboBoxDevice.DisplayMember = "DeviceName";
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxKol.Text == string.Empty)
            {
                throw new Exception("Введите количество устройств");
            }
            mainLogic.AddDevices(new AddDeviceInStorageBindingModel()
            {
                StorageId = (comboBoxStorage.SelectedItem as StorageViewModel).Id,
                DeviceId = (comboBoxDevice.SelectedItem as DeviceViewModel).Id,
                Count = Convert.ToInt32(textBoxKol.Text)
            });
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
