using MVC_CASE.Abstracts;

namespace MVC_CASE.Models
{
    public class Car : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ResimUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }

}
