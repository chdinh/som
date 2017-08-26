namespace SOM
{
    partial class Form_MainAp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainAp));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fensterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.enginetestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.merkmalsklassifizierungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelingSalesmanProbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_search = new System.Windows.Forms.TreeView();
            this.groupBox_search = new System.Windows.Forms.GroupBox();
            this.textBox_ergCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_komp = new System.Windows.Forms.Label();
            this.textBox_compEdit = new System.Windows.Forms.TextBox();
            this.but_search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_searchResult = new System.Windows.Forms.ListView();
            this.columnMatch = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.toolTip_Prof = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Search = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip_main.SuspendLayout();
            this.groupBox_search.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeToolStripMenuItem,
            this.fensterToolStripMenuItem,
            this.hilfeToolStripMenuItem1});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(557, 24);
            this.menuStrip_main.TabIndex = 0;
            this.menuStrip_main.Text = "menuStrip_main";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ladenToolStripMenuItem,
            this.speichernToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.hilfeToolStripMenuItem.Text = "Datei";
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ladenToolStripMenuItem.Text = "laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.speichernToolStripMenuItem.Text = "speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // fensterToolStripMenuItem
            // 
            this.fensterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profEditorToolStripMenuItem,
            this.trainNetworkToolStripMenuItem,
            this.toolStripSeparator2,
            this.enginetestsToolStripMenuItem});
            this.fensterToolStripMenuItem.Name = "fensterToolStripMenuItem";
            this.fensterToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.fensterToolStripMenuItem.Text = "Fenster";
            // 
            // profEditorToolStripMenuItem
            // 
            this.profEditorToolStripMenuItem.Name = "profEditorToolStripMenuItem";
            this.profEditorToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.profEditorToolStripMenuItem.Text = "Prof.-Editor";
            this.profEditorToolStripMenuItem.Click += new System.EventHandler(this.profEditorToolStripMenuItem_Click);
            // 
            // trainNetworkToolStripMenuItem
            // 
            this.trainNetworkToolStripMenuItem.Name = "trainNetworkToolStripMenuItem";
            this.trainNetworkToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.trainNetworkToolStripMenuItem.Text = "train Network";
            this.trainNetworkToolStripMenuItem.Click += new System.EventHandler(this.trainNetworkToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // enginetestsToolStripMenuItem
            // 
            this.enginetestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.merkmalsklassifizierungToolStripMenuItem,
            this.travelingSalesmanProbToolStripMenuItem});
            this.enginetestsToolStripMenuItem.Name = "enginetestsToolStripMenuItem";
            this.enginetestsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.enginetestsToolStripMenuItem.Text = "Enginetests";
            // 
            // merkmalsklassifizierungToolStripMenuItem
            // 
            this.merkmalsklassifizierungToolStripMenuItem.Name = "merkmalsklassifizierungToolStripMenuItem";
            this.merkmalsklassifizierungToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.merkmalsklassifizierungToolStripMenuItem.Text = "Merkmalsklassifizierung";
            this.merkmalsklassifizierungToolStripMenuItem.Click += new System.EventHandler(this.merkmalsklassifizierungToolStripMenuItem_Click);
            // 
            // travelingSalesmanProbToolStripMenuItem
            // 
            this.travelingSalesmanProbToolStripMenuItem.Name = "travelingSalesmanProbToolStripMenuItem";
            this.travelingSalesmanProbToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.travelingSalesmanProbToolStripMenuItem.Text = "Traveling-Salesman-P";
            this.travelingSalesmanProbToolStripMenuItem.Click += new System.EventHandler(this.travelingSalesmanProbToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem1
            // 
            this.hilfeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fAQToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.hilfeToolStripMenuItem1.Name = "hilfeToolStripMenuItem1";
            this.hilfeToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem1.Text = "Hilfe";
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.fAQToolStripMenuItem.Text = "FAQ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // treeView_search
            // 
            this.treeView_search.Location = new System.Drawing.Point(6, 19);
            this.treeView_search.Name = "treeView_search";
            this.treeView_search.Size = new System.Drawing.Size(250, 280);
            this.treeView_search.TabIndex = 1;
            this.treeView_search.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_search_NodeMouseClick);
            // 
            // groupBox_search
            // 
            this.groupBox_search.Controls.Add(this.textBox_ergCount);
            this.groupBox_search.Controls.Add(this.label1);
            this.groupBox_search.Controls.Add(this.label_komp);
            this.groupBox_search.Controls.Add(this.textBox_compEdit);
            this.groupBox_search.Controls.Add(this.but_search);
            this.groupBox_search.Controls.Add(this.treeView_search);
            this.groupBox_search.Location = new System.Drawing.Point(12, 27);
            this.groupBox_search.Name = "groupBox_search";
            this.groupBox_search.Size = new System.Drawing.Size(263, 375);
            this.groupBox_search.TabIndex = 2;
            this.groupBox_search.TabStop = false;
            this.groupBox_search.Text = "Prof. Search";
            // 
            // textBox_ergCount
            // 
            this.textBox_ergCount.Location = new System.Drawing.Point(6, 347);
            this.textBox_ergCount.Name = "textBox_ergCount";
            this.textBox_ergCount.Size = new System.Drawing.Size(79, 20);
            this.textBox_ergCount.TabIndex = 4;
            this.textBox_ergCount.Text = "3";
            this.textBox_ergCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_compEdit_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ergebnisanzahl:";
            // 
            // label_komp
            // 
            this.label_komp.AutoSize = true;
            this.label_komp.Location = new System.Drawing.Point(6, 308);
            this.label_komp.Name = "label_komp";
            this.label_komp.Size = new System.Drawing.Size(63, 13);
            this.label_komp.TabIndex = 4;
            this.label_komp.Text = "Kompetenz:";
            // 
            // textBox_compEdit
            // 
            this.textBox_compEdit.Location = new System.Drawing.Point(75, 305);
            this.textBox_compEdit.Name = "textBox_compEdit";
            this.textBox_compEdit.Size = new System.Drawing.Size(181, 20);
            this.textBox_compEdit.TabIndex = 3;
            this.textBox_compEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_compEdit_KeyUp);
            this.textBox_compEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_compEdit_KeyPress);
            this.textBox_compEdit.MouseHover += new System.EventHandler(this.treeView_search_MouseHover);
            // 
            // but_search
            // 
            this.but_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_search.Location = new System.Drawing.Point(91, 331);
            this.but_search.Name = "but_search";
            this.but_search.Size = new System.Drawing.Size(165, 38);
            this.but_search.TabIndex = 2;
            this.but_search.Text = "Search";
            this.but_search.UseVisualStyleBackColor = true;
            this.but_search.Click += new System.EventHandler(this.but_search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView_searchResult);
            this.groupBox1.Location = new System.Drawing.Point(281, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 374);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suchergebnis";
            // 
            // listView_searchResult
            // 
            this.listView_searchResult.BackColor = System.Drawing.SystemColors.Window;
            this.listView_searchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnMatch,
            this.columnName});
            this.listView_searchResult.Location = new System.Drawing.Point(6, 19);
            this.listView_searchResult.Name = "listView_searchResult";
            this.listView_searchResult.Size = new System.Drawing.Size(250, 348);
            this.listView_searchResult.TabIndex = 0;
            this.listView_searchResult.UseCompatibleStateImageBehavior = false;
            this.listView_searchResult.View = System.Windows.Forms.View.Details;
            this.listView_searchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_searchResult_MouseDoubleClick);
            this.listView_searchResult.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView_searchResult_ItemMouseHover);
            // 
            // columnMatch
            // 
            this.columnMatch.Text = "Matching";
            this.columnMatch.Width = 58;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 190;
            // 
            // toolTip_Prof
            // 
            this.toolTip_Prof.AutomaticDelay = 100;
            // 
            // toolTip_Search
            // 
            this.toolTip_Search.AutomaticDelay = 100;
            this.toolTip_Search.AutoPopDelay = 50000;
            this.toolTip_Search.InitialDelay = 100;
            this.toolTip_Search.ReshowDelay = 20;
            // 
            // Form_MainAp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 414);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_search);
            this.Controls.Add(this.menuStrip_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "Form_MainAp";
            this.Text = "Prof. Search";
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.groupBox_search.ResumeLayout(false);
            this.groupBox_search.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fensterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enginetestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem merkmalsklassifizierungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelingSalesmanProbToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView_search;
        private System.Windows.Forms.ToolStripMenuItem profEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_search;
        private System.Windows.Forms.TextBox textBox_compEdit;
        private System.Windows.Forms.Button but_search;
        private System.Windows.Forms.Label label_komp;
        private System.Windows.Forms.ToolStripMenuItem trainNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_ergCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_searchResult;
        private System.Windows.Forms.ColumnHeader columnMatch;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ToolTip toolTip_Prof;
        private System.Windows.Forms.ToolTip toolTip_Search;
    }
}

