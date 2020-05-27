using System;
using LeagueLibrary;
using LeagueLibrary.Models;

namespace LeagueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string path = @"D:\Niels\School\Prog4\Entity Framework\foot.csv";
            DbManager dm = new DbManager();
            //dm.InitialiseerDatabank(path);

            Speler speler = dm.SelecteerSpeler(10);
            //Console.WriteLine(speler);
            Team team = dm.SelecteerTeam(7);
            //team.ToonDetail();

            Team nieuwTeam = new Team(6, "KFC Sinaai ", "Snoase Bokken", "Charel");
            //dm.VoegTeamToe(nieuwTeam);
            //team = dm.SelecteerTeam(6);
            //team.ToonDetail();

            Speler nieuweSpeler = new Speler("Peeters Laurents", 12, 2400000, nieuwTeam);
            //dm.VoegSpelerToe(nieuweSpeler);
            //team = dm.SelecteerTeam(6);
            //team.ToonDetail();

            Transfer transfer = new Transfer(speler, 2100000, team, nieuwTeam);
            dm.VoegTransferToe(transfer);

            Team updateTeam = new Team(6, "KFC Sinaai ", "Snoase Bokken", "Jeff");
            dm.UpdateTeam(updateTeam);
            //team = dm.SelecteerTeam(6);
            //team.ToonDetail();

            Speler updateSpeler = new Speler("Peeters Laurents", 12, 3600000, nieuwTeam);
            //dm.UpdateSpeler(updateSpeler);
            //team = dm.SelecteerTeam(6);
            //team.ToonDetail();

        }
    }
}
