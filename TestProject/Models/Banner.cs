namespace TestProject.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public int ProductID { get; set; }
        public DateTime CreatedAT { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string CreatedBY { get; set; }
        public string ModifiedBY { get; set; }
        public bool IsLanding { get; set; }
        public bool IsActive { get; set; }
    }
}
