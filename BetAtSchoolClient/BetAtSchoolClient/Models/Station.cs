using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetAtSchoolClient.Models
{
    public class Station
    {
        public string StationName { get; set; }
        public decimal StationID { get; set; }

        public Station(string n, decimal id)
        {
            StationName = n;
            StationID = id;
        }

        public Station()
        {
        }
    }
}