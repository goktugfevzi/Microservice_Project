using MicroService.Services.Discount.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MicroService.Services.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly DbContext _dbContext;



        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DiscountDb;User=sa;Password=123456Aa*");
        }

        public DbSet<DiscountCoupons> DiscountCouponses { get; set; }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);

    }
}
