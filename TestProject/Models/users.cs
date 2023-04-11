using MessagePack;
using TestProject.Models;

namespace TestProject.models
{
    public class users
    {

        public int ID { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userRole { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public Boolean IsActive { get; set; }
        public List<Address> address { get; set; }
    }
}
