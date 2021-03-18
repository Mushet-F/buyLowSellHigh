using System;
using System.Linq;
using System.IO;

namespace Computershare
{
    class Program
    {
        static void Main(string[] args)
        {
            string extractData = "Y";

            while (extractData == "Y")
            {
                try
                {
                    Console.WriteLine("Please provide the directory path to data sample: ");
                    string filePath = Console.ReadLine();
                    string rawData = File.ReadAllText(filePath);

                    double[] pricesDataSet = rawData.Split(',').Select(n => Convert.ToDouble(n)).ToArray();

                    Stock month = new Stock(pricesDataSet);

                    Console.WriteLine(month.getBestTrade(month.Prices));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Would you like to process another data sample? Please respond with (Y/N)");
                extractData = Console.ReadLine();

                while((extractData != "Y") && (extractData != "N"))
                {
                    Console.WriteLine("Please respond with (Y/N)");
                    extractData = Console.ReadLine();
                }  

            }

        }
    }
}