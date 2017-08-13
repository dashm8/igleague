using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsrealLeague.Models
{
    public class Account
    {
        public long ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int score { get; set; }        
        public ICollection<Account> friends { get; set; }
        public Team myteam { get; set; }

        public Account()
        {
            score = 1000;
        }
        
    }
}
