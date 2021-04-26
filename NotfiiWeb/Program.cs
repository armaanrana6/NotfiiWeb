using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notfii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotfiiWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Messaging.Init();
            //Sql.Init();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = "notfiiserver.database.windows.net",
                UserID = "notfiiadmins",
                Password = "wayDeliSaw8",
                InitialCatalog = "notfiidata",
                PersistSecurityInfo = false,
                MultipleActiveResultSets = false,
                Encrypt = true,
                TrustServerCertificate = true,
                ConnectTimeout = 30
            };
            Sql.connection = new SqlConnection(builder.ConnectionString);

            Sql.connection.Open();

            CreateHostBuilder(args).Build().Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
