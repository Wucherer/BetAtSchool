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
        
        string cs = "Provider=OraOLEDB.Oracle;Data Source=aphrodite4/ora11g;User Id=d5b21;Password=wucki;OLEDB.NET=True;";
        public UserGuide getUser(string user, string pw)
        {
            UserGuide ug = null;
            
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "192.168.128.253", "OU=EDVO,OU=Schueler,OU=Benutzer,DC=htl-vil,DC=local"))
            {
                // validate the credentials
                if(pc.ValidateCredentials(user, pw))
                {
                    ug = new UserGuide(user, pw);
                }
            }
            
            return ug;
        }

        public List<string> getAllStationNames(List<Station> AllStationsx)
        {
            names = new List<string>();
            foreach(Station s in AllStationsx)
            {
                names.Add(s.StationName);
            }
           
            return names;
        }

        public string getCurrentPlayer(UserGuide u) {
            string result = "dave";
            return result;
        }

        public bool hasGuest(UserGuide u)
        {
            bool result = false;

            return result;
        }

        public List<Station> getAll()
        {

            List<Station> stations = new List<Station>();
            string connectionString = "Provider=OraOLEDB.Oracle;Data Source=aphrodite4/ora11g;User Id=d5b22;Password=wucki;OLEDB.NET=True;";
            using (OleDbConnection oleDbConnection = new OleDbConnection(connectionString))
            {
                OleDbCommand oleDbCommand = new OleDbCommand("select * from station");
                oleDbConnection.Open();
                oleDbCommand.Connection = oleDbConnection;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();

                while (oleDbDataReader.Read())
                {
                    int id = (int)oleDbDataReader.GetDecimal(0);
                    string sname = (string)oleDbDataReader.GetString(1);
                    Station s = new Station(sname, id);
                    stations.Add(s);
                }
            }

            foreach (Station s in stations)
            {
                using (OleDbConnection oleDbConnection = new OleDbConnection(connectionString))
                {
                    OleDbCommand oleDbCommand = new OleDbCommand("select * from question where question.station_id = ?");
                    oleDbCommand.Parameters.Add("?", s.StationID);
                    oleDbConnection.Open();
                    oleDbCommand.Connection = oleDbConnection;
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();

                    while (oleDbDataReader.Read())
                    {
                        Question q = null;
                        int qid = (int)oleDbDataReader.GetDecimal(0);
                        string desc = (string)oleDbDataReader.GetString(1);
                        int quote = (int)oleDbDataReader.GetDecimal(3);
                        q = new Question(qid, desc, quote, -1);
                        s.Questions.Add(q);
                    }
                }
                foreach (Question q in s.Questions)
                {
                    using (OleDbConnection oleDbConnection = new OleDbConnection(connectionString))
                    {
                        OleDbCommand oleDbCommand = new OleDbCommand("select * from answer where quest_id = ?");
                        oleDbCommand.Parameters.Add("?", q.QId);
                        oleDbConnection.Open();
                        oleDbCommand.Connection = oleDbConnection;
                        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();

                        while (oleDbDataReader.Read())
                        {
                            Answer a = null;
                            int aid = (int)oleDbDataReader.GetDecimal(0);
                            string desc = (string)oleDbDataReader.GetString(1);
                            int corr = (int)oleDbDataReader.GetDecimal(3);

                            if (corr == 1)
                                q.CorrectAnswer = aid;
                            a = new Answer(aid, desc);
                            q.Answers.Add(a);
                        }
                    }
                }

            }

            Allstations = stations;               
            return stations;
        }

        public Station getStationByName(string name, List<Station> all)
        {
            var temp = all.Where(x => x.StationName == name).ToList();

            Station s = temp.FirstOrDefault();

            return s;
        }
    }
 }