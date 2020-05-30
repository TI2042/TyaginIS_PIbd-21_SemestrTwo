namespace SecuritySystemView
{
    partial class FormReportDeviceEquipment
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
            this.components = new System.ComponentModel.Container();
            this.ReportDeviceEquipmentViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDeviceEquipmentViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SecuritySystemView.ReportOrder.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 64);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(792, 374);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сформировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(402, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "В PDF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // FormReportDeviceEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReportDeviceEquipment";
            this.Text = "FormReportDeviceEquipment";
            this.Load += new System.EventHandler(this.FormReportDeviceEquipment_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDeviceEquipmentViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource ReportDeviceEquipmentViewModelBindingSource;
    }
}