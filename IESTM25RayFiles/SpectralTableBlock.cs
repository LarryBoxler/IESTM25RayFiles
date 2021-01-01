using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IESTM25RayFiles
{
    public class SpectralTableBlock
    {
        public List<SpectralTable> SpectralTables { get; set; }
        public bool CheckSpectralTableisValid()
        {
            int tableSize = 0;
            for (int i = 0; i < SpectralTables.Count; i++)
            {
                tableSize += System.Runtime.InteropServices.Marshal.SizeOf(SpectralTables[i].Numberofpairs.GetType());
                for (int j = 0; j < SpectralTables[i].Data.Count; j++)
                {
                    tableSize += SpectralTables[i].Data[j].Size;
                }
            }

            if (tableSize%32 != 0)
                return false;
            return true;
        }
    }

    public class SpectralTable 
    {
        public int Numberofpairs { get; set; }
        public List<SpectralData> Data { get; set; }
    }

    public class SpectralDataPair : SpectralData
    {
        public override float Wavelength { get; set; }
        public override float RelativeWeight { get; set; }
        public override int Size => 8;
    }

    public class SpectralPadding : SpectralData
    {
        public override int Padding { get; set; } = 0;
        public override int Size => 4;
    }

    public abstract class SpectralData
    {
        public virtual float Wavelength { get; set; }
        public virtual float RelativeWeight { get; set; }
        public virtual int Padding { get; set; }
        public virtual int Size => 0;
    }



}
