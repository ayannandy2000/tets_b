namespace TestProject.Models
{
    public class CartItem
    {
     public int Id { get; set; }
        public string ProductName { get; set; }

        public string ProductId { get; set; }

        public int quantity { get; set; }
        public string Price { get; set;}

        public string Discount { get; set;}

        public int CartId { get; set; }
    }
}
