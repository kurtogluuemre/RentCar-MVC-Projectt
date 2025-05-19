using MVC_CASE.Abstracts;

namespace MVC_CASE.Models
{
    public class Rental : BaseEntity
    {
        public string KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
