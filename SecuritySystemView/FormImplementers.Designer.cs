namespace SecuritySystemView
{
    partial class FormImplementers
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
            this.buttonDeleteImplementer = new System.Windows.Forms.Button();
            this.buttonUpdateImplementer = new System.Windows.Forms.Button();
            this.buttonAddImplementer = new System.Windows.Forms.Button();
            this.dataGridViewImplementers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImplementers)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeleteImplementer
            // 
            this.buttonDeleteImplementer.Location = new System.Drawing.Point(448, 101);
            this.buttonDeleteImplementer.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteImplementer.Name = "buttonDeleteImplementer";
            this.buttonDeleteImplementer.Size = new System.Drawing.Size(117, 28);
            this.buttonDeleteImplementer.TabIndex = 7;
            this.buttonDeleteImplementer.Text = "Удалить";
            this.buttonDeleteImplementer.UseVisualStyleBackColor = true;
            this.buttonDeleteImplementer.Click += new System.EventHandler(this.buttonDeleteImplementer_Click);
            // 
            // buttonUpdateImplementer
            // 
            this.buttonUpdateImplementer.Location = new System.Drawing.Point(448, 61);
            this.buttonUpdateImplementer.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdateImplementer.Name = "buttonUpdateImplementer";
            this.buttonUpdateImplementer.Size = new System.Drawing.Size(117, 32);
            this.buttonUpdateImplementer.TabIndex = 6;
            this.buttonUpdateImplementer.Text = "Изменить";
            this.buttonUpdateImplementer.UseVisualStyleBackColor = true;
            this.buttonUpdateImplementer.Click += new System.EventHandler(this.buttonUpdateImplementer_Click);
            // 
            // buttonAddImplementer
            // 
            this.buttonAddImplementer.Location = new System.Drawing.Point(448, 25);
            this.buttonAddImplementer.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddImplementer.Name = "buttonAddImplementer";
            this.buttonAddImplementer.Size = new System.Drawing.Size(117, 30);
            this.buttonAddImplementer.TabIndex = 5;
            this.buttonAddImplementer.Text = "Добавить";
            this.buttonAddImplementer.UseVisualStyleBackColor = true;
            this.buttonAddImplementer.Click += new System.EventHandler(this.buttonAddImplementer_Click);
            // 
            // dataGridViewImplementers
            // 
            this.dataGridViewImplementers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImplementers.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewImplementers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewImplementers.Name = "dataGridViewImplementers";
            this.dataGridViewImplementers.RowHeadersWidth = 51;
            this.dataGridViewImplementers.Size = new System.Drawing.Size(420, 342);
            this.dataGridViewImplementers.TabIndex = 4;
            // 
            // FormImplementers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 371);
            this.Controls.Add(this.buttonDeleteImplementer);
            this.Controls.Add(this.buttonUpdateImplementer);
            this.Controls.Add(this.buttonAddImplementer);
            this.Controls.Add(this.dataGridViewImplementers);
            this.Name = "FormImplementers";
            this.Text = "Исполнители";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImplementers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteImplementer;
        private System.Windows.Forms.Button buttonUpdateImplementer;
        private System.Windows.Forms.Button buttonAddImplementer;
        private System.Windows.Forms.DataGridView dataGridViewImplementers;
    }
}