using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeagueLibrary.Models
{
    public class Team
    {
        public Team(int stamNummer, string naam, string bijnaam, string trainer)
        {
            StamNummer = stamNummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;
        }

        public Team(int stamNummer, string naam, string bijnaam, string trainer, List<Speler> spelers) : this(stamNummer, naam, bijnaam, trainer)
        {
            Spelers = spelers;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StamNummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public ICollection<Speler> Spelers { get; set; } = new List<Speler>();

        public void AddSpeler(Speler speler)
        {
            Spelers.Add(speler);
        }

        public void ToonDetail()
        {
            Console.WriteLine(this.ToString());
            foreach (Speler speler in Spelers)
            {
                Console.WriteLine(speler.ToString());
            }
        }
        public override string ToString()
        {
            return $"Team:{StamNummer}, naam:{Naam}, bijnaam:{Bijnaam}, trainer:{Trainer}";
        }

        public override bool Equals(object obj)
        {
            return obj is Team team &&
                   StamNummer == team.StamNummer;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StamNummer);
        }
    }
}
