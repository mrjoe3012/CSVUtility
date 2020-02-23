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
    /// An object that reads a CSV file and stores the contained data.
    /// </summary>
    class CSVReader : CSVUtil
    {
        protected List<Char> _ignoreList;
        /// <summary>
        /// A list of characters that the reader will ignore if they are present
        /// in the file. (public get & set)
        /// </summary>
        public List<Char> IgnoreList
        {
            get
            {
                return _ignoreList;
            }
            set
            {
                _ignoreList = value;
            }
        }

        /// <summary>
        /// A default constructor, used to call the base constructor from any user created derrived classes.
        /// </summary>
        public CSVReader() : base() // calls base constructor.
        {
            _ignoreList = new List<char>(); // initialising list
        }

        public CSVReader(string path) : this()
        {
            _currentPath = path;
        }

        /// <summary>
        /// Reads the data from the file in the specified path.
        /// </summary>
        public virtual void Read()
        {

            if (this.Path == "")
                throw (new MissingPathException());

            string[] lines;


            lines = File.ReadAllLines(this._currentPath); // reads lines from files
            this._data = FormatData(this._seperationChar, lines); // formats the data and assigns _data to it.

        }

        /// <summary>
        /// Formats data by seperating by the seperation characters and placing the individual values
        /// into their own strings.
        /// </summary>
        /// <param name="seperationChar">The character to be used to format the string</param>
        /// <param name="lines">The lines to be formatted</param>
        /// <returns></returns>
        protected virtual CSVData FormatData(char seperationChar, string[] lines)
        {
            CSVData data = new CSVData(); // the data that will be returned

            foreach (string line in lines) // loop through each line in the provided lines
            {
                string[] formattedLine = new string[CountColumnsInLine(line)]; // the line in the proper format, initalized.

                if (formattedLine.Length > 0) // if there were no columns in the line, ignore it.
                {

                    int column = 0; // a counter for indexing columns
                    string currentValue = ""; // intializing the current value to null.

                    // loop through each character in the line
                    foreach (char c in line)
                    {
                        if (c == this._seperationChar) // if we have reached the seperation character, send the characters in the buffer to the string ad clear the buffer.
                        {
                            formattedLine[column] = currentValue;
                            currentValue = "";
                            column++; // advancing to the next column
                        }
                        else
                        {
                            if(!_ignoreList.Contains(c)) // only add the character if it is not to be ignored.
                                currentValue += c; // add this character (not the seperation character) to the buffer.
                        }
                    }

                    formattedLine[column] = currentValue; // add the final character to the buffer, since the loop will exit before it is added.

                    data.AddLine(new CSVLine(formattedLine)); // add the formatted line to the data structure

                }
            }

            return data; // return the new data structure filled with formatted lines.
        }
        /// <summary>
        /// returns that amount of columns in the line
        /// </summary>
        /// <param name="line">the line in which to count columns</param>
        /// <returns></returns>
        protected virtual int CountColumnsInLine(string line)
        {
            int columns = 1; // a counter for columns, assumed that each line has at least 1 column.

            if(line.Length == 0) // if there is nothing in the line, return 0 as there are no columns.
                return 0;

            foreach(char c in line) // loop through each character in the entire line
            {
                if (c == this._seperationChar) // increment the column counter every time the seperation character is encountered in the line
                    columns++;
            }

            return columns; // return the column count.
        }
        /// <summary>
        /// Re reads the file for any changed.
        /// </summary>
        public virtual void Refresh()
        {
            this.ClearData(); // clears the data first, before reading the file.
            Read();
        }

    }
}
