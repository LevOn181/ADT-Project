using EWYRYV_HFT_202223.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWYRYV_HFT_202223.Repository
{
    public class ManagerRepository : Repository<Manager>, IRepository<Manager>
    {
        public ManagerRepository(TeamDbContext ctx) : base(ctx)
        {

        }
        public override Manager Read(int id)
        {
            return ctx.Managers.FirstOrDefault(t => t.ManagerId == id);
        }

        public override void Update(Manager item)
        {
            var old = Read(item.ManagerId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
