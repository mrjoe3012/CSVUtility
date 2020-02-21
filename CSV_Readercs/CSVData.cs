﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVUtility
{
    /// <summary>
    /// A structure representing all of the data stored in a csv file (lines that each contain any amount of columns)
    /// </summary>
    struct CSVData
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
        /// Adds a line to the object.
        /// </summary>
        /// <param name="line">The line to be added.</param>
        public void AddLine(CSVLine line)
        {
            if (_lines == null)
                _lines = new List<CSVLine>(); // intialize the list of lines if it hasn't already been initialized

            _lines.Add(line); // add the line, done through a procedure to aid encapsulation.
        }

    }
}
