using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class Manager
    {
        private string _conn;
        public Manager(string conn)
        {
            _conn = conn;
        }

        public IEnumerable<Person> GetPeople()
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            conn.Open();
            List<Person> ppl = new List<Person>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ppl.Add(new Person
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                    
                });
            }
            return ppl;
        }

        public void AddPeople(IEnumerable<Person> people)
        {
            SqlConnection conn=new SqlConnection(_conn);
            SqlCommand cmd = conn.CreateCommand();
            foreach(Person p in people)
            {
                cmd.CommandText = "INSERT INTO People VALUES(@fName, @lName, @age)";
                cmd.Parameters.AddWithValue("@fName", p.FirstName);
                cmd.Parameters.AddWithValue("@lName", p.LastName);
                cmd.Parameters.AddWithValue("@age", p.Age);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            conn.Dispose();
        }
    }
}
