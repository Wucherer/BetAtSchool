using BetAtSchoolClient.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BetAtSchoolClient.Controllers
{
    public class ControllerHelper
    {
        public List<Station> Allstations { get; set; }
        public List<string> names { get; set; }
        string cs = "Provider=OraOLEDB.Oracle;Data Source=212.152.179.117/ora11g;User Id=d5b21;Password=wucki;OLEDB.NET=True;";
        public UserGuide getUser()
        {
            UserGuide ug = new UserGuide();

            //AD - connection

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

        public List<String> getAllStationNames()
        {
            getAllStations();
            names = new List<string>();
            foreach(Station s in this.Allstations)
            {
                names.Add(s.StationName);
            }
            return names;
        }

        

        public bool hasGuest()
        {
            bool result = false;

            return result;
        }
    }


}