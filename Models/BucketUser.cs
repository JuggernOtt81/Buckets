namespace Buckets.Models
{
    public class BucketUser
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PrimaryAccount { get; set; }
        public string? NetWorth { get; set; }
        public string? TotalDebt { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
