using EWYRYV_HFT_202223.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWYRYV_HFT_202223.Logic
{
    interface IManagerLogic
    {
        void Create(Manager item);
        void Delete(int id);
        Manager Read(int id);
        IQueryable<Manager> ReadAll();
        void Update(Manager item);
    }
}

