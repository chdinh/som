using System;
using System.Collections.Generic;
using System.Text;

using nn_math;

namespace nn_som
{
    public interface INetwork
    {
        List<Neuron> Neurons { get; set; }

        Vector Net_Center { get; }
    }

    [Serializable]
    public class Network
    {
        #region Fields
        /// <summary>
        /// Fields
        /// </summary>
        private List<Neuron> net_Neurons;

        private BmNeuron net_BmNeuron;

        private Vector net_centerPos;

        private Vector net_maxPos;

        private int net_numOfInputs;

        private int net_numOfNeurons;

        public enum net_hFkt : int
        {
            hgauss1 = 1,
            hcylinder = 2,
            hcone = 3,
            hcos = 4
        }

        #endregion

        #region Properties
        /// <summary>
        /// Properties
        /// </summary>
        public int NumOfInputs
        {
            get { return net_numOfInputs; }
        }

        public int NumOfNeurons
        {
            get { return net_numOfNeurons; }
        }

        public List<Neuron> Neurons
        {
            get { return net_Neurons; }
            set { net_Neurons = value; }
        }

        public Vector Net_Center
        {
            get { return net_centerPos; }
        }

        public Vector Net_Maximum
        {
            get { return net_maxPos; }
        }
        #endregion
        
        #region Konstruktoren
        /// <summary>
        /// Standard Konstruktor
        /// </summary>
        /// <param name="inputs">Anzahl der Eingabe Neuronen</param>
        /// <param name="netArchitektur">Jedes Array Feld ist entspricht einer Dimension mit der Anzahl der Kohonen-Neuronen</param>
        /// <param name="maxWeight">Maximales- Initialgewicht, 0..maxWeight</param>
        public Network(int inputs, int[] netArchitektur, double maxWeight)
        {

            int numNeur = 1;
            for (int i = 0; i < netArchitektur.Length; i++)
            {
                numNeur *= netArchitektur[i];
            }

            net_numOfInputs = inputs;
            net_numOfNeurons = numNeur;
            //Implemetiert wie im A. Zell, Hilfs-Matrix, damit Randomobjekt nur einmal implementiert werden muss
            Matrix net_Weights = new Matrix(inputs, numNeur);
            System.Random rnd = new System.Random();
            //Symmetry Breaking
            for (int i = 0; i < net_Weights.Rows; i++)
                for (int j = 0; j < net_Weights.Cols; j++)
                    net_Weights[i, j] = rnd.NextDouble() * maxWeight;

            net_BmNeuron = new BmNeuron(null);
            net_Neurons = new List<Neuron>();

            //Vektor mit anzahl der Dimensionen
            net_centerPos = new Vector(netArchitektur.Length);
            net_maxPos = new Vector(netArchitektur.Length);
            //max/2 der jeweiligen Dimension
            for (int i = 0; i < netArchitektur.Length; i++)
            {
                net_centerPos[i] = netArchitektur[i] / 2;
                net_maxPos[i] = netArchitektur[i];
            }

            Vector myCoordVec = Vector.NullVector(netArchitektur.Length);
            //Neuronen-Struktur Aufbauen
            for (int i = 0; i < numNeur; i++)
            {
                net_Neurons.Add(new Neuron(myCoordVec.Duplicate(), net_Weights.ConvertColToVector(i), net_BmNeuron));
                myCoordVec[0] += 1;
                for (int j = 0; j < net_maxPos.Dimension; j++)
                {
                    if (net_maxPos[j] - myCoordVec[j] == 0)
                    {
                        myCoordVec[j] = 0;
                        if (i != numNeur - 1)
                            myCoordVec[j + 1] += 1;
                    }
                }
            }
        }
        /// <summary>
        /// Circle Konstruktor
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="numNeur"></param>
        /// <param name="maxWeight"></param>
        public Network(int numNeur, double maxWeight_X, double maxWeight_Y)
        {
            net_numOfInputs = 2;
            net_numOfNeurons = numNeur;
            //Implemetiert wie im A. Zell, Hilfs-Matrix, damit Randomobjekt nur einmal implementiert werden muss
            Matrix net_Weights = new Matrix(2, numNeur);

            double rad = (2*Math.PI)/numNeur;
            //Symmetry Breaking
            for (int j = 0; j < numNeur; j++)
            {
                net_Weights[0, j] = Math.Cos(rad * j) * maxWeight_X + maxWeight_X;
                net_Weights[1, j] = Math.Sin(rad * j) * maxWeight_Y + maxWeight_Y;
            }

            net_BmNeuron = new BmNeuron(null);
            net_Neurons = new List<Neuron>();

            //Vektor mit anzahl der Dimensionen
            net_centerPos = new Vector(new int[1] { numNeur / 2 });
            net_maxPos = new Vector(new int[1] { numNeur });

            Vector myCoordVec = Vector.NullVector(1);
            //Neuronen-Struktur Aufbauen
            for (int i = 0; i < numNeur; i++)
            {
                net_Neurons.Add(new Neuron(myCoordVec.Duplicate(), net_Weights.ConvertColToVector(i), net_BmNeuron));
                myCoordVec[0] += 1;
                for (int j = 0; j < net_maxPos.Dimension; j++)
                {
                    if (net_maxPos[j] - myCoordVec[j] == 0)
                    {
                        myCoordVec[j] = 0;
                        if (i != numNeur - 1)
                            myCoordVec[j + 1] += 1;
                    }
                }
            }
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Liefert das Bestmatching Neuron zurück
        /// </summary>
        /// <param name="InpVect">Eingabe-Vektor X</param>
        /// <returns></returns>
        public Neuron Get_BestMatching(Vector InpVect)
        {
            Neuron bm_neuron;
            double min;
            double c;
            try
            {
                //irgend eine Distanz zum aktuellen Input
                min = (InpVect - Neurons[0].WeightVec).Euklid();
                bm_neuron = Neurons[0];
            }
            catch
            {
                throw new Exception("Operation not possible.");
            }
            for (int i = 1; i < net_Neurons.Count; i++)
            {
                c = (InpVect - Neurons[i].WeightVec).Euklid();
                if (c < min)
                {
                    min = c;
                    bm_neuron = Neurons[i];
                }
            }
            return bm_neuron;
        }

        /// <summary>
        /// Berechnet das Bestmatching, ordnet das Netz neu und Sortiert die Neuronen Liste
        /// </summary>
        /// <param name="InputVec">Eingabe-Vektor X</param>
        public void Calculate_BestMatching(Vector InputVec, int Radius)
        {
            net_BmNeuron.BM_Neuron = Get_BestMatching(InputVec);
            bool move = false;
            //testen ob eine Vesrchiebung des Bm's überhaupt notwendig
            for (int i = 0; i < net_BmNeuron.Position.Dimension && !move; i++)
            {
                //testen ob man mit dem Radius irgendwo über den Rand kommt
                if (net_BmNeuron.Position[i] - Radius < 0 || net_BmNeuron.Position[i] + Radius >= net_maxPos[i])
                    move = true;
            }
            if (move)
                Set_BmAsCenter();

            //Neuronen beginnend beim BM, dann Nachbarn absteigend nach Entfernung sortieren
            net_Neurons.Sort();
        }

        public void Search_BestMatching(Vector SearchVec)
        {
            double min = 0;
            double c;
            
            List<int> mySearchVec_Aufbau = new List<int>();

            for (int i = 0; i < SearchVec.Dimension; i++)
                if (SearchVec[i] != 0)
                    mySearchVec_Aufbau.Add(i);

            Vector NeuronVec = new Vector(mySearchVec_Aufbau.Count);

            for (int i = 0; i < net_Neurons.Count; i++)
            {
                for (int j = 0; j < NeuronVec.Dimension; j++)
                {
                    NeuronVec[j] = SearchVec[mySearchVec_Aufbau[j]] - Neurons[i].WeightVec[mySearchVec_Aufbau[j]];
                }
                c = NeuronVec.Euklid();
                if (i == 0 || c < min)
                {
                    min = c;
                    net_BmNeuron.BM_Neuron = Neurons[i];
                }
            }

            net_Neurons.Sort();
        }
        
        /// <summary>
        /// Rückt das Bestmatching Neuron in die Mitte der Kohonen-Map
        /// </summary>
        private void Set_BmAsCenter()
        {
            Vector differenzVec = Net_Center - net_BmNeuron.Position;
            for (int i = 0; i < Neurons.Count; i++)
            {
                Neurons[i].Position = Neurons[i].Position + differenzVec;
                for (int j = 0; j < Neurons[i].Position.Dimension; j++)
                {
                    if (Neurons[i].Position[j] >= Net_Maximum[j])
                        Neurons[i].Position[j] -= Net_Maximum[j];
                    if (Neurons[i].Position[j] < 0)
                        Neurons[i].Position[j] += Net_Maximum[j];
                }
            }
        }

        public void train_RecordSet(List<RecordSet> myRecs, net_hFkt neighbourFkt, int Cycles)
        {
            for (int cyc = 0; cyc < Cycles; cyc++)
            {
                for (int i = 0; i < myRecs.Count; i++)
                {
                    train_Pattern(myRecs[i].InputVec, net_hFkt.hgauss1, 5);
                    myRecs[i].AddRecordSetToNeuron(net_BmNeuron.BM_Neuron);
                }
            }
        }
        /// <summary>
        /// Trainiert das Netz zu dem repräsentierten Eingabe-Pattern
        /// </summary>
        /// <param name="InputVec">Eingabe-Vektor X (Lern-Pattern)</param>
        public void train_Pattern(Vector InputVec, net_hFkt neighbourFkt, double radius)
        {
            double mu = 0.6;
            Calculate_BestMatching(InputVec, Convert.ToInt32(radius));
            //auch nur so lange korrigieren wie Neuronen vorhanden, bzw. auch nur im Radius (abhängig von der Dimension) sich befinden
            for (int i = 0; i < Neurons.Count && i < radius * Neurons[0].Position.Dimension * 2 + 1; i++)
            {
                Neurons[i].WeightVec = Neurons[i].WeightVec +
                    mu * hcFkt((net_BmNeuron.Position - Neurons[i].Position).Euklid(), radius == 0 ? 1 : radius, neighbourFkt) * (InputVec - Neurons[i].WeightVec);
            }
        }

        /// <summary>
        /// Berechnet den Wert der Nachbarschaftsfunktion 
        /// </summary>
        /// <param name="z">Abstand (Norm) zum Gewinner-Neuron</param>
        /// <param name="d">DistanzParameter (Radius)</param>
        /// <param name="selFkt">Selektierte Nachbarschaftsfunktion</param>
        /// <returns></returns>
        private double hcFkt(double z, double d, net_hFkt selFkt)
        {
            double h = 0;
            switch (selFkt)
            {
                case net_hFkt.hgauss1:
                    {
                        h = Math.Exp(-Math.Pow(z / d, 2));
                        break;
                    }
                case net_hFkt.hcylinder:
                    {
                        h = z < d ? 1 : 0;
                        break;
                    }
                case net_hFkt.hcone:
                    {
                        h = z < d ? 1-(z/d) : 0;
                        break;
                    }
                case net_hFkt.hcos:
                    {
                        h = z < d ? Math.Cos((z/d)*(Math.PI/2)) : 0;
                        break;
                    }
            }
            return h;
        }
        #endregion
    }
}
