using Microsoft.EntityFrameworkCore;

namespace MicroService.Services.Payment.WebApi.DAL
{
    public class PaymentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PaymentDb;User=sa;Password=123456Aa*");
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

    }
}
