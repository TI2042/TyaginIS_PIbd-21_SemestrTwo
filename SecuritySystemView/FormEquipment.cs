using SecuritySystemsBusinessLogic.BindingModels;
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
    public partial class FormEquipment : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IEquipmentLogic logic;

        private int? id;

        private List<EquipmentDeviceViewModel> equipmentDevices;

        public FormEquipment(IEquipmentLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    EquipmentViewModel view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.EquipmentName;
                        textBoxPrice.Text = view.Price.ToString();
                        equipmentDevices = view.ProductComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                equipmentDevices = new List<EquipmentDeviceViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (equipmentDevices != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = equipmentDevices;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEquipmentDevice>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ModelView != null)
                {
                    if (id.HasValue)
                    {
                        form.ModelView.EquipmentId = id.Value;
                    }
                    equipmentDevices.Add(form.ModelView);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormEquipmentDevice>();
                form.ModelView = equipmentDevices[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    equipmentDevices[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.ModelView;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        equipmentDevices.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (equipmentDevices == null || equipmentDevices.Count == 0)
            {
                MessageBox.Show("Заполните устройства", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<EquipmentDeviceBindingModel> productDeviceBM = new List<EquipmentDeviceBindingModel>();
                for (int i = 0; i < equipmentDevices.Count; ++i)
                {
                    productDeviceBM.Add(new EquipmentDeviceBindingModel
                    {
                        Id = equipmentDevices[i].Id,
                        EquipmentId = equipmentDevices[i].EquipmentId,
                        DeviceId = equipmentDevices[i].DeviceId,
                        Count = equipmentDevices[i].Count
                    });
                }
                if (id.HasValue)
                {
                    logic.UpdElement(new EquipmentBindingModel
                    {
                        Id = id.Value,
                        EquipmentName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        EquipmentDevices = productDeviceBM
                    });
                }
                else
                {
                    logic.AddElement(new EquipmentBindingModel
                    {
                        EquipmentName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        EquipmentDevices = productDeviceBM
                    });
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
