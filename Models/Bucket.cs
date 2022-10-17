namespace Buckets.Models
{
    public class Bucket
    {
        public string? Id { get; set; }
        public string? BucketName { get; set; }
        public string? Priority { get; set; }
        public double Income { get; set; }
        public double BucketCapacity { get; set; }
        public double Outflow { get; set; }

        public string AccountHeader { get { return $"{BucketName} | {BucketCapacity} | {Priority}"; } }
        public double Spillover { get { return ((BucketCapacity - Outflow) + Income); } }
    }
}
