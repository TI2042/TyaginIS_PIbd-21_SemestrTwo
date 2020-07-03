namespace SecuritySystemView
{
    partial class FormCreateOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelEquip = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.labelEquip.AutoSize = true;
            this.labelEquip.Location = new System.Drawing.Point(16, 57);
            this.labelEquip.Name = "label1";
            this.labelEquip.Size = new System.Drawing.Size(65, 17);
            this.labelEquip.TabIndex = 0;
            this.labelEquip.Text = "Изделие";
            // 
            // label2
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(16, 92);
            this.labelCount.Name = "label2";
            this.labelCount.Size = new System.Drawing.Size(86, 17);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество";
            // 
            // label3
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(16, 132);
            this.labelSum.Name = "label3";
            this.labelSum.Size = new System.Drawing.Size(50, 17);
            this.labelSum.TabIndex = 2;
            this.labelSum.Text = "Сумма";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(104, 92);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(227, 22);
            this.textBoxCount.TabIndex = 3;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(104, 127);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(227, 22);
            this.textBoxSum.TabIndex = 4;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(104, 54);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(227, 24);
            this.comboBoxProduct.TabIndex = 5;
            this.comboBoxProduct.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
            this.comboBoxProduct.Click += new System.EventHandler(this.FormCreateOrder_Load);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(93, 175);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(116, 28);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(215, 175);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(116, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(104, 24);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(227, 24);
            this.comboBoxClients.TabIndex = 8;
            // 
            // label4
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(16, 27);
            this.labelClient.Name = "label4";
            this.labelClient.Size = new System.Drawing.Size(56, 17);
            this.labelClient.TabIndex = 9;
            this.labelClient.Text = "Клиент";
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 230);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.comboBoxClients);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxProduct);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelEquip);
            this.Name = "FormCreateOrder";
            this.Text = "Создание заказа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEquip;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.Label labelClient;
    }
}
