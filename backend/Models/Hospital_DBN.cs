using backend.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backend.Models
{
    public class Hospital_DBN : DbContext  
    {
        
        public Hospital_DBN(DbContextOptions<Hospital_DBN> dbContextOptions)
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
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
           .SelectMany(t => t.GetForeignKeys())
           .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.NoAction;

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
            modelBuilder.Entity<Patient>().HasIndex(p => p.National_Code).IsUnique();
            modelBuilder.Entity<Catheter>().HasKey(p => p.Catheter_ID);
            modelBuilder.Entity<Catheter>().HasIndex(p => p.Catheter_Name).IsUnique();
            modelBuilder.Entity<Clearance>().HasIndex(p => p.Clearance_Type).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(p => p.Dr_NationalCode).IsUnique();
            modelBuilder.Entity<Event>().HasIndex(p => p.Event_Name).IsUnique();
            modelBuilder.Entity<Part>().HasIndex(p => p.Part_Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.Username).IsUnique();
            modelBuilder.Entity<User_Role>().HasIndex(p => p.Role_Name).IsUnique();
            //----;
            modelBuilder.Entity<Patient>().HasOne(p => p.User).WithMany().OnDelete(DeleteBehavior.NoAction);
            //mod-elBuilder.Entity<Doctor>().HasOne(p => p.User).WithMany().HasForeignKey(d=>d.Dr_ID).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
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
        public DbSet<User_Role> UserRole { get; set; }
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
