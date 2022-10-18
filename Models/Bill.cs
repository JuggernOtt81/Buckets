namespace Buckets.Models
{
    public class Bill
    {
        public string? Id { get; set; }
        public string? BillName { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? Classification { get; set; }
        public string? Priority { get; set; }
        public string? AccountNumber { get; set; }
        public double PastDueAmount { get; set; }
        public double PrePaidCreditAmount { get; set; }
        public double CurrentDueAmount { get; set; }
        public string BillHeader { get { return $"{BillName} | {CompanyName} | {AccountNumber}"; } }
    }
}
