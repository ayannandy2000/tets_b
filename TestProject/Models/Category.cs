namespace TestProject.Models
{
    public class Category
    {
        public int ID { get;set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedAT { get; set; }
        public DateTime ModifiedAt { get; set;}
        public string CreatedBY { get; set;}
        public string ModifiedBY { get; set;}
        public bool IsActive { get; set; }
    }
}
