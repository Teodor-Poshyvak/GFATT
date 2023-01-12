

namespace GFAT.Domain.Models;

public class Basket
    {
        public long id { get; set; }
        
        public User User { get; set; }
        
        public long UserId { get; set; }
        
        public List<Order> Orders { get; set; }
    }

