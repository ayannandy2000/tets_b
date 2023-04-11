﻿namespace TestProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductId { get; set; }

        public int quantity { get; set; }
        public string TotalPrice { get; set; }
        public string image { get; set; }

        public int rating { get; set; }
        public string AmountSaved{ get; set; }

        public string transactionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int userId { get; set; }
        public string CreatedBy { get; set; }

        public int AddressId { get; set; }
    }
}