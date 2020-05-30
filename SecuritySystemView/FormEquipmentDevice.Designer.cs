namespace SecuritySystemView
{
    partial class FormEquipmentDevice
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
            this.labelComponentName = new System.Windows.Forms.Label();
            this.labelCountComponent = new System.Windows.Forms.Label();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.textBoxCountComponent = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelComponentName
            // 
            this.labelComponentName.AutoSize = true;
            this.labelComponentName.Location = new System.Drawing.Point(13, 18);
            this.labelComponentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComponentName.Name = "labelComponentName";
            this.labelComponentName.Size = new System.Drawing.Size(84, 17);
            this.labelComponentName.TabIndex = 0;
            this.labelComponentName.Text = "Устройство";
            // 
            // labelCountComponent
            // 
            this.labelCountComponent.AutoSize = true;
            this.labelCountComponent.Location = new System.Drawing.Point(13, 63);
            this.labelCountComponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCountComponent.Name = "labelCountComponent";
            this.labelCountComponent.Size = new System.Drawing.Size(86, 17);
            this.labelCountComponent.TabIndex = 1;
            this.labelCountComponent.Text = "Количество";
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(109, 15);
            this.comboBoxComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(255, 24);
            this.comboBoxComponent.TabIndex = 2;
            // 
            // textBoxCountComponent
            // 
            this.textBoxCountComponent.Location = new System.Drawing.Point(109, 59);
            this.textBoxCountComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCountComponent.Name = "textBoxCountComponent";
            this.textBoxCountComponent.Size = new System.Drawing.Size(255, 22);
            this.textBoxCountComponent.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(148, 91);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 34);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(269, 91);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(96, 34);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormEquipmentDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 139);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCountComponent);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.labelCountComponent);
            this.Controls.Add(this.labelComponentName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormEquipmentDevice";
            this.Text = "Устрйство комплектации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComponentName;
        private System.Windows.Forms.Label labelCountComponent;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.TextBox textBoxCountComponent;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}