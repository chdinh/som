using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using nn_math;
using nn_som;

namespace SOM
{
    public partial class Sub_Form_ProfEdit : Form
    {
        private DataSet myProfSetToEdit;
        private DataTable myMainTable;

        private BindingSource myBindingSource;

        private string myFile;

        public Sub_Form_ProfEdit(DataSet myProfSet, string targetFile)
        {
            InitializeComponent();

            myFile = targetFile;

            myProfSetToEdit = myProfSet;
            //Status merken
            myProfSetToEdit.AcceptChanges();
            myBindingSource = new BindingSource(myProfSetToEdit, "Prof");

            DataGrid_main.DataSource = myBindingSource;

            DataGrid_main.CaptionText = "Table: " + myBindingSource.DataMember;

            foreach (DataTable dt in myProfSetToEdit.Tables)
            {
                this.listBox_tables.Items.Add(dt.TableName);
            }
            myMainTable = myProfSetToEdit.Tables["Prof"];
            myMainTable.TableNewRow += new DataTableNewRowEventHandler(Sub_Form_ProfEdit_TableNewRow);
            myMainTable.ColumnChanged += new DataColumnChangeEventHandler(Sub_Form_ProfEdit_ColumnChanged);
       }

        private void listBox_tables_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string nameTbl = listBox_tables.Text;
            myBindingSource = new BindingSource(myProfSetToEdit, nameTbl);
            DataGrid_main.DataSource = myBindingSource;
            DataGrid_main.CaptionText = "Table: " + myBindingSource.DataMember;
        }

        private void Sub_Form_ProfEdit_TableNewRow(Object sender, DataTableNewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Table.Columns.Count; i++)
            {
                Console.WriteLine(e.Row.Table.Columns[i].ColumnName);
                Console.WriteLine(e.Row[i]);
            }
            //e.Row[0] = Convert.ToInt32(myMainTable.Rows[myMainTable.Rows.Count - 1].ItemArray.GetValue(0)) + 1;
        }

        private void Sub_Form_ProfEdit_ColumnChanged(Object sender, DataColumnChangeEventArgs e)
        {
            Console.WriteLine(e.Column);
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            myProfSetToEdit.WriteXml(myFile);
            myProfSetToEdit.AcceptChanges();
            System.Windows.Forms.MessageBox.Show("Daten gespeichert!");
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            myProfSetToEdit.RejectChanges();
            this.Close();
        }

    }
}