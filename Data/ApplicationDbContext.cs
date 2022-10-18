using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Buckets.Models;

namespace Buckets.Data
{
    public class ApplicationDbContext : IdentityDbContext<BucketUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Buckets.Models.BankAccount> BankAccount { get; set; }
        public DbSet<Buckets.Models.Bill> Bill { get; set; }
        public DbSet<Buckets.Models.Income> Income { get; set; }
        public DbSet<Buckets.Models.Expense> Expense { get; set; }
        public DbSet<Buckets.Models.Bucket> Bucket { get; set; }
        public DbSet<Buckets.Models.BucketUser> BucketUser { get; set; }
        public DbSet<Buckets.Models.Dashboard> Dashboard { get; set; }
    }
}