﻿using DigitR.Core.InputProvider;

namespace NeuralNetwork.Cnn.Test.Processing.Mock
{
    public class InputPatternMock : IInputPattern<double[]>
    {
        public InputPatternMock(double[] source)
        {
            Source = source;
        }

        public double[] Source { get; }
    }
}