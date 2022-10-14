﻿using System;
using EWYRYV_HFT_202223.Models;
using EWYRYV_HFT_202223.Repository;
using System.Linq;

namespace EWYRYV_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamDbContext ctx = new TeamDbContext();
            Console.WriteLine("Number of Teams: "+ctx.Teams.Count());
            Console.WriteLine("Number of Players: " + ctx.Players.Count());
            Console.WriteLine("Number of Roles: " + ctx.Roles.Count());

            ;
        }

    }
}
