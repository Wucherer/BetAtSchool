using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetAtSchoolClient.Models
{
    public class Player
    {
        public string name { get; set; }
        public decimal credit { get; set; }

        public Player(string _name,decimal _credit)
        {
            name = _name;
            credit = _credit;
        }

        public Player()
        {
            name = null;
            credit = 0;
        }
    }
}