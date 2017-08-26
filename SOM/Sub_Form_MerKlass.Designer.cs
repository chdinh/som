namespace SOM
{
    partial class Sub_Form_MerKlass
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
            this.pictureBox_Anzeige = new System.Windows.Forms.PictureBox();
            this.dataGridView_myAnimals = new System.Windows.Forms.DataGridView();
            this.but_train = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Cycles = new System.Windows.Forms.TextBox();
            this.but_addSpezies = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Anzeige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_myAnimals)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Anzeige
            // 
            this.pictureBox_Anzeige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Anzeige.Location = new System.Drawing.Point(12, 252);
            this.pictureBox_Anzeige.Name = "pictureBox_Anzeige";
            this.pictureBox_Anzeige.Size = new System.Drawing.Size(560, 240);
            this.pictureBox_Anzeige.TabIndex = 0;
            this.pictureBox_Anzeige.TabStop = false;
            this.pictureBox_Anzeige.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Anzeige_Paint);
            // 
            // dataGridView_myAnimals
            // 
            this.dataGridView_myAnimals.AllowUserToAddRows = false;
            this.dataGridView_myAnimals.AllowUserToDeleteRows = false;
            this.dataGridView_myAnimals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_myAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_myAnimals.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_myAnimals.Name = "dataGridView_myAnimals";
            this.dataGridView_myAnimals.Size = new System.Drawing.Size(560, 203);
            this.dataGridView_myAnimals.TabIndex = 1;
            this.dataGridView_myAnimals.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_myAnimals_CellValueChanged);
            // 
            // but_train
            // 
            this.but_train.Location = new System.Drawing.Point(12, 221);
            this.but_train.Name = "but_train";
            this.but_train.Size = new System.Drawing.Size(80, 25);
            this.but_train.TabIndex = 2;
            this.but_train.Text = "Train";
            this.but_train.UseVisualStyleBackColor = true;
            this.but_train.Click += new System.EventHandler(this.but_train_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zyklen:";
            // 
            // textBox_Cycles
            // 
            this.textBox_Cycles.Location = new System.Drawing.Point(146, 224);
            this.textBox_Cycles.Name = "textBox_Cycles";
            this.textBox_Cycles.Size = new System.Drawing.Size(69, 20);
            this.textBox_Cycles.TabIndex = 4;
            this.textBox_Cycles.Text = "10";
            this.textBox_Cycles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Cycles_KeyPress);
            // 
            // but_addSpezies
            // 
            this.but_addSpezies.Location = new System.Drawing.Point(493, 221);
            this.but_addSpezies.Name = "but_addSpezies";
            this.but_addSpezies.Size = new System.Drawing.Size(80, 25);
            this.but_addSpezies.TabIndex = 5;
            this.but_addSpezies.Text = "Add Spezies";
            this.but_addSpezies.UseVisualStyleBackColor = true;
            this.but_addSpezies.Click += new System.EventHandler(this.but_addSpezies_Click);
            // 
            // Sub_Form_MerKlass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 504);
            this.Controls.Add(this.but_addSpezies);
            this.Controls.Add(this.textBox_Cycles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_train);
            this.Controls.Add(this.dataGridView_myAnimals);
            this.Controls.Add(this.pictureBox_Anzeige);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Sub_Form_MerKlass";
            this.Text = "Sub_Form_MerKlass";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Anzeige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_myAnimals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Anzeige;
        private System.Windows.Forms.DataGridView dataGridView_myAnimals;
        private System.Windows.Forms.Button but_train;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Cycles;
        private System.Windows.Forms.Button but_addSpezies;
    }
}