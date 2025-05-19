using MVC_CASE.Contexts;
using MVC_CASE.Contracts;
using MVC_CASE.Models;

namespace MVC_CASE.Concretes
{
    /// <summary>
    /// Generic Repository yaptığım için içine herhangi ekstra bir metot eklemiyorum
    /// </summary>
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }
    }
}
