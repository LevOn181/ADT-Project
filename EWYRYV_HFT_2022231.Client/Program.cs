using ConsoleTools;
using EWYRYV_HFT_202223.Models;
using EWYRYV_HFT_202223.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDbApp.Client
{
    internal class Program
    {
        static RestService rest;
        

        static void List(string entity)
        {
            List<Manager> managers = rest.Get<Manager>("manager");
            List<Team> teams = rest.Get<Team>("team");
            List<Player> players = rest.Get<Player>("player");
            if (entity == "Manager")
            {
                foreach (var item in managers)
                {
                    Console.Write("ID: " + item.ManagerId + " | Name: " + item.Name);  
                    if (item.Nationality != null)
                    {
                        Console.Write(" | Nationality: " + item.Nationality);
                    }
                    else
                    {
                        Console.Write(" | Nationality = null");
                    }
                    if (item.Nationality != null)
                    {
                        Console.Write(" | Managed Team ID: " + item.TeamId);
                    }
                    else
                    {
                        Console.Write(" | Managed Team ID: null");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Press ENTER to continue...");
            }
            else if (entity == "Team")
            {   
                foreach (var item in teams)
                {
                    Console.WriteLine("ID: " + item.TeamId + " | Name: " + item.Name);
                }
                Console.WriteLine("Press ENTER to continue...");
            }
            else if (entity == "Player")
            {
                foreach (var item in players)
                {
                    Console.Write("ID: " + item.PlayerId + " | Name:" + item.Name + " |");
                    if(item.KitNumber != null)
                    {
                        Console.Write(" Birth date: " + item.BirthDate +" |");
                    }
                    else
                    {
                        Console.Write(" Birth date: null |");
                    }
                    if (item.KitNumber != null)
                    {
                        Console.Write(" Kit Number: " + item.KitNumber + " |");
                    }
                    else
                    {
                        Console.Write(" Kit number: null |");
                    }
                    if (item.KitNumber != null)
                    {
                        Console.Write(" Value: " + item.Value);
                    }
                    else
                    {
                        Console.Write(" Value: null");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Press ENTER to continue...");
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Manager one = rest.Get<Manager>(id, "manager");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "manager");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter Team's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Team one = rest.Get<Team>(id, "team");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "team");
            }
            else if (entity == "Player")
            {
                Console.Write("Enter Manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Player one = rest.Get<Player>(id, "actor");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "player");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "actor");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter Team's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "team");
            }
            else if (entity == "Player")
            {
                Console.Write("Enter Players's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:5000/");

            var managerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Manager"))
                //.Add("Create", () => Create("Manager"))
                .Add("Delete", () => Delete("Manager"))
                .Add("Update", () => Update("Manager"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                //.Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                //.Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Managers", () => managerSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
