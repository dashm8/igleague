using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsrealLeague.Models
{
    public class Team
    {
        public long ID { get; set; }
        public string TeamName { get; set; }
        public Account admin { get; set; }
        public Account player1 { get; set; }
        public Account player2 { get; set; }
        public Account player3 { get; set; }
        public int score { get; set; }
    }
}
