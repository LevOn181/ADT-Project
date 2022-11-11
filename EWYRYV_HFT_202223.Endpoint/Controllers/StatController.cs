using EWYRYV_HFT_202223.Logic;
using EWYRYV_HFT_202223.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWYRYV_HFT_202223.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ITeamLogic teamlogic;
        public StatController(ITeamLogic logic)
        {
            this.teamlogic = logic;
        }

        [HttpGet]
        public IEnumerable<object?> countPlayers()
        {
           return this.teamlogic.CountPlayers();
        }

        [HttpGet]
        public IEnumerable<object> teamValue()
        {
            return this.teamlogic.TeamValue();
        }

        [HttpGet]
        public IEnumerable<object> mostValuable()
        {
            return this.teamlogic.MostValuable();
        }

        [HttpGet]
        public IEnumerable<object> hungarianManagers()
        {
            return this.teamlogic.HungarianManagers();
        }

        [HttpGet]
        public IEnumerable<object>topPlayerData()
        {
            return this.teamlogic.TopPlayerData();
        }
    }
}