﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

namespace DigitR.Core.InputProvider.Mnist
{
    public class MnistImageInputProvider : IImageInputProvider<byte, byte[]>
    {
        private readonly string labelPath;
        private readonly string sourcePath;

        public MnistImageInputProvider(
            string labelPath,
            string sourcePath)
        {
            Contract.Requires<ArgumentException>(labelPath != null);
            Contract.Requires<ArgumentException>(sourcePath != null);

            this.labelPath = labelPath;
            this.sourcePath = sourcePath;
        }

        public IEnumerable<object> Retrieve()
        {
            using (FileStream labelsStream = new FileStream(labelPath, FileMode.Open))
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
            using (BinaryReader labelsReader = new BinaryReader(labelsStream))
            using (BinaryReader sourceReader = new BinaryReader(sourceStream))
            {
                MnistHeaderInfo header = ReadHeader(sourceReader, labelsReader);

                for (int imageIndex = 0; imageIndex < header.ImagesCount; imageIndex++)
                {
                    yield return new MnistImagePattern(
                        labelsReader.ReadByte(),
                        sourceReader.ReadBytes(MnistImagePattern.MnistPatternSizeInBytes));
                }
            }
        }

        private MnistHeaderInfo ReadHeader(BinaryReader sourceReader, BinaryReader labelsReader)
        {
            sourceReader.BaseStream.Seek(4, SeekOrigin.Begin);

            int imagesCount = ReverseBytes(sourceReader.ReadInt32());
            int rowsCount = ReverseBytes(sourceReader.ReadInt32());
            int columnsCount = ReverseBytes(sourceReader.ReadInt32());

            labelsReader.BaseStream.Seek(4, SeekOrigin.Begin);

            int labelsCount = ReverseBytes(labelsReader.ReadInt32());

            return new MnistHeaderInfo(imagesCount, rowsCount, columnsCount, labelsCount);
        }

        private static int ReverseBytes(int number)
        {
            return (number & 0x000000FF) << 24
                   | (number & 0x0000FF00) << 8
                   | (number & 0x00FF0000) >> 8
                   | ((int)(number & 0xFF000000)) >> 24;
        }
    }
}