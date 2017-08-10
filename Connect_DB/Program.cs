using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Data;

namespace Connect_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlCon = new SqlConnection())
            {
                DataSet ds = new DataSet();
                DataTable table = new DataTable("Users");
                DataColumn id = new DataColumn("ID", typeof(string));
                DataColumn pw = new DataColumn("PW", typeof(string));
                DataColumn birthday = new DataColumn("Birthday", typeof(DateTime));
                ds.Tables.Add(table);
                table.Columns.Add(id);
                table.Columns.Add(pw);
                table.Columns.Add(birthday);

                // Insert
                table.Rows.Add("infreljs", "1234", new DateTime(2000, 11, 6));
                table.Rows.Add("1", "1", new DateTime(2000, 1, 1));
                table.Rows.Add("2", "2", new DateTime(2000, 2, 2));

                // Select
                DataRow[] rows = table.Select("");
                foreach (DataRow row in rows)
                {
                    Console.WriteLine(row["ID"]);
                }

                //sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
                //sqlCon.Open();

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = sqlCon;

                //cmd.CommandText = "INSERT INTO Users (ID, Name, PW, Birthday) VALUES ('3','3','3','2000-03-03')";
                //int affectedCount = cmd.ExecuteNonQuery();
                //Console.WriteLine(affectedCount);

                //cmd.CommandText = "SELECT * FROM Users";
                //SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    string id = reader.GetString(0);
                //    string name = reader.GetString(1);
                //    string pw = reader.GetString(2);
                //    DateTime birthday = reader.GetDateTime(3);

                //    Console.WriteLine("{0}, {1}, {2}, {3}", id, name, pw, birthday);
                //}

                //reader.Close();
            }
        }
    }
}
