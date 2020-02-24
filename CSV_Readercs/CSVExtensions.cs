using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVUtility;

namespace Extensions
{
    static class CSVExtensions
    {
        public static int[][] ConvertToInt(this CSVData data)
        {
            int[][] newData = new int[data.LineCount][];

            int j = 0;

            foreach(CSVLine oldLine in data)
            {
                newData[j] = new int[oldLine.ColumnCount];

                for (int i = 0; i < oldLine.ColumnCount; i++)
                {
                    newData[j][i] = Convert.ToInt32(oldLine[i]);
                }

                j++;

            }

            return newData;

        }
    }
}
