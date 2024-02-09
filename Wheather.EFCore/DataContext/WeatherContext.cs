using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Weather.Domain.POCOs;

namespace Weather.EFCore.DataContext
{

    public class WeatherContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public WeatherContext(DbContextOptions<WeatherContext> options, IConfiguration configuration) :
            base(options)
        {
            _configuration = configuration;
        }

        public DbSet<SearchHistory> SearchHistories { get; set; }


        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();

            var result = base.SaveChanges();


            return result;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStrings = _configuration != null ? _configuration["ConnectionStrings:DbConection"] : "none";
            optionsBuilder.UseSqlServer(connectionStrings);
        }
    }
}
