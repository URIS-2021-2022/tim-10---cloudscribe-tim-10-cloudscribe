﻿using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace cloudscribe.Core.Storage.EFCore.MSSQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
