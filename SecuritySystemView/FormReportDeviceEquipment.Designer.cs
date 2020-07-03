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
            this.buttonForm = new System.Windows.Forms.Button();
            this.buttonPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDeviceEquipmentViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SecuritySystemView.ReportOrder.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 52);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(594, 304);
            this.reportViewer1.TabIndex = 0;
            // 
            // buttonForm
            // 
            this.buttonForm.Location = new System.Drawing.Point(95, 15);
            this.buttonForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonForm.Name = "buttonForm";
            this.buttonForm.Size = new System.Drawing.Size(116, 22);
            this.buttonForm.TabIndex = 1;
            this.buttonForm.Text = "Сформировать";
            this.buttonForm.UseVisualStyleBackColor = true;
            this.buttonForm.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // buttonPDF
            // 
            this.buttonPDF.Location = new System.Drawing.Point(302, 14);
            this.buttonPDF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(150, 22);
            this.buttonPDF.TabIndex = 2;
            this.buttonPDF.Text = "В PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // FormReportDeviceEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.buttonForm);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormReportDeviceEquipment";
            this.Text = "Отчет PDF";
            this.Load += new System.EventHandler(this.FormReportDeviceEquipment_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDeviceEquipmentViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buttonForm;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.BindingSource ReportDeviceEquipmentViewModelBindingSource;
    }
}