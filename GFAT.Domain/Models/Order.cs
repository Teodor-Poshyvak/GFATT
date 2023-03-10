namespace GFAT.Domain.Models;



    public class Order
    {
        public long id { get; set; }
        
        public long FoodId { get; set; }

        public DateTime DateCreated { get; set; }

        public string Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public long? BasketId { get; set; }

        public virtual Basket Basket { get; set; }
    }   
