using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using nn_math;

namespace nn_som
{
    [Serializable]
    public class Neuron : IComparable<Neuron>, IComparer<Neuron>
    {
        private BmNeuron n_BmNeuron;

        private Vector n_pos;
        private SortedList<int, RecordSet> n_record;

        private Vector n_WeightVec;

        public Vector Position
        {
            get { return n_pos; }
            set { n_pos = value;}
        }

        public Vector WeightVec
        {
            get { return n_WeightVec; }
            set { n_WeightVec = value; }
        }

        public SortedList<int,RecordSet> Records
        {
            get { return n_record; }
            set { n_record = value; }
        }

        public int DistanceToBm
        {
            get { return Convert.ToInt32(((Vector)(Position - n_BmNeuron.Position)).AbsSumNorm()); }
        }

        /// <summary>
        /// Konstruktor für ein Kohonen-Neuron
        /// </summary>
        /// <param name="position">Position in der Kohonen-Map</param>
        /// <param name="WeightVec">Gewichtsvektor, Abbildung von den Inputs auf das Neuron</param>
        /// <param name="BmNeuron">Aktuelles Bestmatching Neuron, zur Distanzberechnung</param>
        public Neuron(Vector position, Vector WeightVec, BmNeuron BmNeuron)
        {
            n_pos = position;
            n_record = new SortedList<int,RecordSet>();
            n_WeightVec = WeightVec;
            n_BmNeuron = BmNeuron;
        }

        public int CompareTo(Neuron neuron)
        {
            return DistanceToBm.CompareTo(neuron.DistanceToBm);
        }

        public int Compare(Neuron x, Neuron y)
        {
            return x.DistanceToBm - y.DistanceToBm;
        }

        public void BindRec(RecordSet data)
        {
            if (n_record.ContainsKey(data.Key))
            {
                n_record[data.Key] = data;
            }
            else
            {
                n_record.Add(data.Key, data);
            }
        }

        public void RemoveRec(RecordSet data)
        {
            n_record.Remove(data.Key);
        }

    }
    [Serializable]
    public class BmNeuron
    {
        private Neuron bm_Neuron;

        public Vector Position
        {
            get { return bm_Neuron.Position; }
        }

        public Neuron BM_Neuron
        {
            set { bm_Neuron = value; }
            get { return bm_Neuron; }
        }

        /// <summary>
        /// Konstruktor für das Best matching Neuron
        /// </summary>
        /// <param name="position">Position des best matching Neurons</param>
        public BmNeuron(Neuron neuron)
        {
            bm_Neuron = neuron;
        }
    }
}
