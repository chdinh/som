using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOM
{
    public partial class Sub_Form_ProfInfo : Form
    {
        public Sub_Form_ProfInfo(DataSet myData, string ProfID_col, string ProfID_num)
        {
            InitializeComponent();
            DataRow[] myDataRow = myData.Tables["Prof"].Select(ProfID_col + " = " + ProfID_num + "");
            this.Text = String.Concat(myDataRow[0].ItemArray.GetValue(2), " ", myDataRow[0].ItemArray.GetValue(1), " ", myDataRow[0].ItemArray.GetValue(0)); ;
            label_name.Text = String.Concat(myDataRow[0].ItemArray.GetValue(2), " ", myDataRow[0].ItemArray.GetValue(1), " ", myDataRow[0].ItemArray.GetValue(0));
            textBox_info.Text = String.Concat("E-Mail: ",myDataRow[0].ItemArray.GetValue(3), "\r\n", "Telephon: ", myDataRow[0].ItemArray.GetValue(4),"\r\n");

            DataRow[] myFakDataRow = myData.Tables["Fak"].Select(ProfID_col + " = " + ProfID_num + "");
            textBox_info.Text = String.Concat(textBox_info.Text, "Fakultät: ", myFakDataRow[0].ItemArray[0], "\r\n");

            string FakID_col = myFakDataRow[0].Table.Columns[1].ColumnName;
            string FakID_num = Convert.ToString(myFakDataRow[0].ItemArray[1]);
            DataRow[] myFakAdressDataRow = myData.Tables["Adress"].Select(FakID_col + " = " + FakID_num + "");
            textBox_info.Text = String.Concat(textBox_info.Text, "\r\n", "Anschrift: ", "\r\n", myFakAdressDataRow[0].ItemArray[0], "\r\n"
                , myFakAdressDataRow[0].ItemArray[1], "\r\n"
                , myFakAdressDataRow[0].ItemArray[4], " ", myFakAdressDataRow[0].ItemArray[2], "\r\n"
                , myFakAdressDataRow[0].ItemArray[3]);
        }
    }
}