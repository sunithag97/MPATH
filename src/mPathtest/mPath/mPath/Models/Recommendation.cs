namespace mPath.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int PatientId { get; set; } // Foreign key property
        public Patient Patient { get; set; } // Navigation property
    }
}
