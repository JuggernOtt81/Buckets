namespace Buckets.Models
{
    public class Bucket
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Priority { get; set; }
        public double Income { get; set; }
        public double Outflow { get; set; }
        public double Spillover { get { return Income - Outflow; } }
    }
}
