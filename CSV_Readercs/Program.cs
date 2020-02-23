using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSVUtility;


class Program
{

    public static int Main(string[] args)
    {

        CSVWriter writer = new CSVWriter();

        writer.Path = "../../data.txt";

        CSVData dataToWrite = new CSVData();

        string[] string1 = new string[3]
        {
            "1", "2", "3"
        };

        string[] string2 = new string[2]
        {
            "Hello", "World"
        };

        string[] string3 = new string[2]
        {
            "Goodbye",
            "World"
        };

        CSVLine line1 = new CSVLine(string1);
        CSVLine line2 = new CSVLine(string2);
        CSVLine line3 = new CSVLine(string3);

        dataToWrite.AddLine(line1);
        dataToWrite.AddLine(line2);
        dataToWrite.AddLine(line3);

        writer.SetData(dataToWrite);

        writer.Write();

        return 0;
    }

}

