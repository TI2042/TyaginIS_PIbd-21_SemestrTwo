﻿using SecuritySystemsBusinessLogic.BindingModels;
using SecuritySystemsBusinessLogic.Interfaces;
using SecuritySystemsBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;
using SecuritySystemBusinessLogic.BusinessLogic;
using SecuritySystemBusinessLogic.BindingModels;

namespace SecuritySystemView
{
    public partial class FormMain : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly ReportLogic report;
        private readonly WorkModeling modeling;
        private readonly BackUpAbstractLogic backUpAbstractLogic;
        public FormMain(MainLogic logic, IOrderLogic orderLogic, ReportLogic report, WorkModeling modeling, BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.report = report;
            this.modeling = modeling;
            this.backUpAbstractLogic = backUpAbstractLogic;
            LoadData();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(orderLogic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void компонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDevices>();
            form.ShowDialog();
        }

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSystems>();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    report.SaveEquipmentsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ComponentProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportDeviceEquipment>();
            form.ShowDialog();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportEquipmentDevices>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }
        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modeling.DoWork();
        }

        private void сообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMessages>();
            form.ShowDialog();
        }

        private void создатьBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
