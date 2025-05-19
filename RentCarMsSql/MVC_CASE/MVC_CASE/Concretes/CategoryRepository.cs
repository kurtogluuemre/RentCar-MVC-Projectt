using MVC_CASE.Contexts;
using MVC_CASE.Contracts;
using MVC_CASE.Models;

namespace MVC_CASE.Concretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
