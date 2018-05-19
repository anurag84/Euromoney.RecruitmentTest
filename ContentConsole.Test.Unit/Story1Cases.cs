using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ContentConsole;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class Story1Cases
    {
        Functionality funcObject;

        [SetUp]
        public void Setup()
        {
            funcObject = new Functionality(new DatabaseCont());
        }

        [Test]
        public void sentence_when_null()
        {
            Assert.AreEqual(0, funcObject.CheckNegativeCount(null));
        }

        [Test]
        public void sentence_when_blank()
        {
            Assert.AreEqual(0, funcObject.CheckNegativeCount(""));
        }

        [Test]
        public void sentence_with_neg_words()
        {
            Assert.AreEqual(2, funcObject.CheckNegativeCount("The weather is bad and nasty."));
        }

        [Test]
        public void sentence_with_neg_words_only()
        {
            Assert.AreEqual(3, funcObject.CheckNegativeCount("bad nasty horrible"));
        }

        [Test]
        public void sentence_with_zeroNeg_words()
        {
            Assert.AreEqual(0, funcObject.CheckNegativeCount("The weater is very good."));
        }

        [Test]
        public void sentence_with_sameNeg_words_repeat()
        {
            Assert.AreEqual(2, funcObject.CheckNegativeCount("The weater is very horrible and makes me feel horrible."));
        }

        [Test]
        public void sentence_with_Neg_words_diffCase()
        {
            Assert.AreEqual(1, funcObject.CheckNegativeCount("The weater is very Horrible."));
        }

        [Test]
        public void sentence_with_Neg_words_underQuotes()
        {
            Assert.AreEqual(1, funcObject.CheckNegativeCount("The weater is very 'horrible'."));
        }
    }
}
