using System;
using System.Collections.Generic;
using System.Linq;
using EWYRYV_HFT_202223.Models;
using EWYRYV_HFT_202223.Repository;

namespace EWYRYV_HFT_202223.Logic
{
    public class TeamLogic : ITeamLogic
    {

        IRepository<Team> teamRepo;
        IRepository<Manager> managerRepo;
        IRepository<Player> playerRepo;

        public TeamLogic(IRepository<Team> repot, IRepository<Player> repop, IRepository<Manager> repom)
        {
            this.teamRepo = repot;
            this.managerRepo = repom;
            this.playerRepo = repop;
        }

        public void Create(Team item)
        {
            this.teamRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.teamRepo.Delete(id);
        }

        public Team Read(int id)
        {
            return this.teamRepo.Read(id);
        }

        public IQueryable<Team> ReadAll()
        {
            return this.teamRepo.ReadAll();
        }

        public void Update(Team item)
        {
            this.teamRepo.Update(item);
        }

        public IEnumerable<object> CountPlayers()
        {
            var data = from x in playerRepo.ReadAll()
                       group x by x.Team.Name into g
                       orderby g.Count() descending
                       select new
                       {
                           TeamName = g.Key,
                           PlayerCount = g.Count(),
                       };

            return data;
        }
        public IEnumerable<object> TeamValue()
        {
            var data = from x in playerRepo.ReadAll()
                       group x by x.Team.Name into g
                       orderby g.Sum(t => t.Value) descending
                       select new
                       {
                           TeamName = g.Key,
                           TeamValue = g.Sum(t => t.Value),
                       };

            return data;
        }

        public IEnumerable<object> MostValuable()
        {

            var data = from x in playerRepo.ReadAll()
                       where x.Value.Equals(playerRepo.ReadAll().Max(t => t.Value))
                       select new
                       {
                           PlayerName = x.Name,
                           ManagerName = x.Team.Manager.Name
                       };
            return data;
        }

        public IEnumerable<object> HungarianManagers()
        {
            var data = from x in teamRepo.ReadAll()
                       where x.Manager.Nationality.ToLower().Equals("hungarian") || x.Manager.Nationality.ToLower().Equals("hungary")
                       select new { teamName = x.Name, ManagerName = x.Manager.Name };
            return data;
        }

        public IEnumerable<object> TopPlayerData()
        {
            var data = from x in managerRepo.ReadAll()
                       select new
                       {
                           ManagerName = x.Name,
                           TeamName = x.Team.Name,
                           PlayerName = x.Team.Players.OrderByDescending(t => t.Value).First().Name,
                       };
            return data;
        }
    }
}
