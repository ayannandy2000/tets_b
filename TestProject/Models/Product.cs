namespace TestProject.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int BannerID { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public string price { get; set; }
        public string keyfeature1 { get; set; }
        public string keyfeature2 { get; set; }
        public string keyfeature3 { get; set; }
        public string keyfeature4 { get; set; }
        public float rating { get; set; }
        public int reviewID { get; set; }
        public int offerID { get; set; }
        public string discountPercent { get; set; }
        public int quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
        
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set;}
    }
}
