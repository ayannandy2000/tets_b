namespace TestProject.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PinCode { get; set; }
        public string Landmark { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
        public bool IsActive { get; set; }

    }
}
