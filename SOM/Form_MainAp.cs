using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

using nn_math;
using nn_som;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SOM
{
    public partial class Form_MainAp : Form
    {

        private Sub_AboutSOM frm_ab;
        private Sub_Form_MerKlass frm_MerKlass;
        private Sub_Form_TSP frm_TSP;
        private Sub_Form_ProfEdit frm_ProfEdit;
        private Sub_Form_ProfInfo frm_ProfInfo;
        private Sub_Form_TrainNet frm_TrainNet;


        private DataSet ProfCatalog;

        private string fileSchema = "Prof_Schema.xsd";
        private string fileData = "Prof_Data.xml";
        private string currentNetFileName = "ProfSearch.net";

        private string strFile;

        private List<RecordSet> SearchList_Profs;

        private Vector search_Vec;

        private Dictionary<string,int> KompAufbau;

        private TreeNode currentNode;

        public Network searchNetwork;

        private string profID;
        private string kompID;

        private List<String> myHints;
        private List<String> myProfIDs;

        public Form_MainAp()
        {
            InitializeComponent();

            ProfCatalog = new DataSet("Profs");


            ProfCatalog.ReadXmlSchema(fileSchema);

            ProfCatalog.ReadXml(fileData);

            SearchList_Profs = new List<RecordSet>();


            treeView_search.BeginUpdate();
            treeView_search.Nodes.Add("Kompetenz - Tree");

            int length = 0;

            int count = ProfCatalog.Tables["Kompetenzfelder"].ChildRelations.Count;

            KompAufbau = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                treeView_search.Nodes[0].Nodes.Add(ProfCatalog.Tables["Kompetenzfelder"].ChildRelations[i].RelationName);
                for (int j = 0; j < ProfCatalog.Tables["Kompetenzfelder"].ChildRelations[i].ChildTable.Columns.Count - 1; j++)
                    treeView_search.Nodes[0].Nodes[i].Nodes.Add(ProfCatalog.Tables["Kompetenzfelder"].ChildRelations[i].ChildTable.Columns[j].ColumnName, String.Concat(ProfCatalog.Tables["Kompetenzfelder"].ChildRelations[i].ChildTable.Columns[j].ColumnName, " : ", 0));

                length += ProfCatalog.Tables["Kompetenzfelder"].ChildRelations[i].ChildTable.Columns.Count - 1;
                KompAufbau.Add(ProfCatalog.Tables["Kompetenzfelder"].ChildRelations[i].RelationName, ProfCatalog.Tables["Kompetenzfelder"].ChildRelations[i].ChildTable.Columns.Count - 1);
            }

            treeView_search.EndUpdate();
            treeView_search.Nodes[0].Expand();

            search_Vec = new Vector(length);
            search_Vec.FillVect(0);

            profID = ProfCatalog.Tables["Prof"].Columns[ProfCatalog.Tables["Prof"].Columns.Count - 1].ColumnName;

            //myKompTable -> Referenz auf Profs Kompetenztabelle
            DataTable myKompTable = ProfCatalog.Tables["Kompetenzfelder"];

            kompID = myKompTable.Columns[myKompTable.Columns.Count - 2].ColumnName;

            for (int i = 0; i < myKompTable.Rows.Count; i++)
            {
                double[] tempKomp = new double[length];
                count = 0;
                foreach (string key in KompAufbau.Keys)
                {


                    for (int z = 0; z < myKompTable.ChildRelations[key].ChildTable.Rows.Count; z++)
                    {
                        if (Convert.ToInt32(myKompTable.ChildRelations[key].ChildTable.Rows[z][kompID]) == Convert.ToInt32(myKompTable.Rows[i][kompID]))
                        {
                            //-1 da letzte Spalte für id -> nich mit gezählt
                            for (int k = 0; k < myKompTable.ChildRelations[key].ChildTable.Columns.Count - 1; k++)
                            {
                                tempKomp[count + k] = Convert.ToDouble(myKompTable.ChildRelations[key].ChildTable.Rows[z][k]);
                            }
                        }
                    }
                    count += Convert.ToInt32(KompAufbau[key]);
                }

                Hashtable Content = new Hashtable();
                Content.Add(profID, myKompTable.Rows[i][profID]);
                Content.Add(kompID, myKompTable.Rows[i][kompID]);

                SearchList_Profs.Add(new RecordSet(Convert.ToInt32(myKompTable.Rows[i][profID]), Content, new Vector(tempKomp)));
            }

            if (File.Exists(currentNetFileName))
            {
                try
                {
                    FileStream fs = new FileStream(currentNetFileName, FileMode.Open);
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    searchNetwork = (Network)binFormatter.Deserialize(fs);
                    fs.Close();
                    AssociateSearchListwithNetwork();
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private int getIndex(int Level1, int Level2)
        {
            int index = 0;
            int count = 0;
            foreach (string key in KompAufbau.Keys)
            {
                count++;
                if (count > Level1)
                    break;
                index += Convert.ToInt32(KompAufbau[key]);
            }
            index += Level2;
            return index;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ab = new Sub_AboutSOM();
            frm_ab.ShowDialog();
        }

        private void merkmalsklassifizierungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_MerKlass = new Sub_Form_MerKlass();
            frm_MerKlass.Show();
        }

        private void travelingSalesmanProbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TSP = new Sub_Form_TSP();
            frm_TSP.Show();
        }

        private void profEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ProfEdit = new Sub_Form_ProfEdit(ProfCatalog, fileData);
            frm_ProfEdit.Show();
        }

        private void treeView_search_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                currentNode = e.Node;
                textBox_compEdit.Text = Convert.ToString(search_Vec[getIndex(e.Node.Parent.Index, e.Node.Index)]);
            }
            else
            {
                currentNode = null;
                textBox_compEdit.Text = String.Empty;
            }
        }

        private void textBox_compEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            int input = Convert.ToInt32(e.KeyChar);
            if ((input >= 44 && input <= 57) || (input == 8))
                return;
            e.Handled = true;
        }

        private void textBox_compEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (currentNode != null && textBox_compEdit.Text != String.Empty)
            {
                try
                {
                    textBox_compEdit.Text = Convert.ToDouble(textBox_compEdit.Text) > 10 ? "10" : Convert.ToDouble(textBox_compEdit.Text) < 0 ? "0" : textBox_compEdit.Text;
                    int index = getIndex(currentNode.Parent.Index, currentNode.Index);
                    currentNode.Text = String.Concat(currentNode.Text.Split(':')[0], ": ", Convert.ToDouble(textBox_compEdit.Text));
                    search_Vec[index] = Convert.ToDouble(textBox_compEdit.Text);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Falscher Eingabewert!");
                }
            }
        }

        private void trainNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TrainNet = new Sub_Form_TrainNet(searchNetwork, SearchList_Profs, KompAufbau, currentNetFileName);
            frm_TrainNet.Show();

            /*
            train_SearchList();

            try
            {
                FileStream myStream = new FileStream(currentNetFileName, FileMode.Create);
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(myStream, searchNetwork);
                myStream.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }*/
        }

        private void train_SearchList()
        {
            for (int cyc = 0; cyc < 100; cyc++)
            {
                for (int i = 0; i < SearchList_Profs.Count; i++)
                {
                    searchNetwork.train_Pattern(SearchList_Profs[i].InputVec, Network.net_hFkt.hgauss1, 2);
                }
            }
            AssociateSearchListwithNetwork();
        }

        public void AssociateSearchListwithNetwork()
        {
            for (int i = 0; i < SearchList_Profs.Count; i++)
            {
                SearchList_Profs[i].AddRecordSetToNeuron(searchNetwork.Get_BestMatching(SearchList_Profs[i].InputVec));
            }
        }

        private void but_search_Click(object sender, EventArgs e)
        {
            List<double[]> myOutputList = new List<double[]>();
            List<double[]> mySortedList = new List<double[]>();

            if (searchNetwork != null)
            {
                myHints = new List<string>();
                myProfIDs = new List<string>();
                listView_searchResult.Items.Clear();
                //searchNetwork.Calculate_BestMatching(search_Vec, 1);
                searchNetwork.Search_BestMatching(search_Vec);
                
                int dim = 0;
                for (int i = 0; i < search_Vec.Dimension; i++)
                    if (search_Vec[i] != 0)
                        dim++;

                double PercentofOne = dim > 0 ? 100 / (Convert.ToDouble(dim) * 10) : 0;
                int count = 0;
                for (int i = 0; i < searchNetwork.Neurons.Count; i++)
                {
                    if (searchNetwork.Neurons[i].Records.Count > 0)
                    {
                        count++;
                        foreach (int Key in searchNetwork.Neurons[i].Records.Keys)
                        {
                            DataRow[] myDataRow = ProfCatalog.Tables["Prof"].Select(profID + " = " + ((Hashtable)searchNetwork.Neurons[i].Records[Key].Content)[profID] + "");

                            myOutputList.Add(new double[2] { 100 - PercentofOne * searchNetwork.Neurons[i].DistanceToBm,
                                Convert.ToInt32(((Hashtable)searchNetwork.Neurons[i].Records[Key].Content)[profID]) });

                        }
                    }
                }
            }
            /*
            while (myOutputList.Count > 0)
            {
                double max = 0;
                int index = 0;

                for (int i = 0; i < myOutputList.Count; i++)
                {
                    if (max< myOutputList[i][0])
                    {
                        max = myOutputList[i][0];
                        index = i;
                    }
                }
                mySortedList.Add(myOutputList[index]);
                myOutputList.RemoveAt(index);
            }*/

            //for (int i = 0; i < mySortedList.Count && i < Convert.ToInt32(textBox_ergCount.Text); i++)
            for (int i = 0; i < myOutputList.Count && i < Convert.ToInt32(textBox_ergCount.Text); i++)
            {
                DataRow[] myDataRow = ProfCatalog.Tables["Prof"].Select(profID + " = " + myOutputList[i][1] + "");
                ListViewItem subI = listView_searchResult.Items.Add(String.Concat(myOutputList[i][0], "%"));
                subI.SubItems.Add(String.Concat(myDataRow[0].ItemArray.GetValue(2), " ", myDataRow[0].ItemArray.GetValue(0)));
                myHints.Add(String.Concat(myDataRow[0].ItemArray.GetValue(2), " ", myDataRow[0].ItemArray.GetValue(1), " ", myDataRow[0].ItemArray.GetValue(0), "\r\n"));
                myProfIDs.Add(Convert.ToString(myOutputList[i][1]));
            }
        }

        private void listView_searchResult_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            toolTip_Prof.SetToolTip(listView_searchResult, myHints[e.Item.Index]);
        }

        private void listView_searchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm_ProfInfo = new Sub_Form_ProfInfo(ProfCatalog, profID, myProfIDs[listView_searchResult.SelectedItems[0].Index]);
            frm_ProfInfo.Show();
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgFileOpen = new OpenFileDialog();
            dlgFileOpen.Filter = String.Concat("Network (*.net)|*.net");
            dlgFileOpen.Title = "SearchNet öffnen";
            if (dlgFileOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(dlgFileOpen.FileName, FileMode.Open);
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    searchNetwork = (Network)binFormatter.Deserialize(fs);
                    fs.Close();
                    AssociateSearchListwithNetwork();
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgFileSave = new SaveFileDialog();
            dlgFileSave.Filter = String.Concat("Network (*.net)|*.net");
            dlgFileSave.Title = "SearchNet speichern";
            if (strFile != null && strFile.Length > 0)
            {
                dlgFileSave.FileName = strFile;
            }
            if (dlgFileSave.ShowDialog() == DialogResult.OK)
            {
                strFile = dlgFileSave.FileName;
                try
                {
                    FileStream myStream = new FileStream(strFile, FileMode.Create);
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    binFormatter.Serialize(myStream, searchNetwork);
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void treeView_search_MouseHover(object sender, EventArgs e)
        {
            toolTip_Search.SetToolTip((Control)sender, "1 - geringe u. 10 - hohe Kompetenz; 0 - nicht relevant");
        }
    }
}