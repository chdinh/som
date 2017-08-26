using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using nn_som;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SOM
{
    public partial class Sub_Form_TrainNet : Form
    {
        private Network myNet;
        private List<RecordSet> mySL;
        private Dictionary<string, int> myNetStruct;

        private string saveFile;

        private int length = 0;

        public Sub_Form_TrainNet(Network myTrainNet, List<RecordSet> mySearchList, Dictionary<string, int> netAufbau, string targetFile)
        {
            InitializeComponent();
            myNet = myTrainNet;
            mySL = mySearchList;
            myNetStruct = netAufbau;

            but_train.Enabled = myNet == null ? false : true;

            foreach (string key in netAufbau.Keys)
            {
                length += Convert.ToInt32(netAufbau[key]);
            }

            saveFile = targetFile;

            textBox_dim.Text = Convert.ToString(netAufbau.Count);
        }

        private void but_create_Click(object sender, EventArgs e)
        {
            textBox_NCount.Text = Convert.ToInt32(textBox_NCount.Text) > 0 ? textBox_NCount.Text : "3";

            int[] netArch = new int[myNetStruct.Count];

            for (int i = 0; i < netArch.Length; i++)
                netArch[i] = Convert.ToInt32(textBox_NCount.Text);

            MessageBox.Show("Netzwerk erstellt!");

            myNet = new Network(length, netArch, 10);


            ((Form_MainAp)Application.OpenForms[0]).searchNetwork = myNet;

            but_train.Enabled = myNet == null ? false : true;
        }

        private void but_train_Click(object sender, EventArgs e)
        {

            textBox_Epoch.Text = Convert.ToInt32(textBox_Epoch.Text) > 0 ? textBox_Epoch.Text : "100";

            this.Text = "Train Network - Netzwerk wird trainiert, bitte warten!";

            int maxCyc = Convert.ToInt32(textBox_Epoch.Text);
            
            for (int cyc = 0; cyc < maxCyc; cyc++)
            {
                Application.DoEvents();
                for (int i = 0; i < mySL.Count; i++)
                {
                    myNet.train_Pattern(mySL[i].InputVec, Network.net_hFkt.hgauss1, 2);
                }

                progressBar_train.Value = Convert.ToInt32( 100 * Convert.ToDouble(cyc) / Convert.ToDouble(maxCyc));
            }

            progressBar_train.Value = 0;

            this.Text = "Train Network";

            MessageBox.Show("Netzwerk trainiert!");

            ((Form_MainAp)Application.OpenForms[0]).searchNetwork = myNet;
            ((Form_MainAp)Application.OpenForms[0]).AssociateSearchListwithNetwork();

            try
            {
                FileStream myStream = new FileStream(saveFile, FileMode.Create);
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(myStream, myNet);
                myStream.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        private void textBox_NumCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            int input = Convert.ToInt32(e.KeyChar);
            if ((input >= 44 && input <= 57) || (input == 8))
                return;
            e.Handled = true;
        }

        private void textBox_NCount_TextChanged(object sender, EventArgs e)
        {
            if (textBox_NCount.Text != String.Empty)
            {
                textBox_NCount.Text = Convert.ToInt32(textBox_NCount.Text) > 0 ? textBox_NCount.Text : "3";
                label_num.Text = String.Concat(Math.Pow(Convert.ToInt32(textBox_NCount.Text), myNetStruct.Count), " Neuronen");
            }
        }
    }
}