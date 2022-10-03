using EWYRYV_HFT_202223.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWYRYV_HFT_202223.Repository
{
    public class RoleRepository : Repository<Role>, IRepository<Role>
    {
        public RoleRepository(TeamDbContext ctx) : base(ctx)
        {

        }
        public override Role Read(int id)
        {
            return ctx.Roles.FirstOrDefault(t => t.RoleId == id);
        }

        public override void Update(Role item)
        {
            var old = Read(item.RoleId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
