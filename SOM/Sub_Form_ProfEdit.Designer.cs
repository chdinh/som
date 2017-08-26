namespace SOM
{
    partial class Sub_Form_ProfEdit
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_tables = new System.Windows.Forms.ListBox();
            this.DataGrid_main = new System.Windows.Forms.DataGrid();
            this.but_save = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_tables
            // 
            this.listBox_tables.FormattingEnabled = true;
            this.listBox_tables.Location = new System.Drawing.Point(6, 19);
            this.listBox_tables.Name = "listBox_tables";
            this.listBox_tables.Size = new System.Drawing.Size(170, 134);
            this.listBox_tables.TabIndex = 5;
            this.listBox_tables.SelectedIndexChanged += new System.EventHandler(this.listBox_tables_SelectedIndexChanged);
            // 
            // DataGrid_main
            // 
            this.DataGrid_main.DataMember = "";
            this.DataGrid_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGrid_main.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid_main.Location = new System.Drawing.Point(203, 12);
            this.DataGrid_main.Name = "DataGrid_main";
            this.DataGrid_main.Size = new System.Drawing.Size(565, 380);
            this.DataGrid_main.TabIndex = 6;
            // 
            // but_save
            // 
            this.but_save.Location = new System.Drawing.Point(46, 336);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(116, 25);
            this.but_save.TabIndex = 7;
            this.but_save.Text = "speichern";
            this.but_save.UseVisualStyleBackColor = true;
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Location = new System.Drawing.Point(46, 367);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(116, 25);
            this.but_cancel.TabIndex = 8;
            this.but_cancel.Text = "abbrechen";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_tables);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 165);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabellen";
            // 
            // Sub_Form_ProfEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 404);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.DataGrid_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Sub_Form_ProfEdit";
            this.Text = "Prof.-Editor";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_tables;
        private System.Windows.Forms.DataGrid DataGrid_main;
        private System.Windows.Forms.Button but_save;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}