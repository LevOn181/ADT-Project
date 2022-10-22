using NUnit.Framework;
using System;

namespace EWYRYV_HFT_202223.Test2
{
    [TestFixture]
    public class Tester
    {
        private int calc { get; set; }

        [SetUp]
        public void Setup()
        {
            calc = 1;
        }
        [Test]
        public void TesterTest()
        {
            int res = calc;
            Assert.That(calc, Is.EqualTo(1));
        }
    }
}
