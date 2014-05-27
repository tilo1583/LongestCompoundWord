using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    public class PrefixTree : IPrefixTree
    {
        Node Root;

        public PrefixTree()
        {
            Root = new Node(' ');
        }

        private class Node
        {
            public char Character;
            public Dictionary<char, Node> Followers = new Dictionary<char, Node>();
            public bool isEndChar;

            public Node(char Char, bool isEnd=false)
            {
                this.Character = Char;
                this.isEndChar = isEnd;
            }
        }

        /// <summary>
        /// If the word being tested is cat, it tests to see if a follows c and if t follows a. Also, it checks to see if t has 
        /// the end char. 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public bool Contains(string inputString)
        {
             Node currentNode = this.Root;
             char[] arr = inputString.ToCharArray();
             foreach(char c in arr)
             {
                 if (!currentNode.Followers.ContainsKey(c))
                 {
                     return false;
                 }
                 else
                 {
                     currentNode = currentNode.Followers[c];
                 }
             }
             return currentNode.isEndChar;
        }

        /// <summary>
        /// Inserts a word in the prefix tree. Eg. If the word is cat, c, a and t will be three different nodes in the tree. 
        /// c will be a child of root, a will be a child of c and so on. t will have isEndChar true
        /// </summary>
        /// <param name="inputString"></param>
        public void Insert(string inputString)
        {
            Node currentNode = this.Root;
            char[] arr = inputString.ToCharArray();
            foreach (char c in arr)
            {
                if (!currentNode.Followers.ContainsKey(c))
                {
                    currentNode.Followers[c] = new Node(c);
                }

                currentNode = currentNode.Followers[c];
            }
            currentNode.isEndChar = true;
        }

        /// <summary>
        /// Given a string, it will return all the prefixes of that string that are  
        /// valid words in the prefix tree
        /// eg if cats is inputString and cat is a valid word in the tree, it will return cat
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public List<string> GetPrefixesOfGivenString(string inputString)
        {
            List<string> prefixList = new List<string>();
            StringBuilder currentPrefix = new StringBuilder(string.Empty);

            Node currentNode = this.Root;
            foreach(char c in inputString.ToCharArray())
            {
                if(!currentNode.Followers.ContainsKey(c))
                {
                    break;
                }
                currentNode = currentNode.Followers[c];
                currentPrefix.Append(c);
                if (currentNode.isEndChar)
                {
                    prefixList.Add(currentPrefix.ToString());
                }
            }

            return prefixList;
        }
    }
}
