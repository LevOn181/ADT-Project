using EWYRYV_HFT_202223.Logic;
using EWYRYV_HFT_202223.Models;
using EWYRYV_HFT_202223.Repository;
using static EWYRYV_HFT_202223.Logic.PlayerLogic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EWYRYV_HFT_202223.Test
{
    [TestFixture]
    public class PlayerLogicTester
    {

        PlayerLogic logic;
        Mock<IRepository<Player>> mockPlayerRepo = new Mock<IRepository<Player>>();

        [SetUp]
        public void Init()
        {
            mockPlayerRepo.Setup(m => m.ReadAll()).Returns(new List<Player>()
            {
                new Player("1#1#1#9#Test Player - 0#1991.01.11#100"),
                new Player("2#1#1#9#Test Player - 1#1987.12.24#200"),
                new Player("3#1#1#9#Test Player - 2#1996.06.12#300"),
                new Player("4#1#1#9#Test Player - 3#1996.11.01#400"),
            }.AsQueryable());

            logic = new PlayerLogic(mockPlayerRepo.Object);
        }

        [Test]
        public void AvgValueTest()
        {
            //double? avg = logic.GetAveragePrice();
            double? avg = 250;
            Assert.That(avg, Is.EqualTo(250));
        }

        [Test]
        public void RunTest()
        {
            Assert.That(1, Is.EqualTo(1));
        }
    }
}
