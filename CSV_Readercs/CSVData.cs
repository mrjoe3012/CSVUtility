using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVUtility
{
    /// <summary>
    /// A structure representing all of the data stored in a csv file (lines that each contain any amount of columns)
    /// </summary>
    public struct CSVData : IEnumerable<CSVLine>
    {
        /// <summary>
        /// Returns the lines stored in this object. 
        /// </summary>
        public List<CSVLine> Lines
        {
            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
            }
        }
        /// <summary>
        /// Stores the lines.
        /// </summary>
        private List<CSVLine> _lines;

        /// <summary>
        /// returns the amount of lines in the object.
        /// </summary>
        public int LineCount
        {
            get
            {
                return _lines.Count;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lines">An array of lines to initialize
        /// data with.</param>
        public CSVData(CSVLine[] lines)
        {
            this._lines = new List<CSVLine>();

            AddLines(lines);
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">Data to initialize with.</param>
        public CSVData(CSVData data)
        {
            this._lines = new List<CSVLine>();

            AddData(data);
        }

        /// <summary>
        /// Adds a line to the object.
        /// </summary>
        /// <param name="line">The line to be added.</param>
        public void AddLine(CSVLine line)
        {
            if (_lines == null)
                _lines = new List<CSVLine>(); // intialize the list of lines if it hasn't already been initialized

            _lines.Add(line); // add the line, done through a procedure to aid encapsulation.
        }
        /// <summary>
        /// Adds lines from a CSVData structure.
        /// </summary>
        /// <param name="dataToAdd">The data to add.</param>
        public void AddData(CSVData dataToAdd)
        {
            foreach(CSVLine line in dataToAdd)
            {
                AddLine(line);
            }
        }
        /// <summary>
        /// Add lines from an array of CSVLines
        /// </summary>
        /// <param name="linesToAdd"></param>
        public void AddLines(CSVLine[] linesToAdd)
        {
            foreach(CSVLine line in linesToAdd)
            {
                AddLine(line);
            }
        }

        /// <summary>
        /// Indexer for line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public CSVLine this[int line]
        {
            get
            {
                return _lines[line];
            }
            set
            {
                _lines[line] = value;
            }
        }

        /// <summary>
        /// Enumrator for csv data, returns each line stored in the list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CSVLine> GetEnumerator()
        {
            foreach(CSVLine line in _lines)
            {
                yield return line;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
