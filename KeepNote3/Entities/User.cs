
namespace KeepNote3.Entities
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }    
        public string password { get; set; }    
        public string contact { get; set; } 
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
