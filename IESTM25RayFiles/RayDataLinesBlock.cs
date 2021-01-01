using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace IESTM25RayFiles
{
    public class RayDataLinesBlock
    {
        public float[][] Rays { get; set; }
        public string[] RayDataMembers { get; set; }
    }
    
    public struct RayData
    {
        public float X_Position;
        public float Y_Position;
        public float Z_Position;
        public float X_Direction_Cosine;
        public float Y_Direction_Cosine;
        public float Z_Direction_Cosine;
        public float? RadiantFlux_StokesS0;
        public float? Wavelength;
        public float? YTristimulus_LuminousFlux;
        public float? StokesS1;
        public float? StokesS2;
        public float? SotkesS3;
        public float? XTristimulus;
        public float? ZTristimulus;
        public int? SpectrumIndex;
        public float[] AdditionalUserDefinedData;
    }
}
