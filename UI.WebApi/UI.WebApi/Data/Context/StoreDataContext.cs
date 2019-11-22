using Microsoft.EntityFrameworkCore;
using UI.WebApi.Data.Mappings;
using UI.WebApi.Dominio;

namespace UI.WebApi.Data.Context
{

    public class ReservaCarroContexto : DbContext
    {
        public class StoreDataContext : DbContext
        {
            public DbSet<ReservaCarro> ReservasCarro { get;set;}

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase();
            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.ApplyConfiguration(new ReservaCarroMap());
            }
        }
    }
}
