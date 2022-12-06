using backend.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Hospital_DBN2 : DbContext  
    {
        public Hospital_DBN2(DbContextOptions<Hospital_DBN2> dbContextOptions)
           : base(dbContextOptions)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Hospital_DB, System.Data.Entity.Migrations.Configuration>());
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<Hospital_DB, Migrations.Configuration>());

            // Database.SetInitializer<Hospital_DB>(new CreateDatabaseIfNotExists<Hospital_DB>());

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     // connect to sql server with connection string from app settings
        //     options.UseSqlServer("Data Source=GEEK-PC\\GEEK;Initial Catalog=Hospital_DBN;Integrated Security=true;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate = True; ");

        //     // var configuration = new ConfigurationBuilder()
        //     //     .SetBasePath(Directory.GetCurrentDirectory())
        //     //     .AddJsonFile("appsettings.json")
        //     //     .Build();
                
           
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
            modelBuilder.Entity<Patient>().HasIndex(p => p.National_Code).IsUnique();
        }

        public DbSet<Catheter> Catheter { get; set; }
        public DbSet<Catheterisation> Catheterisation { get; set; }
        public DbSet<Clearance> Clearance { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Part> Part { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Reception> Reception { get; set; }
        public DbSet<Catheter_event> Catheter_event { get; set; }
        public DbSet<CatheterEject> CatheterEject { get; set; }

        //public virtual ObjectResult<string> Getuser_tbl(string userName, string password)
        //{
        //    var userNameParameter = userName != null ?
        //        new SqlParameter("UserName", userName) :
        //        new SqlParameter("UserName", typeof(string));

        //    var passwordParameter = password != null ?
        //        new SqlParameter("Password", password) :
        //        new SqlParameter("Password", typeof(string));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<string>("Getuser_tbl", userNameParameter.SqlValue, passwordParameter.SqlValue);
        //}
        public DbSet<User> User_tbl { get; set; }
    }

}
