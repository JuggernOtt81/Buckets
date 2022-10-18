using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Buckets.Models
{
    public class BucketUser : IdentityUser
    {
        //public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PrimaryAccount { get; set; }
        public string? NetWorth { get; set; }
        public string? TotalDebt { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public virtual ICollection<Bucket> Buckets { get; set; } = new HashSet<Bucket>();
        public virtual ICollection<BankAccount> BankAccounts { get; set; } = new HashSet<BankAccount>();
        public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
        public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
        public virtual ICollection<Income> Incomes { get; set; } = new HashSet<Income>();
        public virtual ICollection<Dashboard> Dashboards { get; set; } = new HashSet<Dashboard>();
    }
}
