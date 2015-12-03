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

        internal static void Test(string name)
        {
            try
            {
                ConnectDB();
                string sqlInput = @"Insert into People (Name, IsAdmin) values (@name, 0)";
                SqlCommand cmd = new SqlCommand(sqlInput, dbconn);
                cmd.Parameters.AddWithValue("@name", name);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseDB();
            }
        }

        //CM06 #FB02
        public static void CreateUser(Person person)
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand("CreatePerson", dbconn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Name", person.Name));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", person.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@IsAdmin", person.IsAdmin));
                cmd.Parameters.Add(new SqlParameter("@Gender", person.Gender));
                cmd.Parameters.Add(new SqlParameter("@Email", person.Email));
                cmd.Parameters.Add(new SqlParameter("@Password", person.Password));
                cmd.Parameters.Add(new SqlParameter("@Weight", person.Measurements[0].Weight));
                cmd.Parameters.Add(new SqlParameter("@Height", person.Measurements[0].Height));
                cmd.Parameters.Add(new SqlParameter("@BMR", person.Measurements[0].BMR));
                cmd.Parameters.Add(new SqlParameter("@Date", person.Measurements[0].Date));
                
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
        public static void DeleteUser(string email)
        {
            ConnectDB();
            ConnectDB();
            SqlCommand cmd = new SqlCommand("DeletePerson", dbconn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Email", email));

            cmd.ExecuteNonQuery();
            CloseDB();
        }
    }
}
