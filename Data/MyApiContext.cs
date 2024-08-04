using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Data
{
    public class MyApiContext : DbContext
    {
        public MyApiContext(DbContextOptions<MyApiContext> options)
            : base(options)
        {
        }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
