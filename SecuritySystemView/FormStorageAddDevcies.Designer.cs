namespace SecuritySystemView
{
    partial class FormStorageAddDevcies
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
            this.labelStorage = new System.Windows.Forms.Label();
            this.labelDevice = new System.Windows.Forms.Label();
            this.labelKol = new System.Windows.Forms.Label();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.textBoxKol = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(12, 9);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(48, 17);
            this.labelStorage.TabIndex = 0;
            this.labelStorage.Text = "Склад";
            // 
            // labelDevice
            // 
            this.labelDevice.AutoSize = true;
            this.labelDevice.Location = new System.Drawing.Point(12, 45);
            this.labelDevice.Name = "labelDevice";
            this.labelDevice.Size = new System.Drawing.Size(86, 17);
            this.labelDevice.TabIndex = 1;
            this.labelDevice.Text = "Устройство";
            // 
            // labelKol
            // 
            this.labelKol.AutoSize = true;
            this.labelKol.Location = new System.Drawing.Point(12, 85);
            this.labelKol.Name = "labelKol";
            this.labelKol.Size = new System.Drawing.Size(86, 17);
            this.labelKol.TabIndex = 2;
            this.labelKol.Text = "Количество";
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(108, 9);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(279, 24);
            this.comboBoxStorage.TabIndex = 3;
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(108, 45);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(279, 24);
            this.comboBoxDevice.TabIndex = 4;
            // 
            // textBoxKol
            // 
            this.textBoxKol.Location = new System.Drawing.Point(108, 82);
            this.textBoxKol.Name = "textBoxKol";
            this.textBoxKol.Size = new System.Drawing.Size(279, 22);
            this.textBoxKol.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(157, 110);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(118, 32);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(281, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 32);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormStorageAddDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 150);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxKol);
            this.Controls.Add(this.comboBoxDevice);
            this.Controls.Add(this.comboBoxStorage);
            this.Controls.Add(this.labelKol);
            this.Controls.Add(this.labelDevice);
            this.Controls.Add(this.labelStorage);
            this.Name = "FormStorageAddDevices";
            this.Text = "Добавление Устройств";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.Label labelDevice;
        private System.Windows.Forms.Label labelKol;
        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.TextBox textBoxKol;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}