﻿using DigitR.Core.NeuralNetwork.InputProvider;

namespace DigitR.NeuralNetwork.InputProvider.Processing.Bitmap
{
    public class BitmapInputPattern : IInputPattern<double[]>
    {
        public BitmapInputPattern(double[] source)
        {
            Source = source;
        }

       public double[] Source
        {
            get;
            private set;
        }
    }
}
