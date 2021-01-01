using System;
using System.Collections.Generic;
using System.Text;

namespace IESTM25RayFiles
{
    [System.Serializable]
    public class InvalidTM25Exception : SystemException
    {
        private static readonly string DefaultMessage = "File is not a valid TM25 file";

        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public InvalidTM25Exception() : base(DefaultMessage) { }
        public InvalidTM25Exception(string message) : base(message) { }
        public InvalidTM25Exception(string message, System.Exception innerException)
        : base(message, innerException) { }

        public InvalidTM25Exception(string fieldname, string fieldvalue) : base(DefaultMessage)
        {
            FieldName = fieldname;
            FieldValue = fieldvalue;
        }

        public InvalidTM25Exception(string fieldname, string fieldvalue, System.Exception innerException) : base(DefaultMessage, innerException)
        {
            FieldName = fieldname;
            FieldValue = fieldvalue;
        }

        protected InvalidTM25Exception(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
