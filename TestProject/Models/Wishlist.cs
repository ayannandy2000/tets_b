namespace TestProject.Models
{
    public class Wishlist
    {

        public int Id { get; set; }
        public string ProductName { get; set; }

        public string ProductId { get; set; }

        public int quantity { get; set; }
        public string Price { get; set; }
        public string image { get; set; }

        public int rating { get; set; }
        public string Discount { get; set; }


        public DateTime CreatedAt { get; set; }
        public int userId { get; set; }
        public string CreatedBy { get; set; }
    }
}
