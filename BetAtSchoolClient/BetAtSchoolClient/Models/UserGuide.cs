using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetAtSchoolClient.Models
{
    public class UserGuide
    {
        private string user;
        private string pw;

        public UserGuide(string user, string pw)
        {
            this.user = user;
            this.pw = pw;
        }
    }
}