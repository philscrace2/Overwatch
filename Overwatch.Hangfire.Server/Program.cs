using Hangfire;
using Hangfire.SqlServer;
using Spectre.Console;
using Overwatch.Hangfire.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;




namespace Overwatch.Hangfire.Server
{
    public class Program
    {
        public static void Main()
        {
            // Configure Hangfire with SQL Server storage
            //GlobalConfiguration.Configuration.UseSqlServerStorage("your_connection_string");
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=UKCAML11345\\MSSQLSERVER01;Database=HangfireDb;Trusted_Connection=True;TrustServerCertificate=True;");


            // Start Hangfire server
            using (var server = new BackgroundJobServer())
            {
                // Set up the dashboard for monitoring jobs
                var dashboardUrl = "http://localhost:5000";
                Console.WriteLine($"Hangfire Dashboard running at {dashboardUrl}");
                AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
                {
                    // Cleanup on process exit
                    server.Dispose();
                };

                // Start the Hangfire Dashboard (runs on a separate thread or web server)
                var dashboardThread = new System.Threading.Thread(() =>
                {
                    //using (var server2 = new BackgroundJobServer())
                    //{


                    //}
                    var builder = WebApplication.CreateBuilder();
                    builder.Logging.AddConsole(Options =>
                    {
                        Options.LogToStandardErrorThreshold = Microsoft.Extensions.Logging.LogLevel.Warning;
                    });
                    builder.Services.AddHangfire(configuration =>
                    configuration.UseSqlServerStorage("Server=UKCAML11345\\MSSQLSERVER01;Database=HangfireDb;Trusted_Connection=True;TrustServerCertificate=True;"));
                    builder.Services.AddHangfireServer();
                    var app = builder.Build();
                    app.UseHangfireDashboard("/hangfire");
                    app.Run();
                });

                dashboardThread.Start();

                Console.ReadLine();

            }
        }


    }
}
