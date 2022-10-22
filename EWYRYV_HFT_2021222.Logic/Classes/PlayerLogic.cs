using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWYRYV_HFT_202223.Repository;
using EWYRYV_HFT_202223.Models;

namespace EWYRYV_HFT_202223.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> repo;

        public PlayerLogic(IRepository<Player> repo)
        {
            this.repo = repo;
        }

        public void Create(Player item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public int GetAverageAge()
        {
            throw new NotImplementedException();
        }

        public double? GetAveragePrice()
        {
            int? sum = 0;
            foreach (var item in this.repo.ReadAll())
            {
                sum += item.Value;
            }

            return sum / this.repo.ReadAll().Count();
        }

        public Player Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Player item)
        {
            this.repo.Update(item);
        }
    }
}

