using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class Story3Cases
    {
        Functionality funcObject;

        [SetUp]
        public void Setup()
        {
            funcObject = new Functionality(new DatabaseCont());
        }

        [Test]
        public void content_when_null()
        {
            Assert.AreEqual("", funcObject.FilterOutNegativeWords(null, true));
        }

        [Test]
        public void content_when_empty()
        {
            Assert.AreEqual("", funcObject.FilterOutNegativeWords("", true));
        }

        [Test]
        public void content_with_oneNegativeWord()
        {
            Assert.AreEqual("The weather is h******e today.", funcObject.FilterOutNegativeWords("The weather is horrible today.", true));
        }

        [Test]
        public void content_with_noNegWord()
        {
            Assert.AreEqual("The weather is good today.", funcObject.FilterOutNegativeWords("The weather is good today.", true));
        }

        [Test]
        public void content_with_multipleNegWord()
        {
            Assert.AreEqual("The weather is h******e and makes me feel b*d today.", funcObject.FilterOutNegativeWords("The weather is horrible and makes me feel bad today.", true));
        }

        [Test]
        public void content_with_multipleNegWordDiffCase()
        {
            Assert.AreEqual("The weather is h******e and makes me feel H******E today.", funcObject.FilterOutNegativeWords("The weather is horrible and makes me feel HORRIBLE today.", true));
        }
    }
}
