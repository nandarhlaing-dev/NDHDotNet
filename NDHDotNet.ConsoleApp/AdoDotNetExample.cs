using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NDHDotNet.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "B3J",
            UserID = "sa",
            Password = "root"
        };
        public void Read()
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            Console.WriteLine("Connection is Open");
            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();
            Console.WriteLine("Connection is Close");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("BlogId" + dr["BlogId"]);
                Console.WriteLine("BlogTitle" + dr["BlogTitle"]);
                Console.WriteLine("BlogAuthor" + dr["BlogAuthor"]);
                Console.WriteLine("BlogContent" + dr["BlogContent"]);
                Console.WriteLine("--------------------------------------");
            }
        }

        public void Create(string title, string author, string content)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
           @BlogAuthor,
           @BlogContent)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "saving successful" : "saving fail";
            Console.WriteLine(message);
        }
    }
}
