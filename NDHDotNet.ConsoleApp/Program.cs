// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = ".";
stringBuilder.InitialCatalog = "B3J";
stringBuilder.UserID = "sa";
stringBuilder.Password = "root";

SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
sqlConnection.Open();
Console.WriteLine("Connection is Open");
string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

sqlConnection.Close();
Console.WriteLine("Connection is Close");

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("BlogId" + dr["BlogId"]);
    Console.WriteLine("BlogTitle" + dr["BlogTitle"]);
    Console.WriteLine("BlogAuthor" + dr["BlogAuthor"]);
    Console.WriteLine("BlogContent" + dr["BlogContent"]);
    Console.WriteLine("--------------------------------------");
}
Console.ReadKey();
