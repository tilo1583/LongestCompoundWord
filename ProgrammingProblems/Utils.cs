using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    public class Utils
    {
        public static string GetSuffix(string main, string prefix)
        {
            int length = prefix.Length;
            return main.Substring(length);
        }
    }
}
