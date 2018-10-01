using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SGKataWebAPI.Context;
using SGKataWebAPI.Models;

namespace SGKataWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                try
                {
                    ApiContext context = services.GetService<ApiContext>();
                    SeedDB(context);
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void SeedDB(ApiContext context)
        {
            List<Room> rooms = new List<Room>();
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Name = "room" + i.ToString()
                });
            }

            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }
    }
}
