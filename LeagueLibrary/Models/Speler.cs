using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLibrary.Models
{
    public class Speler
    {
        public Speler(string naam, int rugNummer, int waarde)
        {
            Naam = naam;
            RugNummer = rugNummer;
            Waarde = waarde;
        }

        public Speler(string naam, int rugNummer, int waarde, Team team) : this(naam, rugNummer, waarde)
        {
            Team = team;
        }

        public int SpelerID { get; set; }
        public string Naam { get; set; }
        public int RugNummer { get; set; }
        public int Waarde { get; set; }
        public int TeamStamNummer { get; set; }
        public Team Team { get; set; }

        public override string ToString()
        {
            return $"Speler:{SpelerID}, naam:{Naam}, rugnummer:{RugNummer}, waarde:{Waarde}, team:{Team.Naam} ";
        }

        public override bool Equals(object obj)
        {
            return obj is Speler speler &&
                   Naam == speler.Naam &&
                   RugNummer == speler.RugNummer;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam, RugNummer);
        }
    }
}
