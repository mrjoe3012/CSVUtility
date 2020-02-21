using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVErrors
{
    class MissingDataException : Exception
    {
        public MissingDataException() : base("No data was provided. Data is empty.")
        {

        }
    }

    class MissingPathException : Exception
    {
        public MissingPathException() : base("No path was provided.")
        {

        }
    }
}
