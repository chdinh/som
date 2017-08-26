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
    public partial class Sub_Form_TSP : Form
    {
        private Network myCircleNet;
        private List<Point> myTargets;

        public Sub_Form_TSP()
        {
            InitializeComponent();
            myCircleNet = new Network(20, pictureBox_Anzeige.Width/2, pictureBox_Anzeige.Height/2);
            myTargets = new List<Point>();
            myTargets.Add(new Point(28, 105));
            myTargets.Add(new Point(384, 210));
            myTargets.Add(new Point(176, 408));
            myTargets.Add(new Point(262, 168));
            myTargets.Add(new Point(295, 350));
            myTargets.Add(new Point(279, 423));
            myTargets.Add(new Point(360, 444));
            pictureBox_Anzeige.Invalidate();
        }

        private void but_train_Click(object sender, EventArgs e)
        {
            textBox_Cycles.Text = textBox_Cycles.Text == String.Empty ? "10" : textBox_Cycles.Text;
            int totalCyc = Convert.ToInt32(textBox_Cycles.Text);
            double neuronNum = myCircleNet.NumOfNeurons;
            double radius = Convert.ToDouble(myCircleNet.NumOfNeurons) / 2;
            for (int i = 0; i < totalCyc; i++)
            {
                double fak = Convert.ToDouble(i) / neuronNum;
                for (int j = 0; j < myTargets.Count; j++)
                {
                    myCircleNet.train_Pattern(new Vector(new double[2] { myTargets[j].X, myTargets[j].Y }), Network.net_hFkt.hgauss1, radius);
                }
                radius = radius - radius * fak;
            }
            pictureBox_Anzeige.Invalidate();
        }

        private void but_create_Click(object sender, EventArgs e)
        {
            textBox_Neurons.Text = textBox_Neurons.Text == String.Empty ? "10" : textBox_Neurons.Text;
            myCircleNet = new Network(Convert.ToInt32(textBox_Neurons.Text), pictureBox_Anzeige.Width / 2, pictureBox_Anzeige.Height / 2);
            pictureBox_Anzeige.Invalidate();
        }

        private void pictureBox_Anzeige_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Courier New", 10);
            Pen pen_Citys = new Pen(Color.OrangeRed);
            Pen pen_Trader = new Pen(Color.Green);
            for (int i = 0; i < myTargets.Count; i++)
            {
                g.DrawEllipse(pen_Citys, myTargets[i].X, myTargets[i].Y, 8, 8);
            }
            PointF[] pt = new PointF[myCircleNet.Neurons.Count + 1];
            for (int i = 0; i < myCircleNet.Neurons.Count; i++)
            {
                pt[i] = new PointF(Convert.ToInt32(myCircleNet.Neurons[i].WeightVec[0]), Convert.ToInt32(myCircleNet.Neurons[i].WeightVec[1]));
                g.DrawEllipse(pen_Trader, pt[i].X, pt[i].Y, 5, 5);
            }
            pt[pt.Length - 1] = new PointF(Convert.ToInt32(myCircleNet.Neurons[0].WeightVec[0]), Convert.ToInt32(myCircleNet.Neurons[0].WeightVec[1]));
            g.DrawLines(pen_Trader, pt);
        }

        private void TestInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            int input = Convert.ToInt32(e.KeyChar);
            if ((input >= 44 && input <= 57) || (input == 8))
                return;
            e.Handled = true;
        }

        private void pictureBox_Anzeige_MouseClick(object sender, MouseEventArgs e)
        {
            Boolean add = true;
            int pos = 0;
            for (int i = 0; i < myTargets.Count; i++)
            {
                if (e.X > myTargets[i].X && e.X < myTargets[i].X + 8 && e.Y > myTargets[i].Y && e.Y < myTargets[i].Y + 8)
                {
                    add = false;
                    pos = i;
                }
            }
            if (add)
            {
                myTargets.Add(new Point(e.X - 4, e.Y - 4));
            }
            else
            {
                myTargets.RemoveAt(pos);
            }
            pictureBox_Anzeige.Invalidate();
        }
    }
}