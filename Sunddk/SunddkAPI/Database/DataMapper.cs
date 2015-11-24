using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SunddkAPI.Models;


namespace SunddkAPI.Database
{
    public static class DataMapper
    {
        private static string _connectionString = "Server=ealdb1.eal.local;" + "Database=EJL101_DB;" + "User Id=ejl101_usr;" + "Password=Baz1nga101;";
        static SqlConnection dbconn;

        private static void ConnectDB()
        {
            dbconn = new SqlConnection(_connectionString);
            dbconn.Open();
        }
        private static void CloseDB()
        {
            dbconn.Close();
            dbconn.Dispose();
        }
        public static List<Person> GetUsers()
        {
            List<Person> PersonList = new List<Person>();
            try
            {
                ConnectDB();
                string sqlInput = "Select * from People";
                SqlCommand cmd = new SqlCommand(sqlInput, dbconn);

                SqlDataReader myReader;
                myReader = cmd.ExecuteReader();

                while(myReader.HasRows && myReader.Read())
                {
                    PersonList.Add(new Person() { Email = Convert.ToString(myReader["Email"]), Name = Convert.ToString(myReader["Name"]) });
                }
            }
            catch (Exception e)
            {
                throw new Exception("Kan ikke hente brugerne" + e.Message);
            }
            finally
            {
                CloseDB();
            }
            return PersonList;
        }
        public static void CreateUser(Person person)
        {
            try
            {
                ConnectDB();

                string sqlInput = string.Format("Declare @personId int" +
                                   "Insert into People" +
                                   "(Name, DateOfBirth, IsAdmin, Gender, Email, Password)" +
                                   "@personId = Inserted.PersonId" +
                                   "Values({0},{1},{2},{3},{4},{5})", person.Name, person.DateOfBirth, person.IsAdmin, person.Gender, person.Email, person.Password) +
                                   string.Format("\nInsert into Measurements" +
                                   "(Date, Weight, Height, BMR, PersonId)" +
                                   "({0}, {1}, {2}, {3}, {4}", person.Measurements[0].Date, person.Measurements[0].Weight, person.Measurements[0].Height, person.Measurements[0].Height + "@personId"); 
                                    
                SqlCommand cmd = new SqlCommand(sqlInput, dbconn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Kunne ikke oprette bruger" + e.Message);
            }
            finally
            {
                CloseDB();
            }
        }
    }
}
