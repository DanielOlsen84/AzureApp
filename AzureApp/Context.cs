using AzureApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureApp
{
    public class Context : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ChatMessageModel> ChatMessages { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = tcp:danielolsenhrserver.database.windows.net,1433; Initial Catalog = HRDB; Persist Security Info = False; 
                    User ID = Daniel; Password = ; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
            }
            
        }
    }
}
