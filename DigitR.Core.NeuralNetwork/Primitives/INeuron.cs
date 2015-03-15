﻿using System.Collections.Generic;

namespace DigitR.Core.NeuralNetwork.Primitives
{
    /// <summary>
    /// Provides an interface for abstract neuron.
    /// </summary>
    public interface INeuron<TOutput, TConnection>
    {
        IList<TConnection> Inputs
        {
            get;
        }
            
        TOutput Output
        {
            get;
            set;
        }

        /// <summary>
        /// Performs output calculation for this neuron.
        /// </summary>
        TOutput Calculate();
    }
}
