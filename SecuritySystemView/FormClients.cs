﻿using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.Interfaces;
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
    public partial class FormClients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IClientLogic logic;

        public FormClients(IClientLogic clientLogic)
        {
            InitializeComponent();
            this.logic = clientLogic;
            LoadData();
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var clients = logic.Read(null);
                if (clients != null)
                {
                    dataGridViewClients.DataSource = clients;
                    dataGridViewClients.Columns[0].Visible = false;
                    dataGridViewClients.Columns[2].Visible = false;
                    dataGridViewClients.Columns[3].Visible = false;
                    dataGridViewClients.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                logic.Delete(new ClientBindingModel()
                {
                    Id = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value)
                });
                LoadData();
            }
        }
    }
}
