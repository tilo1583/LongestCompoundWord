using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems
{
    public class UtilsTest
    {
        [Test]
        [TestCase("testString", "test","String")]
        [TestCase("testtest", "test", "test")]
        [TestCase("hi", "h", "i")]
        public void GetSuffixTest(string testString, string prefix, string expectedSuffix)
        {
            Assert.AreEqual(Utils.GetSuffix(testString, prefix), expectedSuffix);
        }
    }
}
