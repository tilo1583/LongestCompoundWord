using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    public interface ICompoundWordFinder
    {
        string LongestCompoundWord { get; set; }
        string SecondLongestWord { get; set; }
        int NumberOfCompoundWords { get; set; }

        void ProcessCompoundWords(List<string> inputStrings);
    }
}
