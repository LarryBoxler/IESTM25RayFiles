using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace IESTM25RayFiles
{
    public static class TM25HelperFunctions
    {
        public static int FindNumberOfRayDataFields(KnownDataFlagBlock dataFlagBlock, FileHeaderBlock fileHeaderBlock)
        {
            Type type = typeof(KnownDataFlagBlock);
            int numberofitems = 0;

            foreach (FieldInfo fi in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                if (fi.Name == "PositionFlag" || fi.Name == "DirectionFlag" || fi.Name == "StokesFlag")
                {
                    if ((int)fi.GetValue(dataFlagBlock) == 1)
                        numberofitems += 3;
                }
                else if (fi.Name == "TristimulusFlag")
                {
                    if ((int)fi.GetValue(dataFlagBlock) == 1)
                        numberofitems += 2;
                }
                else
                {
                    if ((int)fi.GetValue(dataFlagBlock) == 1)
                        numberofitems++;
                }
            }

            if (fileHeaderBlock.NumberOfAdditionalRayDataItemsPerRay > 0)
                numberofitems += fileHeaderBlock.NumberOfAdditionalRayDataItemsPerRay;

            return numberofitems;
        }

        public static string[] GetListofRayDataFieldsPresent(KnownDataFlagBlock dataFlagBlock, FileHeaderBlock fileHeaderBlock, AdditionalRayDataColumnLabelsBlock additionalRayDataColumn = null)
        {
            Type type = typeof(KnownDataFlagBlock);
            string[] rayitems = new string[FindNumberOfRayDataFields( dataFlagBlock,  fileHeaderBlock)];
            var position = 0;

            foreach (FieldInfo fi in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                if (fi.Name == "PositionFlag"  && (int)fi.GetValue(dataFlagBlock) == 1)
                {
                    rayitems[0] = "X Position";
                    rayitems[1] = "Y Position";
                    rayitems[2] = "Z Position";
                    position += 3;
                }
                if (fi.Name == "PositionFlag" && (int)fi.GetValue(dataFlagBlock) == 1)
                {   
                    rayitems[3] = "X Direction Cosine";
                    rayitems[4] = "Y Direction Cosine";
                    rayitems[5] = "Z Direction Cosine";
                    position += 3;
                }
                if (fi.Name == "RadiantFlux_StokesS0Flag" && (int)fi.GetValue(dataFlagBlock) == 1)
                {
                    rayitems[position] = "Radiant Flux/Stokes S0";
                    position += 1;
                }

                if (fi.Name == "WavelengthFlag" && (int)fi.GetValue(dataFlagBlock) == 1)
                {
                    rayitems[position] = "Wavelength";
                    position += 1;
                }

                if (fi.Name == "LuminousFlux_TristimulusYFlag" && (int)fi.GetValue(dataFlagBlock) == 1)
                {
                    rayitems[position] = "LuminousFlux / Tristimulus Y";
                    position += 1;
                }

                if (fi.Name == "StokesFlag" && (int)fi.GetValue(dataFlagBlock) == 1)
                {
                    rayitems[position] = "Stokes S1";
                    rayitems[position+1] = "Stokes S2";
                    rayitems[position+2] = "Stokes S3";
                    position += 3;
                }

                if (fi.Name == "TristimulusFlag" && (int)fi.GetValue(dataFlagBlock) == 1)
                {
                    rayitems[position] = "X Tristimulus";
                    rayitems[position + 1] = "Y Tristimulus";
                    position += 2;
                }

                if (fi.Name == "SpectrumIndexFlag" && (int)fi.GetValue(dataFlagBlock) == 1)
                {
                    rayitems[position] = "Spectrum Index";
                    position += 1;
                }

                if (fileHeaderBlock.NumberOfAdditionalRayDataItemsPerRay > 0)
                {
                    for (int i = 0; i < fileHeaderBlock.NumberOfAdditionalRayDataItemsPerRay; i++)
                    {
                        rayitems[position] = additionalRayDataColumn.ColumnNames[i]; 
                    }
                }
            }
            return rayitems;
        }
    }
}
