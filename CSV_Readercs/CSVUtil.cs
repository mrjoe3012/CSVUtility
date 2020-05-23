using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVErrors;

namespace CSVUtility
{
    /// <summary>
    /// a base class for both the writer and reader objects.
    /// </summary>
    public abstract class CSVUtil
    {
        /// <summary>
        /// the character which determines seperation of values.
        /// </summary>
        protected char _seperationChar;
        /// <summary>
        /// property for _seperationChar (public get and set)
        /// </summary>
        public char SeperationChar
        {
            get
            {
                return _seperationChar;
            }
            set
            {
                _seperationChar = value;
            }
        }

        /// <summary>
        /// property for _currentPath (public get and set)
        /// </summary>
        public string Path
        {
            get
            {
                return _currentPath;
            }
            set
            {
                _currentPath = value;
            }
        }
        /// <summary>
        /// the location of the data file.
        /// </summary>
        protected string _currentPath;

        /// <summary>
        /// A reference to the data held by the object.
        /// </summary>
        protected CSVData _data;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CSVUtil() // default constructor
        {
            _data = new CSVData(); // initialize data
            _currentPath = ""; // initialize path
            _seperationChar = ','; // set seperation character to default (comma)
        }

        /// <summary>
        /// Returns the stored data as an array of lines.
        /// </summary>
        /// <returns></returns>
        public virtual CSVLine[] GetDataAsLines() // returns an array of csv lines; data stored in this object.
        {
            CSVLine[] data = new CSVLine[0];

            try
            {
                data = new CSVLine[_data.LineCount]; // initialize size of data to the amount of lines in _data
            }
            catch(NullReferenceException e)
            {
                throw (new MissingDataException());
            }

            if(_data.LineCount == 0)
                throw (new MissingDataException());

            int index = 0; // counter variable for indexing the lines in _data

            
            foreach(CSVLine line in _data.Lines) // loop through every line stored in _data and populate data array.
            {
                data[index] = line;
                index++;
            }

            return data; // return the array of lines. Doesn't return original data structure to make it more difficult 
                         //to accidentally change the data structure and break the object.
        }
        /// <summary>
        /// Returns data as CSVData
        /// </summary>
        /// <returns>Data stored in object.</returns>
        public virtual CSVData GetData()
        {
            return this._data;
        }

        /// <summary>
        /// Resets the stored data in the object.
        /// </summary>
        public virtual void ClearData()
        {
            _data = new CSVData(); // reinitializes data structure.
        }

    }

}
