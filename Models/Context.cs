
using Microsoft.EntityFrameworkCore;

namespace BharatMedics.Models
{
    public class Context:DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Order> Orders { get; set; }



    }
}
