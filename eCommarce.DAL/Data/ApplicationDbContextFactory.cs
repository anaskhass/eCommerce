//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;

//namespace eCommarce.DAL.Data
//{
//    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../eCommarce.PL");

//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(basePath)
//                .AddJsonFile("appsettings.json")
//                .Build();

//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            var connectionString = configuration.GetConnectionString("DefaultConnection");

//            optionsBuilder.UseSqlServer(connectionString);

//            return new ApplicationDbContext(optionsBuilder.Options);
//        }
//    }
//}using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace eCommarce.DAL.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine("📁 Current directory: " + currentDir);

            var basePath = Path.Combine(currentDir, "../eCommarce.PL");
            Console.WriteLine("📁 Base path used for config: " + basePath);

            var configPath = Path.Combine(basePath, "appsettings.json");
            Console.WriteLine("📄 Checking if appsettings.json exists: " + File.Exists(configPath));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine("🔑 Connection string: " + connectionString);

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

