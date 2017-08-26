using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using nn_som;
using nn_math;

namespace SOM
{
    public partial class Sub_Form_MerKlass : Form
    {
        DataSet myDataSet;
        DataTable myAnimalTable;
        Network myNNet;
        List<RecordSet> myRecords;

        public Sub_Form_MerKlass()
        {
            InitializeComponent();

            myDataSet = new DataSet();
            myAnimalTable = new DataTable("AnimalFarm");
            myAnimalTable.Columns.Add("Name", typeof(string));

            myAnimalTable.Columns.Add("fliegt", typeof(bool));
            myAnimalTable.Columns.Add("schwimmt", typeof(bool));
            myAnimalTable.Columns.Add("groß", typeof(bool));
            myAnimalTable.Columns.Add("jagt", typeof(bool));
            myAnimalTable.Columns.Add("hat Hufe", typeof(bool));
            myAnimalTable.Columns.Add("hat Pfoten", typeof(bool));
            myAnimalTable.Columns.Add("hat Flossen", typeof(bool));
            myAnimalTable.Columns.Add("hat Federn", typeof(bool));
            myAnimalTable.Columns.Add("hat Fell", typeof(bool));
            myAnimalTable.Columns.Add("hat Schuppen", typeof(bool));
            myAnimalTable.Columns.Add("hat Schwanz", typeof(bool));

            myAnimalTable.Rows.Add("Ente", true, true, false, false, false, false, false, true, false, false, false);
            myAnimalTable.Rows.Add("Karpfen", false, true, false, false, false, false, true, false, false, true, true);
            myAnimalTable.Rows.Add("Löwe", false, false, true, true, false, true, false, false, true, false, true);
            myAnimalTable.Rows.Add("Kuh", false, false, true, false, true, false, false, false, true, false, true);
            myAnimalTable.Rows.Add("Katze", false, false, false, true, false, true, false, false, true, false, true);
            myAnimalTable.Rows.Add("Delphin", false, true, true, true, false, false, true, false, false, false, true);
            myAnimalTable.Rows.Add("Taube", true, false, false, false, false, false, false, true, false, false, false);
            myAnimalTable.Rows.Add("Elephant", false, false, true, false, false, false, false, false, false, false, true);
            
            dataGridView_myAnimals.DataSource = myAnimalTable;
            
            pictureBox_Anzeige.Invalidate();

            myNNet = new Network(myAnimalTable.Columns.Count - 1, new int[2] { 8, 7 }, 1);

            myRecords = new List<RecordSet>();

            for (int i = 0; i < myAnimalTable.Rows.Count; i++)
            {
                double[] myElements = new double[]{
                    Convert.ToInt32(myAnimalTable.Rows[i][1]),Convert.ToInt32(myAnimalTable.Rows[i][2]),Convert.ToInt32(myAnimalTable.Rows[i][3]),Convert.ToInt32(myAnimalTable.Rows[i][4]),Convert.ToInt32(myAnimalTable.Rows[i][5]),
                    Convert.ToInt32(myAnimalTable.Rows[i][6]),Convert.ToInt32(myAnimalTable.Rows[i][7]),Convert.ToInt32(myAnimalTable.Rows[i][8]),Convert.ToInt32(myAnimalTable.Rows[i][9]),Convert.ToInt32(myAnimalTable.Rows[i][10]),Convert.ToInt32(myAnimalTable.Rows[i][11])};
                myRecords.Add(new RecordSet(i, myAnimalTable.Rows[i][0], new Vector(myElements)));
            }
        }

        private void pictureBox_Anzeige_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Courier New", 10);
            Pen pen = new Pen(Color.Gray);
            for (int i = 0; i < myRecords.Count; i++)
            {
                g.DrawString(String.Concat(myRecords[i].Content," ", myRecords[i].CurrentNeuron == null ? 0 : myRecords[i].CurrentNeuron.Position[0]," ", myRecords[i].CurrentNeuron == null ? 0 : myRecords[i].CurrentNeuron.Position[1]), font, brush,
                    10 + (myRecords[i].CurrentNeuron == null ? 0 : Convert.ToInt32(myRecords[i].CurrentNeuron.Position[1] * 80)),
                    8 + (myRecords[i].CurrentNeuron == null ? 0 : Convert.ToInt32(myRecords[i].CurrentNeuron.Position[0] * 30)));
            }
            for (int i = 1; i < 7; i++)
            {
                g.DrawLine(pen, 80 * i, 0, 80 * i, pictureBox_Anzeige.Height);
            }
            for (int i = 1; i < 8; i++)
            {
                g.DrawLine(pen, 0, 30 * i, pictureBox_Anzeige.Width, 30 * i);
            }
        }

        private void but_train_Click(object sender, EventArgs e)
        {
            textBox_Cycles.Text = textBox_Cycles.Text == String.Empty ? "10" : textBox_Cycles.Text;
            myNNet.train_RecordSet(myRecords, Network.net_hFkt.hgauss1, Convert.ToInt32(textBox_Cycles.Text));
            pictureBox_Anzeige.Invalidate();
        }

        private void CellChanged(int iRow)
        {
            double[] myElements = new double[]{
                    Convert.ToInt32(myAnimalTable.Rows[iRow][1]),Convert.ToInt32(myAnimalTable.Rows[iRow][2]),Convert.ToInt32(myAnimalTable.Rows[iRow][3]),Convert.ToInt32(myAnimalTable.Rows[iRow][4]),Convert.ToInt32(myAnimalTable.Rows[iRow][5]),
                    Convert.ToInt32(myAnimalTable.Rows[iRow][6]),Convert.ToInt32(myAnimalTable.Rows[iRow][7]),Convert.ToInt32(myAnimalTable.Rows[iRow][8]),Convert.ToInt32(myAnimalTable.Rows[iRow][9]),Convert.ToInt32(myAnimalTable.Rows[iRow][10]),Convert.ToInt32(myAnimalTable.Rows[iRow][11])};
            myRecords[iRow].InputVec = new Vector(myElements);
            myRecords[iRow].Content = myAnimalTable.Rows[iRow][0];
            pictureBox_Anzeige.Invalidate();
        }

        private void dataGridView_myAnimals_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CellChanged(e.RowIndex);
        }

        private void but_addSpezies_Click(object sender, EventArgs e)
        {
            myAnimalTable.Rows.Add("Spezies", false, false, false, false, false, false, false, false, false, false, false);
            double[] myElements = new double[]{
                    Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][1]), Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][2]),
                Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][3]), Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][4]),
                Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][5]),Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][6]),
                Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][7]),Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][8]),
                Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][9]),Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][10]),
            Convert.ToInt32(myAnimalTable.Rows[myAnimalTable.Rows.Count-1][11])};
            myRecords.Add(new RecordSet(myAnimalTable.Rows.Count - 1, myAnimalTable.Rows[myAnimalTable.Rows.Count - 1][0], new Vector(myElements)));
            pictureBox_Anzeige.Invalidate();
        }

        private void textBox_Cycles_KeyPress(object sender, KeyPressEventArgs e)
        {
            int input = Convert.ToInt32(e.KeyChar);
            if ((input >= 44 && input <= 57) || (input == 8))
                return;
            e.Handled = true;
        }
    }
}