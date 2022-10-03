using System;
using System.Linq;
using EWYRYV_HFT_202223.Models;
using EWYRYV_HFT_202223.Repository;

namespace EWYRYV_HFT_202223.Logic
{
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> repo;

        public TeamLogic(IRepository<Team> repo)
        {
            this.repo = repo;
        }

        public void Create(Team item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Team Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Team> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Team item)
        {
            this.repo.Update(item);
        }
    }
}
