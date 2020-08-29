namespace SecuritySystemView
{
    partial class FormImplementer
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.textBoxWorkTime = new System.Windows.Forms.TextBox();
            this.labelWorkTime = new System.Windows.Forms.Label();
            this.textBoxImplementerFIO = new System.Windows.Forms.TextBox();
            this.labelImplementerFIO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(113, 101);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(222, 101);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(100, 28);
            this.buttonAccept.TabIndex = 14;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(149, 69);
            this.textBoxDelay.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(171, 22);
            this.textBoxDelay.TabIndex = 13;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(36, 73);
            this.labelDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(101, 17);
            this.labelDelay.TabIndex = 12;
            this.labelDelay.Text = "Время отдыха";
            // 
            // textBoxWorkTime
            // 
            this.textBoxWorkTime.Location = new System.Drawing.Point(149, 37);
            this.textBoxWorkTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWorkTime.Name = "textBoxWorkTime";
            this.textBoxWorkTime.Size = new System.Drawing.Size(171, 22);
            this.textBoxWorkTime.TabIndex = 11;
            // 
            // labelWorkTime
            // 
            this.labelWorkTime.AutoSize = true;
            this.labelWorkTime.Location = new System.Drawing.Point(5, 41);
            this.labelWorkTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWorkTime.Name = "labelWorkTime";
            this.labelWorkTime.Size = new System.Drawing.Size(135, 17);
            this.labelWorkTime.TabIndex = 10;
            this.labelWorkTime.Text = "Время выполнения";
            // 
            // textBoxImplementerFIO
            // 
            this.textBoxImplementerFIO.Location = new System.Drawing.Point(149, 5);
            this.textBoxImplementerFIO.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxImplementerFIO.Name = "textBoxImplementerFIO";
            this.textBoxImplementerFIO.Size = new System.Drawing.Size(171, 22);
            this.textBoxImplementerFIO.TabIndex = 9;
            // 
            // labelImplementerFIO
            // 
            this.labelImplementerFIO.AutoSize = true;
            this.labelImplementerFIO.Location = new System.Drawing.Point(69, 9);
            this.labelImplementerFIO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelImplementerFIO.Name = "labelImplementerFIO";
            this.labelImplementerFIO.Size = new System.Drawing.Size(42, 17);
            this.labelImplementerFIO.TabIndex = 8;
            this.labelImplementerFIO.Text = "ФИО";
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 135);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxDelay);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.textBoxWorkTime);
            this.Controls.Add(this.labelWorkTime);
            this.Controls.Add(this.textBoxImplementerFIO);
            this.Controls.Add(this.labelImplementerFIO);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.TextBox textBoxWorkTime;
        private System.Windows.Forms.Label labelWorkTime;
        private System.Windows.Forms.TextBox textBoxImplementerFIO;
        private System.Windows.Forms.Label labelImplementerFIO;
    }
}