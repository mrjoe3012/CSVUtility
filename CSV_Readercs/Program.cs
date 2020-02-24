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
        CSVLine line1 = new CSVLine(new string[4] { 
            "Hello","This", "Is", "A"
        });
        CSVLine line2 = new CSVLine(new string[3] { 
            "2","5", "7"
        });
        CSVLine line3 = new CSVLine(new string[1] {
            "Goodbye"} );

        CSVData csvData = new CSVData();

        csvData.AddLine(line1);
        csvData.AddLine(line2);
        csvData.AddLine(line3);

        CSVWriter writer = new CSVWriter("../../data.txt", csvData);

        writer.Write();
      
        return 0;
    }

}

