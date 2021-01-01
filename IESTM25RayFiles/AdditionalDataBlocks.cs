using System;
using System.Collections.Generic;
using System.Text;

namespace IESTM25RayFiles
{
    public class AdditionalRayDataColumnLabelsBlock
    {
        public List<string> ColumnNames { get; set; }
        public bool CheckAdditionalRayDataColumnisValid()
        {
            var totalsize = 0;
            foreach (var columname in ColumnNames)
            {
                if (String.IsNullOrEmpty(columname))
                    throw new InvalidTM25Exception("Additional Column Names Not Present");
                totalsize += columname.Length;
            }

            if (totalsize != ColumnNames.Count * 512)
                throw new InvalidTM25Exception("Additional Ray Data Column Block size not correct multiple of 512");

            return true;
        }
    }

    public class AdditionalTextBlock
    {
        public string AdditionalText { get; set; }
    }
}
