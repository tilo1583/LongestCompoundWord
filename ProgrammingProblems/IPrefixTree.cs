using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    public interface IPrefixTree
    {
        bool Contains(string inputString);
        void Insert(string inputString);
        List<string> GetPrefixesOfGivenString(string inputString);
    }
}
