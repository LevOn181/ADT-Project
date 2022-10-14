using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWYRYV_HFT_202223.Repository;
using EWYRYV_HFT_202223.Models;

namespace EWYRYV_HFT_202223.Logic.Classes
{
    class ManagerLogic : IManagerLogic
    {
        IRepository<Manager> repo;
        public ManagerLogic(IRepository<Manager> repo)
        {
            this.repo = repo;
        }
        public void Create(Manager item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Manager Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Manager> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Manager item)
        {
            this.repo.Update(item);
        }
    }
}
