using System;
using System.Reflection;

namespace IESTM25RayFiles
{
    public struct KnownDataFlagBlock
    {
        public int PositionFlag;
        public int DirectionFlag;
        public int RadiantFlux_StokesS0Flag;
        public int WavelengthFlag;
        public int LuminousFlux_TristimulusYFlag;
        public int StokesFlag;
        public int TristimulusFlag;
        public int SpetrumIndexFlag;

        public bool CheckKnownDataFlagBlockisValid()
        {
            Type type = typeof(KnownDataFlagBlock);
            object fieldValue;
            int total_size = 0;

            foreach (FieldInfo fi in type.GetFields(BindingFlags.Instance | BindingFlags.Public ))
            {
                fieldValue = fi.GetValue(this);
                if (fieldValue != null && !string.IsNullOrEmpty(fieldValue.ToString()))
                {
                    total_size += System.Runtime.InteropServices.Marshal.SizeOf(fieldValue);
                }
            }

            if (total_size == 32)
                return true;
            return false;
        }
    }
}