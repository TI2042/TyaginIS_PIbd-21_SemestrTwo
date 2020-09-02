using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.BusinessLogic;
using SecuritySystemBusinessLogic.ViewModels;
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
    public partial class FormReportEquipmentDevices : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportEquipmentDevices(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dateTimePickerFrom.Value <= dateTimePickerTo.Value)
                {
                    var orders = logic.GetOrders(new ReportBindingModel()
                    {
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    });

                    foreach (var orderGroup in orders)
                    {
                        dataGridView.Rows.Add(orderGroup.Key, "", "");
                        decimal sum = 0;
                        foreach (var order in orderGroup)
                        {
                            dataGridView.Rows.Add("", order.EquipmentName, order.Sum);
                            sum += order.Sum;
                        }
                        dataGridView.Rows.Add("Всего:", "", sum);
                    }
                }
                else
                    MessageBox.Show("Начало периода не должно превышать его конец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                dataGridView.Rows.Clear();
                var query = logic.GetOrders(new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value.Date,
                    DateTo = dateTimePickerTo.Value.Date
                });
                foreach (IGrouping<DateTime, ReportOrdersViewModel> group in query)
                {
                    dataGridView.Rows.Add(new object[] { group.Key.ToShortDateString(), "", ""
});
                    decimal total = 0;
                    foreach (var model in group)
                    {
                        dataGridView.Rows.Add(new object[] { "", model.EquipmentName,
                            model.Sum });
                        total += model.Sum;
                    }
                    dataGridView.Rows.Add(new object[] { "Итого", "", total });
                    dataGridView.Rows.Add(new object[] { });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
