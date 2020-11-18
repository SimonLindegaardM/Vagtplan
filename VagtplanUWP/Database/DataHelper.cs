using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VagtplanUWP.Database
{
    public static class DataHelper
    {
        private static string ConnectionString = "Data Source=andensemesterproject.database.windows.net;Initial Catalog=andensemesterproject;User ID=simonlindegaard;Password=Datamatiker!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public static ObservableCollection<Afdelingsplan> GetAfdelingsplan()
        {
            const string query = "select Medarbejdersplan.MedarbejderID, VagtID, Dato, VirksomhedsID from Afdelingsplan inner join Medarbejdersplan on Afdelingsplan.MedarbejderID = Medarbejdersplan.MedarbejderID";
            var afdelingsplan = new ObservableCollection<Afdelingsplan>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = query;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var vagtplan = new Afdelingsplan();
                                    vagtplan.MedarbejderID = reader.GetInt32(0);
                                    vagtplan.VagtID = reader.GetInt32(1);
                                    vagtplan.Dato = reader.GetDateTime(2);
                                    vagtplan.VirksomhedsID = reader.GetInt32(3);
                                    afdelingsplan.Add(vagtplan);
                                }
                            }
                        }
                    }
                }
                return afdelingsplan;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
        public static ObservableCollection<Medarbejdersplan> GetMedarbejdersplan()
        {
            const string query = "select MedarbejderID, Navn, Adresse, Telefon from Medarbejdersplan";
            var medarbejdersplan = new ObservableCollection<Medarbejdersplan>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = query;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var vagtplan = new Medarbejdersplan();
                                    vagtplan.MedarbejderID = reader.GetInt32(0);
                                    vagtplan.MedarbejderNavn = reader.GetString(1);
                                    vagtplan.Adresse = reader.GetString(2);
                                    vagtplan.Nummer = reader.GetInt32(3);
                                    medarbejdersplan.Add(vagtplan);

                                }
                            }
                        }
                    }
                }
                return medarbejdersplan;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }


    }
}
