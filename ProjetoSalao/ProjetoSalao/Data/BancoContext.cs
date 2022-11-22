using Microsoft.EntityFrameworkCore;
using ProjetoSalao.Models;

namespace ProjetoSalao.Data
{
    public class BancoContext : DbContext
    {
		public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder model)
		{
			model.UseSerialColumns();
		}


		public DbSet<Client> Client { get; set; }
		public DbSet<Scheduling> Scheduling { get; set; }
		public DbSet<Provider> Provider { get; set; }
		public DbSet<Service> Service { get; set; }
		public DbSet<Product> Product { get; set; }
	}
}
