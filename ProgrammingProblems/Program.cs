using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(args[0]))
            {
                throw new ArgumentNullException("Usage - Enter the complete path of the file to be processed");
            }

            string[] lines = File.ReadAllLines(args[0]);
            var listOfStrings = new List<string>();
            listOfStrings.AddRange(lines);

            ICompoundWordFinder compoundWordFinder = new PrefixTreeLongestCompoundWordFinder();

            compoundWordFinder.ProcessCompoundWords(listOfStrings);

            Console.WriteLine(string.Format("The longest compound word is {0}",compoundWordFinder.LongestCompoundWord));
            Console.WriteLine(string.Format("The second longest compound word is {0}", compoundWordFinder.SecondLongestWord));
            Console.WriteLine(string.Format("Number of compound words {0}", compoundWordFinder.NumberOfCompoundWords));
            Console.ReadKey();
        }
    }
}
