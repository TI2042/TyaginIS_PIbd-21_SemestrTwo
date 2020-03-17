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
using Unity;

namespace SecuritySystemView
{
    public partial class FormEquipmentDevice : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }

        public EquipmentDeviceViewModel ModelView { get; set; }

        private readonly IDeviceLogic logic;

        public FormEquipmentDevice(IDeviceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormProductComponent_Load(object sender, EventArgs e)
        {
            try
            {
                List<DeviceViewModel> list = logic.GetList();
                if (list != null)
                {
                    comboBoxComponent.DisplayMember = "DeviceName";
                    comboBoxComponent.ValueMember = "Id";
                    comboBoxComponent.DataSource = list;
                    comboBoxComponent.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ModelView != null)
            {
                comboBoxComponent.Enabled = false;
                comboBoxComponent.SelectedValue = ModelView.DeviceId;
                textBoxCount.Text = ModelView.Count.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите устройство", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (ModelView == null)
                {
                    ModelView = new EquipmentDeviceViewModel
                    {
                        DeviceId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                        DeviceName = comboBoxComponent.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    ModelView.Count = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
