using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVUtility
{
    /// <summary>
    /// A structure that represents a line of a CSV
    /// file populated with columns (strings)
    /// </summary>
    struct CSVLine : IEnumerable<string>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">An array of strings to represent the columns in the
        /// csv file.</param>
        public CSVLine(string[] data)
        {
            this._columns = data;
            this._columnsCount = data.Length;
        }

        /// <summary>
        /// Returns the indexed column.
        /// </summary>
        public string this[int column]
        {
            get
            {
                return _columns[column];
            }
            set
            {
                _columns[column] = value;
            }
        }

       

        /// <summary>
        /// Stores each column in the CSV file.
        /// </summary>
        private string[] _columns;

        /// <summary>
        /// Returns the amount of columns.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return _columnsCount;
            }
        }
        /// <summary>
        /// The amount of columns in this line.
        /// </summary>
        private int _columnsCount;

        /// <summary>
        /// Enumerator for csvline, returns each column in the line.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> GetEnumerator()
        {
            foreach(string column in _columns)
            {
                yield return column;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
