using System;
using System.Reflection;

namespace IESTM25RayFiles
{
    public struct DescriptionHeaderBlock
    {
        public string NameOFLightSource;
        public string ManufacturerOfLightSource;
        public string CreatorofOpticalLightSourceModel;
        public string CreatorOfRayFile;
        public string Equipment_Software_Used;
        public string CameraInformation;
        public string LightSourceOperationInformation;
        public string AdditionalInformation;
        public string DataReferencetoSourceGeometry;
        
        public bool CheckDescriptionBlockisValid()
        {
            Type type = typeof(DescriptionHeaderBlock);
            object fieldValue;
            int total_size = 0;

            foreach (FieldInfo fi in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                fieldValue = fi.GetValue(this);
                if (fieldValue != null && !string.IsNullOrEmpty(fieldValue.ToString()))
                {
                    string arr = (string)fieldValue;
                    total_size += arr.Length*4;
                }
            }

            if (total_size == 36000)
                return true;
            return false;
        }
    }   
}
