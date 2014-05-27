using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    public class PrefixTreeTests
    {
        PrefixTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new PrefixTree();
        }

        [Test]
        public void TestContainsWorksAsExpected()
        {
            tree.Insert("cat");

            Assert.IsTrue(tree.Contains("cat"));
            Assert.IsFalse(tree.Contains("ca"));
            Assert.IsFalse(tree.Contains("c"));
            Assert.IsFalse(tree.Contains("cats"));
        }

        [Test]
        public void TestGetPrefixesAsExpected()
        {
            tree.Insert("cat");
            tree.Insert("rat");

            var list = tree.GetPrefixesOfGivenString("cats");

            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(list.Contains("cat"));

            list = tree.GetPrefixesOfGivenString("catrat");
            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(list.Contains("cat"));

            list = tree.GetPrefixesOfGivenString("catcat");
            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(list.Contains("cat"));
        }
    }
}
