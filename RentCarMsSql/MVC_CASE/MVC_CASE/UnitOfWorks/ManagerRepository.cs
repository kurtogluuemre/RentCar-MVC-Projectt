using MVC_CASE.Concretes;
using MVC_CASE.Contexts;
using MVC_CASE.Contracts;

namespace MVC_CASE.UnitOfWorks
{
    /// <summary>
    /// Repository nesnelerinin yönetimini ve veritabanı işlemlerini gerçekleştiren sınıf.
    /// Repositoryleri Lazy Loading ile oluşturur.
    /// </summary>
    public class ManagerRepository : IManagerRepository
    {

        private readonly AppDbContext _context;

        private readonly Lazy<ICategoryRepository> _CategoryRepository;
        private readonly Lazy<ICarRepository> _CarRepository;
        private readonly Lazy<IRentalRepository> _RentalRepository;


        public ManagerRepository(AppDbContext context)
        {
            _context = context;

            // Repositoryler ihtiyaç duyulduğunda oluşturulacak şekilde ayarlanıyor.
            _CategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _CarRepository = new Lazy<ICarRepository>(() => new CarRepository(_context));
            _RentalRepository = new Lazy<IRentalRepository>(() => new RentalRepository(_context));
        }

        /// <summary>
        /// Kategori repository erişimi sağlar.
        /// </summary>
        public ICategoryRepository CategoryRepository => _CategoryRepository.Value;

        /// <summary>
        /// Car repository erişimi sağlar.
        /// </summary>
        public ICarRepository CarRepository => _CarRepository.Value;

        /// <summary>
        /// Kiralama sınıfını repository erişimi sağlar.
        /// </summary>
        public IRentalRepository RentalRepository => _RentalRepository.Value;


        /// <summary>
        /// Yapılan değişiklikleri veritabanına kaydeder.
        /// </summary>
        /// <returns>İşlem başarılıysa true, değilse false döner.</returns>
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
