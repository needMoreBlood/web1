using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace TatooParlor.Web.Models
{
    //namespace DataAccessPostgreSqlProvider
    //{
        public class TatooParlorDbContext : DbContext
        {
            public TatooParlorDbContext()
            {

                Database.EnsureCreated();
            }

            public TatooParlorDbContext(DbContextOptions<TatooParlorDbContext> options) : base(options)
            {
            }

            public DbSet<DbTatooSalon> TatooSalons { get; set; }
            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(TatooParlorDbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }


        public class DbTatooSalon
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public virtual Collection<DbRegistration> Journal { get; set; }

            public List<Comments> CommetsPage { get; set; }

            public string VisitorName { get; set; }

            public string Age { get; set; }

            public byte[] Photo { get; set; }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        public class DbRegistration
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int TatooSalonId { get; set; }
            [ForeignKey("TatooSalonId")]
            public virtual DbTatooSalon TatooSalon { get; set; }

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
    //}
}
