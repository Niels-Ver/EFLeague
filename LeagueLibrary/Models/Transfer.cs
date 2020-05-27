using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLibrary.Models
{
    public class Transfer
    {
        public Transfer()
        {

        }

        public Transfer(Speler speler, int transferPrijs, Team oudeClub, Team nieuweClub)
        {
            Speler = speler;
            TransferPrijs = transferPrijs;
            OudeClub = oudeClub;
            NieuweClub = nieuweClub;
        }

        public int TransferID { get; set; }
        public Speler Speler { get; set; }
        public int TransferPrijs { get; set; }
        public Team OudeClub { get; set; }
        public Team NieuweClub { get; set; }
    }
}
