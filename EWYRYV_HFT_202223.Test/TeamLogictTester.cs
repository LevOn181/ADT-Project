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
    public class TeamLogictTester
    {
        TeamLogic teamLogic;
        ManagerLogic managerLogic;
        PlayerLogic playerLogic;

        Mock<IRepository<Team>> mockTeamRepo = new Mock<IRepository<Team>>();
        Mock<IRepository<Manager>> mockManagerRepo = new Mock<IRepository<Manager>>();
        Mock<IRepository<Player>> mockPlayerRepo = new Mock<IRepository<Player>>();

        [SetUp]
        public void Init()
        {
            mockPlayerRepo.Setup(m => m.ReadAll()).Returns(new List<Player>()
            {
                new Player("1#11#1#9#Test Player0#1991.01.11#100"),
                new Player("2#16#1#9#Test Player1#1987.12.24#200"),
                new Player("3#23#1#9#Test Player2#1996.06.12#300"),
                new Player("4#2#1#9#Test Player3#1996.11.01#400"),

                new Player("5#1#2#9#Test Player4#2001.09.11#500"),
                new Player("6#4#2#9#Test Player5#1981.08.09#400"),
                new Player("7#5#2#9#Test Player6#1997.07.21#300"),
                new Player("8#10#2#9#Test Player7#1985.12.01#200"),

                new Player("9#69#3#9#Test Player8#2004.03.21#300"),
                new Player("10#99#3#9#Test Player9#1999.04.14#600"),
                new Player("11#13#3#9#Test Player10#1979.02.11#100"),
                new Player("12#22#3#9#Test Player11#1986.01.01#50"),
            }.AsQueryable());

            mockTeamRepo.Setup(m => m.ReadAll()).Returns(new List<Team>()
            {
                new Team("1#Tes1 FC#2000"),
                new Team("2#Test2 SC#1950"),
                new Team("3#test3 AC#1880"),
            }.AsQueryable());

            mockManagerRepo.Setup(m => m.ReadAll()).Returns(new List<Manager>() 
            { 
                new Manager("1#Test Manager0#USA#1"),
                new Manager("2#Test Manager1#HU#2"),
                new Manager("3#Test Manager2#UK#3"),
            }.AsQueryable());

            teamLogic = new TeamLogic(mockTeamRepo.Object);
            playerLogic = new PlayerLogic(mockPlayerRepo.Object);
            managerLogic = new ManagerLogic(mockManagerRepo.Object);
        }

        /*
        [Test]
        public void MostValuableCorrectTest()
        {
            Init();
            IEnumerable<object> expected = new IEnumerable<object>();
            
            var actual = playerLogic.MostValuable();
            ;
            Assert.That(expected.GetHashCode().Equals(actual.GetHashCode()));
        }
        */

        [Test]
        public void RunTest()
        {
            Assert.That(1, Is.EqualTo(1));
        }

        [Test]
        public void CreateManagerTestSuccess()
        {
            Init();
            var manager = new Manager() { Name = "Test Manager3", Nationality = "CZK", TeamId = 4 };
            managerLogic.Create(manager);
            mockManagerRepo.Verify(m => m.Create(manager), Times.Once);
        }

        [Test]
        public void CreateManagerTestFail()
        {
            var manager = new Manager() { Nationality = "RO", TeamId = 4 };
            try
            {
                //ACT
                managerLogic.Create(manager);
            }
            catch
            {

            }
            mockManagerRepo.Verify(m => m.Create(manager), Times.Never);
        }

        [Test]
        public void DeleteTeamTestSuccess()
        {

        }

        [Test]
        public void DeleteTeamTestFail()
        {
            try
            {
                teamLogic.Delete(5);
            }
            catch
            {

            }
            mockTeamRepo.Verify(m => m.Delete(5), Times.Never);
           

        }

        
    }
}
