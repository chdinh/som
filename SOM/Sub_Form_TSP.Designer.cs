namespace SOM
{
    partial class Sub_Form_TSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sub_Form_TSP));
            this.pictureBox_Anzeige = new System.Windows.Forms.PictureBox();
            this.but_train = new System.Windows.Forms.Button();
            this.but_create = new System.Windows.Forms.Button();
            this.textBox_Cycles = new System.Windows.Forms.TextBox();
            this.textBox_Neurons = new System.Windows.Forms.TextBox();
            this.label_Zyklen = new System.Windows.Forms.Label();
            this.label_neurons = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Anzeige)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Anzeige
            // 
            this.pictureBox_Anzeige.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Anzeige.BackgroundImage")));
            this.pictureBox_Anzeige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Anzeige.Location = new System.Drawing.Point(12, 43);
            this.pictureBox_Anzeige.Name = "pictureBox_Anzeige";
            this.pictureBox_Anzeige.Size = new System.Drawing.Size(520, 660);
            this.pictureBox_Anzeige.TabIndex = 0;
            this.pictureBox_Anzeige.TabStop = false;
            this.pictureBox_Anzeige.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Anzeige_Paint);
            this.pictureBox_Anzeige.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Anzeige_MouseClick);
            // 
            // but_train
            // 
            this.but_train.Location = new System.Drawing.Point(12, 12);
            this.but_train.Name = "but_train";
            this.but_train.Size = new System.Drawing.Size(80, 25);
            this.but_train.TabIndex = 1;
            this.but_train.Text = "Train";
            this.but_train.UseVisualStyleBackColor = true;
            this.but_train.Click += new System.EventHandler(this.but_train_Click);
            // 
            // but_create
            // 
            this.but_create.Location = new System.Drawing.Point(303, 12);
            this.but_create.Name = "but_create";
            this.but_create.Size = new System.Drawing.Size(80, 25);
            this.but_create.TabIndex = 2;
            this.but_create.Text = "Create";
            this.but_create.UseVisualStyleBackColor = true;
            this.but_create.Click += new System.EventHandler(this.but_create_Click);
            // 
            // textBox_Cycles
            // 
            this.textBox_Cycles.Location = new System.Drawing.Point(146, 15);
            this.textBox_Cycles.Name = "textBox_Cycles";
            this.textBox_Cycles.Size = new System.Drawing.Size(80, 20);
            this.textBox_Cycles.TabIndex = 3;
            this.textBox_Cycles.Text = "14";
            this.textBox_Cycles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TestInput_KeyPress);
            // 
            // textBox_Neurons
            // 
            this.textBox_Neurons.Location = new System.Drawing.Point(452, 15);
            this.textBox_Neurons.Name = "textBox_Neurons";
            this.textBox_Neurons.Size = new System.Drawing.Size(80, 20);
            this.textBox_Neurons.TabIndex = 4;
            this.textBox_Neurons.Text = "20";
            this.textBox_Neurons.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TestInput_KeyPress);
            // 
            // label_Zyklen
            // 
            this.label_Zyklen.AutoSize = true;
            this.label_Zyklen.Location = new System.Drawing.Point(98, 19);
            this.label_Zyklen.Name = "label_Zyklen";
            this.label_Zyklen.Size = new System.Drawing.Size(42, 13);
            this.label_Zyklen.TabIndex = 5;
            this.label_Zyklen.Text = "Zyklen:";
            // 
            // label_neurons
            // 
            this.label_neurons.AutoSize = true;
            this.label_neurons.Location = new System.Drawing.Point(389, 18);
            this.label_neurons.Name = "label_neurons";
            this.label_neurons.Size = new System.Drawing.Size(57, 13);
            this.label_neurons.TabIndex = 6;
            this.label_neurons.Text = "Neuronen:";
            // 
            // Sub_Form_TSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 714);
            this.Controls.Add(this.label_neurons);
            this.Controls.Add(this.label_Zyklen);
            this.Controls.Add(this.textBox_Neurons);
            this.Controls.Add(this.textBox_Cycles);
            this.Controls.Add(this.but_create);
            this.Controls.Add(this.but_train);
            this.Controls.Add(this.pictureBox_Anzeige);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Sub_Form_TSP";
            this.Text = "Traveling Salesman Problem";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Anzeige)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Anzeige;
        private System.Windows.Forms.Button but_train;
        private System.Windows.Forms.Button but_create;
        private System.Windows.Forms.TextBox textBox_Cycles;
        private System.Windows.Forms.TextBox textBox_Neurons;
        private System.Windows.Forms.Label label_Zyklen;
        private System.Windows.Forms.Label label_neurons;
    }
}