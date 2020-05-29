using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace app_simulated_config
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Iterating the config file values and attributes...");
            Console.WriteLine("==================================================");
            XElement xConfig = XElement.Load("app.simulated.config");
            foreach (var element in xConfig.DescendantsAndSelf())
            {
                Console.WriteLine(element.Name);
                foreach (var attribute in element.Attributes())
                {
                    Console.WriteLine("\t" + attribute.Name + "," + attribute.Value);
                }
            }

            XElement xel =
                xConfig
                .DescendantsAndSelf()
                .FirstOrDefault(match => 
                    (match.Attribute("key") != null) && 
                    (match.Attribute("key").Value == "sheetNumber"));


            Console.WriteLine();
            Console.WriteLine("Finding a value using matching conditions.");
            Console.WriteLine("==========================================");
            Console.WriteLine(
                "The value of 'sheetNumber' is " +
                xel.Attribute("value").Value
             );

            // Pause
            Console.ReadKey();
        }
    }
}
