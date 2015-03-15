﻿using System;
using System.Collections.Generic;
using System.Linq;

using DigitR.Core.NeuralNetwork.Algorithms;
using DigitR.Core.NeuralNetwork.Primitives;

namespace DigitR.Core.NeuralNetwork.Cnn.Primitives
{
    public class CnnNeuron : INeuron<double, CnnConnection>
    {
        private readonly IOutputAlgorithm<double, CnnConnection> outputAlgorithm;

        public CnnNeuron(IOutputAlgorithm<double, CnnConnection> outputAlgorithm)
        {
            if (outputAlgorithm == null)
            {
                throw new ArgumentNullException("outputAlgorithm");
            }

            this.outputAlgorithm = outputAlgorithm;
        }

        private readonly IList<CnnConnection> connections = new List<CnnConnection>(); 

        public IList<CnnConnection> Inputs
        {
            get
            {
                return connections;
            }
        }

        public double Output
        {
            get;
            set;
        }

        /// <summary>
        /// Performs output calculation for this neuron.
        /// </summary>
        public double Calculate()
        {
            return outputAlgorithm.Calculate(Inputs.ToList());
        }
    }
}
