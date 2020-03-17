using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.ViewModels;
using SecuritySystemsBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace SecuritySystemView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly IEquipmentLogic logicP;

        private readonly MainLogic logicM;

        public FormCreateOrder(IEquipmentLogic logicP, MainLogic logicM)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicM = logicM;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {

        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    EquipmentViewModel equipment = logicP.GetElement(id);
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

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
