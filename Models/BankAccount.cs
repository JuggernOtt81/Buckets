namespace Buckets.Models
{
    public class BankAccount
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? RoutingNumber { get; set; }
        public string? AccountNumber { get; set; }
        public string? Description { get; set; }
        public string? ReportedBalance { get; set; }
        public string? AdjustedBalance { get; set; }
        public string AccountHeader { get { return $"{Name} {AccountNumber}"; } }
    }
}
