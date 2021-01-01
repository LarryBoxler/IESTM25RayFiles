using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IESTM25RayFiles.Tests
{
    public static class Helpers
    {
        public static Byte[] GetFixedSizeByteArrayFromBinaryString(String binary, int fixedsize)
        {
            var list = new List<Byte>();

            foreach (var character in binary)
            {
                list.Add(Convert.ToByte(character));
            }

            if (list.Count < fixedsize)
            {
                for (int i = list.Count; i < fixedsize; i++)
                {
                    list.Add(32);
                }
            }

            return list.ToArray();
        }

        public static string GetTM25DescriptionString(string description)
        {
            string tm25String="";

            if (description.Length < 1000)
                tm25String = description.PadRight(1000, '\0');
            else if (description.Length > 1000)
                tm25String = description.Substring(0, 1000);

            return tm25String;
        }

        public static Stream GetExampleSpectralTableMemoryStream()
        {
            MemoryStream memoryStream = new MemoryStream();

            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                
                //Table 1
                binaryWriter.Write(4);
                binaryWriter.Write(450f);
                binaryWriter.Write(1f);
                binaryWriter.Write(600f);
                binaryWriter.Write(0.25f);
                binaryWriter.Write(700f);
                binaryWriter.Write(0.01f);
                binaryWriter.Write(800f);
                binaryWriter.Write(0.01f);

                //Table 2
                binaryWriter.Write(5);
                binaryWriter.Write(455f);
                binaryWriter.Write(0.25f);
                binaryWriter.Write(500f);
                binaryWriter.Write(1.2f);
                binaryWriter.Write(555f);
                binaryWriter.Write(0.38f);
                binaryWriter.Write(600f);
                binaryWriter.Write(0.22f);
                binaryWriter.Write(655f);
                binaryWriter.Write(0.19f);

                //Table 3
                binaryWriter.Write(2);
                binaryWriter.Write(300f);
                binaryWriter.Write(0.1f);
                binaryWriter.Write(355f);
                binaryWriter.Write(0.5f);
            for (int i = 0; i < 7; i++)
            {
                binaryWriter.Write(0);
            }


                memoryStream.Position = 0;
                return memoryStream;
        }

        public static void ReadSpectralTableBlock(BinaryReader reader, int numberOfTables, ref SpectralTableBlock spectralTableBlock)
        {
            int tableBlockSize = 0;
            spectralTableBlock.SpectralTables = new List<SpectralTable>();
            for (int i = 0; i <numberOfTables; i++)
            {
                SpectralTable table = new SpectralTable();
                table.Data = new List<SpectralData>();
                table.Numberofpairs = reader.ReadInt32();
                tableBlockSize += 4 * ((2 * table.Numberofpairs) + 1);
                for (int j = 0; j < table.Numberofpairs; j++)
                {
                    SpectralDataPair dataPair = new SpectralDataPair();
                    dataPair.Wavelength = reader.ReadSingle();
                    dataPair.RelativeWeight = reader.ReadSingle();
                    table.Data.Add(dataPair);
                }
                spectralTableBlock.SpectralTables.Add(table);
            }

            if (tableBlockSize % 32 != 0)
            {
                int numberToPad = (((tableBlockSize / 32)+1)*32 - tableBlockSize)/4;
                for (int i = 0; i < numberToPad; i++)
                {
                    reader.ReadSingle();
                    spectralTableBlock.SpectralTables[numberOfTables - 1].Data.Add(new SpectralPadding());
                }
            }
        }
    }
}
