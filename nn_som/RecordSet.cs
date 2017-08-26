using System;
using System.Collections.Generic;
using System.Text;
using nn_math;

namespace nn_som
{
    [Serializable]
    public class RecordSet
    {
        /// <summary>
        /// Fields
        /// </summary>
        private int ds_key;

        private Object ds_Content;

        private Neuron ds_CurrentNeuron;

        private Vector ds_inputVec;

        /// <summary>
        /// Properties
        /// </summary>
        public int Key
        {
            get { return ds_key; }
        }

        public Object Content
        {
            get { return ds_Content; }
            set { ds_Content = value; }
        }

        public Neuron CurrentNeuron
        {
            get { return ds_CurrentNeuron; }
        }

        public Vector InputVec
        {
            get { return ds_inputVec; }
            set { ds_inputVec = value; }
        }


        /// <summary>
        /// Simple Konstruktor
        /// </summary>
        /// <param name="key"></param>
        public RecordSet(int key)
        {
            ds_key = key;
        }

        public RecordSet(int key, Object content) : this(key)
        {
            ds_Content = content;
            ds_CurrentNeuron = null;
        }

        public RecordSet(int key, Object content, Vector input)
            : this(key, content)
        {
            ds_inputVec = input;
        }

        public void AddRecordSetToNeuron(Neuron neuron)
        {
            if (ds_CurrentNeuron != null)
                ds_CurrentNeuron.RemoveRec(this);
            ds_CurrentNeuron = neuron;
            ds_CurrentNeuron.BindRec(this);
        }
    }
}
