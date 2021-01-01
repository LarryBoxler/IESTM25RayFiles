using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace IESTM25RayFiles
{
    public struct FileHeaderBlock
    {
       
        public byte[] FileType;
        public int FileVersion;
        public int CreationMethod;
        public float TotalLuminousFlux;
        public float TotalRadiantFlux;
        public ulong NumberOfRays;
        public byte[] FileCreationDateAndTime;
        public int RayStartPosition;
        public int SpectralDataIdentifier;
        public float SingleWavelength;
        public float MinimumWavelength;
        public float MaximumWavelength;
        public int NumberOfSpectralTables;
        public int NumberOfAdditionalRayDataItemsPerRay;
        public int SizeOfAdditionalTextBlock;
        private static readonly byte[] _reserved = new byte[168];

        public bool CheckHeaderBlockisValid()
        {
            Type type = typeof(FileHeaderBlock);
            object fieldValue;
            int total_size=0;

            foreach (FieldInfo fi in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                fieldValue = fi.GetValue(this);

                if (fi.FieldType == typeof(byte[]))
                {
                    byte[] arr = (byte[])fieldValue;
                    total_size += arr.Length;
                }
                
                else if (fieldValue != null && !string.IsNullOrEmpty(fieldValue.ToString()))
                {
                    total_size += System.Runtime.InteropServices.Marshal.SizeOf(fieldValue);
                }
            }

            if (total_size == 256)
                return true;
            return false;
        }
        public string FileTypeToASCII()
        {
            return System.Text.Encoding.ASCII.GetString(FileType);
        }
        public string FileCreationDatetoASCII()
        {
            string pattern = "[^ -~]+";
            Regex reg_exp = new Regex(pattern);
            return reg_exp.Replace(System.Text.Encoding.ASCII.GetString(FileCreationDateAndTime), "");
            //return System.Text.Encoding.UTF32.GetString(FileCreationDateAndTime);
        }
    }
}
