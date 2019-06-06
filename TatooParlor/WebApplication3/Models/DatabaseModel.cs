using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace WebApplication3.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        // >dotnet ef migration add testMigration in AspNet5MultipleProject
        public class TatooParlorDbContext : DbContext
        {
            public TatooParlorDbContext()
            {

                Database.EnsureCreated();
            }

            public TatooParlorDbContext(DbContextOptions<TatooParlorDbContext> options) : base(options)
            {
            }

            public DbSet<DbTatooParlor> SpaceShips { get; set; }
            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(TatooParlorDbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }


        public class DbTatooParlor
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            
            public virtual Collection<DbFlight> Journal { get; set; }
        }
        

        public class DbFlight
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int SpaceShipId { get; set; }
            [ForeignKey("SpaceShipId")]
            public virtual DbTatooParlor SpaceShip { get; set; }

            public string VisitorName { get; set; }

            public string Age { get; set; }

            public string Contacts { get; set; }

            public string Gender { get; set; }

            public DateTime DateToVisit { get; set; }

            public string TatooStyles { get; set; }

            public string BodyPart { get; set; }

            public string Master { get; set; }

            public override string ToString()
            {
                return $" Телефон: {Contacts}, Часть тела: {BodyPart}," +
                 $"Cтиль тату: {TatooStyles}, Мастер: {Master}, Дата: {DateToVisit}";
            }
        }
    }
}