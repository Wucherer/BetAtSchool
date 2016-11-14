using BetAtSchoolClient.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace BetAtSchoolClient.Controllers
{
    public class ControllerHelper
    {
        public List<Station> Allstations { get; set; }
        public List<string> names { get; set; }
        string cs = "Provider=OraOLEDB.Oracle;Data Source=212.152.179.117/ora11g;User Id=d5b21;Password=wucki;OLEDB.NET=True;";
        public UserGuide getUser(string user, string pw)
        {
            UserGuide ug = null;
            /*
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "gandalf.htl-villach.at", "OU=EDVO,OU=Schueler,OU=Benutzer,DC=htl-vil,DC=local"))
            {
                // validate the credentials
                if(pc.ValidateCredentials(user, pw))
                {
                    ug = new UserGuide(user, pw);
                }
            }*/
            ug = new UserGuide("harald", "hh");
            return ug;
        }

        private void getAllStations()
        {
            Allstations = new List<Station>();

            using (OleDbConnection oleDbConnection = new OleDbConnection(cs))
            {
                OleDbCommand oleDbCommand = new OleDbCommand("select * from Station");
                oleDbConnection.Open();
                oleDbCommand.Connection = oleDbConnection;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                int currQId = 0;
                Station s;
                while (oleDbDataReader.Read())
                {
                    decimal id = oleDbDataReader.GetDecimal(0);
                    string name = oleDbDataReader.GetString(1);
                    s = new Station(name, id);
                    Allstations.Add(s);
                }
            }
        }

        public List<string> getAllStationNames()
        {
            getAllStations();
            names = new List<string>();
            foreach(Station s in this.Allstations)
            {
                names.Add(s.StationName);
            }
            return names;
        }

        public string getCurrentPlayer(UserGuide u) {
            string result = "dave";
            return result;
        }

        public bool hasGuest()
        {
            bool result = false;

            return result;
        }
    }


}