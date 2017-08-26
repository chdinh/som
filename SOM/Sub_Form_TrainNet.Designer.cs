namespace SOM
{
    partial class Sub_Form_TrainNet
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
            this.but_train = new System.Windows.Forms.Button();
            this.but_create = new System.Windows.Forms.Button();
            this.label_NproDim = new System.Windows.Forms.Label();
            this.label_cycles = new System.Windows.Forms.Label();
            this.textBox_Epoch = new System.Windows.Forms.TextBox();
            this.textBox_NCount = new System.Windows.Forms.TextBox();
            this.label_dim = new System.Windows.Forms.Label();
            this.textBox_dim = new System.Windows.Forms.TextBox();
            this.progressBar_train = new System.Windows.Forms.ProgressBar();
            this.label_num = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_train
            // 
            this.but_train.Location = new System.Drawing.Point(225, 61);
            this.but_train.Name = "but_train";
            this.but_train.Size = new System.Drawing.Size(90, 25);
            this.but_train.TabIndex = 0;
            this.but_train.Text = "Train Network";
            this.but_train.UseVisualStyleBackColor = true;
            this.but_train.Click += new System.EventHandler(this.but_train_Click);
            // 
            // but_create
            // 
            this.but_create.Location = new System.Drawing.Point(225, 35);
            this.but_create.Name = "but_create";
            this.but_create.Size = new System.Drawing.Size(90, 25);
            this.but_create.TabIndex = 1;
            this.but_create.Text = "Create Network";
            this.but_create.UseVisualStyleBackColor = true;
            this.but_create.Click += new System.EventHandler(this.but_create_Click);
            // 
            // label_NproDim
            // 
            this.label_NproDim.AutoSize = true;
            this.label_NproDim.Location = new System.Drawing.Point(28, 41);
            this.label_NproDim.Name = "label_NproDim";
            this.label_NproDim.Size = new System.Drawing.Size(111, 13);
            this.label_NproDim.TabIndex = 2;
            this.label_NproDim.Text = "Neuronen/Dimension:";
            // 
            // label_cycles
            // 
            this.label_cycles.AutoSize = true;
            this.label_cycles.Location = new System.Drawing.Point(86, 67);
            this.label_cycles.Name = "label_cycles";
            this.label_cycles.Size = new System.Drawing.Size(53, 13);
            this.label_cycles.TabIndex = 3;
            this.label_cycles.Text = "Epochen:";
            // 
            // textBox_Epoch
            // 
            this.textBox_Epoch.Location = new System.Drawing.Point(140, 64);
            this.textBox_Epoch.Name = "textBox_Epoch";
            this.textBox_Epoch.Size = new System.Drawing.Size(79, 20);
            this.textBox_Epoch.TabIndex = 4;
            this.textBox_Epoch.Text = "100";
            this.textBox_Epoch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NumCheck_KeyPress);
            // 
            // textBox_NCount
            // 
            this.textBox_NCount.Location = new System.Drawing.Point(140, 38);
            this.textBox_NCount.Name = "textBox_NCount";
            this.textBox_NCount.Size = new System.Drawing.Size(79, 20);
            this.textBox_NCount.TabIndex = 5;
            this.textBox_NCount.Text = "3";
            this.textBox_NCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NumCheck_KeyPress);
            this.textBox_NCount.TextChanged += new System.EventHandler(this.textBox_NCount_TextChanged);
            // 
            // label_dim
            // 
            this.label_dim.AutoSize = true;
            this.label_dim.Location = new System.Drawing.Point(12, 15);
            this.label_dim.Name = "label_dim";
            this.label_dim.Size = new System.Drawing.Size(127, 13);
            this.label_dim.TabIndex = 6;
            this.label_dim.Text = "Dimensionen des Netzes:";
            // 
            // textBox_dim
            // 
            this.textBox_dim.Location = new System.Drawing.Point(140, 12);
            this.textBox_dim.Name = "textBox_dim";
            this.textBox_dim.ReadOnly = true;
            this.textBox_dim.Size = new System.Drawing.Size(79, 20);
            this.textBox_dim.TabIndex = 7;
            // 
            // progressBar_train
            // 
            this.progressBar_train.Location = new System.Drawing.Point(12, 90);
            this.progressBar_train.Name = "progressBar_train";
            this.progressBar_train.Size = new System.Drawing.Size(303, 10);
            this.progressBar_train.TabIndex = 8;
            // 
            // label_num
            // 
            this.label_num.AutoSize = true;
            this.label_num.Location = new System.Drawing.Point(225, 15);
            this.label_num.Name = "label_num";
            this.label_num.Size = new System.Drawing.Size(75, 13);
            this.label_num.TabIndex = 9;
            this.label_num.Text = "729 Neuronen";
            // 
            // Sub_Form_TrainNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 105);
            this.Controls.Add(this.label_num);
            this.Controls.Add(this.progressBar_train);
            this.Controls.Add(this.textBox_dim);
            this.Controls.Add(this.label_dim);
            this.Controls.Add(this.textBox_NCount);
            this.Controls.Add(this.textBox_Epoch);
            this.Controls.Add(this.label_cycles);
            this.Controls.Add(this.label_NproDim);
            this.Controls.Add(this.but_create);
            this.Controls.Add(this.but_train);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Sub_Form_TrainNet";
            this.Text = "Train Network";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_train;
        private System.Windows.Forms.Button but_create;
        private System.Windows.Forms.Label label_NproDim;
        private System.Windows.Forms.Label label_cycles;
        private System.Windows.Forms.TextBox textBox_Epoch;
        private System.Windows.Forms.TextBox textBox_NCount;
        private System.Windows.Forms.Label label_dim;
        private System.Windows.Forms.TextBox textBox_dim;
        private System.Windows.Forms.ProgressBar progressBar_train;
        private System.Windows.Forms.Label label_num;
    }
}