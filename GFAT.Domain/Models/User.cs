
using GFAT.Domain.Enum;
namespace GFAT.Domain.Models;

    public class User
    {
        public long id { get; set; }
        
        public string Password { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }
        
        public Profile Profile { get; set; }
        
        public Basket Basket { get; set; }
    }
