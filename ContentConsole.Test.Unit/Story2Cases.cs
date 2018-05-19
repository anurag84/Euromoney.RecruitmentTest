using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class Story2Cases
    {
        DatabaseCont dbObject;

        [SetUp]
        public void Setup()
        {
            dbObject = new DatabaseCont(new List<string> { "bad", "worst", "horrible" });
        }

        [Test]
        public void word_when_null()
        {
            Assert.AreEqual(3, dbObject.AddNegativeWords(null).Count());
        }


        [Test]
        public void word_when_empty()
        {
            Assert.AreEqual(3, dbObject.AddNegativeWords(null).Count());
        }

        [Test]
        public void word_when_added()
        {
            Assert.AreEqual(4, dbObject.AddNegativeWords("dumb").Count());
        }

        [Test]
        public void word_when_alreadyExists()
        {
            Assert.AreEqual(3, dbObject.AddNegativeWords("bad").Count());
        }
    }
}
