﻿using System;
using System.Diagnostics.Contracts;

using DigitR.Core.NeuralNetwork.Primitives;

namespace DigitR.Core.NeuralNetwork.Cnn.Primitives
{
    public class CnnLayer : ILayer<CnnNeuron>
    {
        private readonly CnnNeuron[] neurons;
        private readonly CnnWeight[] weights;

        public CnnLayer(int neuronsCount)
        {
            Contract.Requires<ArgumentException>(neuronsCount > 0);

            neurons = new CnnNeuron[neuronsCount];
            weights = new CnnWeight[neuronsCount];
        }

        public bool IsFirst
        {
            get;
            private set;
        }

        public bool IsLast
        {
            get;
            private set;
        }

        public CnnNeuron[] Neurons
        {
            get
            {
                return neurons;
            }
        }

        public CnnWeight[] Weights
        {
            get
            {
                return weights;
            }
        }

        public void Calculate()
        {
        }

        public void ConnectToLayer(ILayer<CnnNeuron> layer)
        {
            throw new NotImplementedException();
        }
    }
}
