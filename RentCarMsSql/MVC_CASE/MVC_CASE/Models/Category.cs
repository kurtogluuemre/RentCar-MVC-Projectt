using MVC_CASE.Abstracts;

namespace MVC_CASE.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
