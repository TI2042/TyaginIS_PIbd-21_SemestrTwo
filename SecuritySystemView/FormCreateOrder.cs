using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using SecuritySystemsBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.ViewModels;

namespace SecuritySystemView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly IEquipmentLogic logicP;
        private readonly IClientLogic logicC;
        private readonly MainLogic logicM;

        public FormCreateOrder(IEquipmentLogic logicP, MainLogic logicM, IClientLogic logicC)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicM = logicM;
            this.logicC = logicC;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listP = logicP.Read(null); if (listP != null)
                {
                    comboBoxProduct.DisplayMember = "EquipmentName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = listP;
                    comboBoxProduct.SelectedItem = null;
                }
                var listClients = logicC.Read(null);
                if (listClients != null)
                {
                    comboBoxClients.DisplayMember = "ClientFIO";
                    comboBoxClients.DataSource = listClients;
                    comboBoxClients.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    EquipmentViewModel equipment = logicP.Read(new EquipmentBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * equipment.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClients.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите комплектацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    EquipmentId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    ClientId = (comboBoxClients.SelectedItem as ClientViewModel).Id,
                    ClientFIO = (comboBoxClients.SelectedItem as ClientViewModel).ClientFIO
                });
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
