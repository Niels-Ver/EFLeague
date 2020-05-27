using LeagueLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeagueLibrary
{
    public class DbManager
    {
        private LeagueContext ctx = new LeagueContext();

        public void InitialiseerDatabank(string path)
        {
            Dictionary<string, Speler> spelerDict = new Dictionary<string, Speler>();
            Dictionary<int, Team> teamDict = new Dictionary<int, Team>();
            Dictionary<int, Transfer> transferDict = new Dictionary<int, Transfer>();

            using (StreamReader r = new StreamReader(path))
            {
                string line;
                string spelerNaam;
                int nummer;
                string club;
                int waarde;
                int stamnr;
                string trainer;
                string bijnaam;

                r.ReadLine();
                while ((line = r.ReadLine()) != null)
                {
                    string[] ss = line.Split(',').Select(x => x.Trim()).ToArray();
                    spelerNaam = ss[0];
                    nummer = int.Parse(ss[1]);
                    club = ss[2];
                    waarde = int.Parse(ss[3].Replace(" ", ""));
                    stamnr = int.Parse(ss[4]);
                    trainer = ss[5];
                    bijnaam = ss[6];

                    if (!teamDict.ContainsKey(stamnr))
                        teamDict.Add(stamnr, new Team(stamnr, club, bijnaam, trainer));
                    if (!spelerDict.ContainsKey(spelerNaam))
                        spelerDict.Add(spelerNaam, new Speler(spelerNaam, nummer, waarde, teamDict[stamnr]));
                    teamDict[stamnr].Spelers.Add(spelerDict[spelerNaam]);

                }
            }

            using (LeagueContext ctx = new LeagueContext())
            {
                ctx.Teams.AddRange(teamDict.Values);
                ctx.SaveChanges();
            }
        }

        public void VoegSpelerToe(Speler speler)
        {
            ctx.Spelers.Add(speler);
            ctx.SaveChanges();
        }

        public void VoegTeamToe(Team team)
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();
        }

        public void VoegTransferToe(Transfer transfer)
        {
            ctx.Transfers.Add(transfer);
            ctx.SaveChanges();
        }

        public void UpdateSpeler(Speler speler)
        {
            Speler teUpdatenSpeler = ctx.Spelers.Single(x => x.Naam == speler.Naam);
            teUpdatenSpeler.RugNummer = speler.RugNummer;
            teUpdatenSpeler.Waarde = speler.Waarde;
            ctx.SaveChanges();
        }

        public void UpdateTeam(Team team)
        {
            Team teUpdatenTeam = ctx.Teams.Single(x => x.StamNummer == team.StamNummer);
            teUpdatenTeam.Naam = team.Naam;
            teUpdatenTeam.Bijnaam = team.Bijnaam;
            teUpdatenTeam.Trainer = team.Trainer;
            teUpdatenTeam.Spelers = team.Spelers;
            ctx.SaveChanges();
        }

        public Speler SelecteerSpeler(int spelerID)
        {
            Speler selectedSpeler = ctx.Spelers.Single(x => x.SpelerID == spelerID);
            selectedSpeler.Team = ctx.Teams.Single(x => x.StamNummer == selectedSpeler.TeamStamNummer);
            return selectedSpeler;
        }

        public Team SelecteerTeam(int stamnummer)
        {
            Team selectedTeam = ctx.Teams.Single(x => x.StamNummer == stamnummer);
            foreach (Speler speler in ctx.Spelers.Where(s=>s.TeamStamNummer==stamnummer))
            {
                selectedTeam.AddSpeler(speler);
            }
            return selectedTeam;
        }

        public Transfer SelecteerTransfer(int transferID)
        {
            Transfer selectedTransfer = ctx.Transfers.Single(x => x.TransferID == transferID);
            return selectedTransfer;
        }
    }
}
