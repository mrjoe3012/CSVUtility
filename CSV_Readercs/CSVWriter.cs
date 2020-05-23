using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CSVErrors;

namespace CSVUtility
{
    /// <summary>
    /// A class for writing data (formatted as CSV) to a specified file.
    /// </summary>
    public class CSVWriter : CSVUtil
    {
        /// <summary>
        /// Default constructor - empty for modularity so that base can be called if classes are derrived from
        /// this class.
        /// </summary>
        public CSVWriter() : base()
        {

        }
        /// <summary>
        /// Sets data and calls default constructor.
        /// </summary>
        /// <param name="data">The data to write.</param>
        public CSVWriter(CSVLine[] data) : this()
        {
            this.SetData(data);
        }
        /// <summary>
        /// Sets data and calls default constructor.
        /// </summary>
        /// <param name="data">The data to write.</param>
        public CSVWriter(CSVData data) : this()
        {
            this.SetData(data);
        }
        /// <summary>
        /// Sets path and calls default constructor.
        /// </summary>
        /// <param name="path">The path of the data file</param>
        public CSVWriter(string path) : this()
        {
            this._currentPath = path;
        }
        /// <summary>
        /// Sets path and data and calls default constructor.
        /// </summary>
        /// <param name="path">Path of data file</param>
        /// <param name="data">Array of CSVLines which the stored
        /// CSVData will be assigned to.</param>
        public CSVWriter(string path, CSVLine[] data) : this()
        {
            this._currentPath = path;
            this.SetData(data);
        }
        /// <summary>
        /// Sets path and data and calls default constructor.
        /// </summary>
        /// <param name="path">Path of data file</param>
        /// <param name="data">CSVData to write to file</param>
        public CSVWriter(string path, CSVData data) : this()
        {
            this._currentPath = path;
            this.SetData(data);
        }

        /// <summary>
        /// Sets the CSVData to be written.
        /// </summary>
        /// <param name="data">The data to write.</param>
        public virtual void SetData(CSVData data)
        {
            this._data = data;
        }
        /// <summary>
        /// Sets the CSVData to be written.
        /// </summary>
        /// <param name="data">The data to write.</param>
        public virtual void SetData(CSVLine[] data)
        {
            this._data = new CSVData();
            foreach (CSVLine line in data)
            {
                this._data.AddLine(line);
            }
        }
        /// <summary>
        /// Adds data.
        /// </summary>
        /// <param name="data">The data to add</param>
        public virtual void AddData(CSVData data)
        {
            try
            {
                foreach (CSVLine line in data.Lines)
                {
                    _data.AddLine(line);
                }
            }
            catch(NullReferenceException e)
            {
                throw (new MissingDataException());
            }
        }
        /// <summary>
        /// Adds data.
        /// </summary>
        /// <param name="data">The data to add</param>
        public virtual void AddData(CSVLine[] data)
        {
            try
            {
                foreach (CSVLine line in data)
                {
                    _data.AddLine(line);
                }
            }
            catch(NullReferenceException e)
            {
                throw (new MissingDataException());
            }
        }

        /// <summary>
        /// Writes the stored CSV data to the specified file through "Path"
        /// </summary>
        public virtual void Write()
        {
            if(this.Path == "")
            {
                throw (new MissingPathException());
            }

            try
            {
                if (this._data.LineCount == 0)
                {
                    throw (new MissingDataException());
                }
            }
            catch(NullReferenceException e)
            {
                throw (new MissingDataException());
            }

            string[] lines = new string[this._data.LineCount]; // storing the lines that will be written to the file

            int index = 0; // index counter

            foreach(CSVLine line in this._data.Lines)
            {

                for (int i = 0; i < line.ColumnCount; i++) // loop for every column in this line
                {
                    lines[index] += line[i]; // add the column's value to the "lines" string

                    if(i != line.ColumnCount-1)
                    {
                        lines[index] += this._seperationChar; // only add the seperation character if we aren't on the last column.
                    }
                }

                index++; // increment every iteration
            }

            File.WriteAllLines(this._currentPath, lines); // write the "lines" string to the file.

        }
        /// <summary>
        /// Clears the file at "Path".
        /// </summary>
        public virtual void WipeFile()
        {
            File.WriteAllText(this._currentPath, "");
        }

    }
}
