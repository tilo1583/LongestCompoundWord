using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    public class PrefixTreeLongestCompoundWordFinder : ICompoundWordFinder
    {
        public string LongestCompoundWord { get; set; }
        public string SecondLongestWord { get; set; }
        public int NumberOfCompoundWords { get; set; }
        private IPrefixTree PrefixTree;
        private Queue<Tuple<string, string>> Queue;

        public PrefixTreeLongestCompoundWordFinder()
        {
            PrefixTree = new PrefixTree();
            Queue = new Queue<Tuple<string, string>>();
        }
        
        public void ProcessCompoundWords(List<string> inputStrings)
        {
            var sortedWords = inputStrings.OrderBy(s => s.Length);

            foreach (string inputString in sortedWords)
            {
                EnqueueSuffixesOfInputString(inputString);
                this.PrefixTree.Insert(inputString);
            }

            ProcessQueue();
        }

        /// <summary>
        /// Processes the queue, to get the longest word, second longest compound word 
        /// and gets the number of compound words
        /// </summary>
        private void ProcessQueue()
        {
            while (this.Queue.Count > 0)
            {
                var tuple = this.Queue.Dequeue();
                string inputString = tuple.Item1;
                string suffix = tuple.Item2;
                int maxLength = 0;
                int secondMaxLength = 0;

                if (this.PrefixTree.Contains(suffix))
                {
                    int len = inputString.Length;
                    if (len > maxLength)
                    {
                        this.SecondLongestWord = LongestCompoundWord;
                        secondMaxLength = maxLength;

                        LongestCompoundWord = inputString;
                        maxLength = inputString.Length;
                    }

                    NumberOfCompoundWords++;
                }
                else
                {
                    EnqueueSuffixesOfSuffix(inputString, suffix);
                }
            }
        }

        /// <summary>
        /// Enqueues the suffixes of the suffix that follow the prefix
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="suffix"></param>
        private void EnqueueSuffixesOfSuffix(string inputString, string suffix)
        {
            var prefixes = this.PrefixTree.GetPrefixesOfGivenString(suffix);
            foreach (string prefix in prefixes)
            {
                this.Queue.Enqueue(Tuple.Create(inputString, Utils.GetSuffix(suffix, prefix)));
            }
        }

        /// <summary>
        /// Enqueues the suffixes of the inputString that follow the prefix
        /// </summary>
        /// <param name="inputString"></param>
        private void EnqueueSuffixesOfInputString(string inputString)
        {
            List<string> prefixes = this.PrefixTree.GetPrefixesOfGivenString(inputString);
            foreach (string prefix in prefixes)
            {
                this.Queue.Enqueue(Tuple.Create(inputString, Utils.GetSuffix(inputString, prefix)));
            }
        }
    }
}
