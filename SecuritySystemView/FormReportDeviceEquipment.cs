using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.BusinessLogic;
using System;
using Microsoft.Reporting.WinForms;
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
    public partial class FormReportDeviceEquipment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportDeviceEquipment(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;

        }

        private void ButtonMake_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetEquipmentDevices();
                ReportDataSource source = new ReportDataSource("DataSet1", dataSource);
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveEquipmentDevicesToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportDeviceEquipment_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void FormReportDeviceEquipment_Load_1(object sender, EventArgs e)
        {

        }
    }
}
