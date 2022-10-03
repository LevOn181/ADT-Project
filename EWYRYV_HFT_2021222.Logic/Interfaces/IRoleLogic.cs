using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWYRYV_HFT_202223.Models;

namespace EWYRYV_HFT_202223.Logic
{
    interface IRoleLogic
    {
        void Create(Role item);
        void Delete(int id);
        Role Read(int id);
        IQueryable<Role> ReadAll();
        void Update(Role item);
    }
}
