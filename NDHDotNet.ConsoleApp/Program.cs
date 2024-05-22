// See https://aka.ms/new-console-template for more information
using NDHDotNet.ConsoleApp;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
adoDotNetExample.Create("t1","a1","c1");
Console.ReadKey();
