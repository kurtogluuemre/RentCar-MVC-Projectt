using MVC_CASE.Contracts;

namespace MVC_CASE.UnitOfWorks
{
    /// <summary>
    /// Repository nesnelerinin bir arada yönetilmesini ve tek bir yerden erişilmesini sağlayan yapı.
    /// Ayrıca save changes  işlemini de yönetir.
    /// </summary>
    public interface IManagerRepository
    {
        /// <summary>
        /// Kategori işlemleri için repository erişimi sağlar.
        /// </summary>
        ICategoryRepository CategoryRepository { get; }

        /// <summary>
        /// Araba işlemleri için repository erişimi sağlar.
        /// </summary>
        ICarRepository CarRepository { get; }

        /// <summary>
        ///  Kiralama işlemleri için repository erişimi sağlar.
        /// </summary>
        IRentalRepository RentalRepository { get; }

        /// <summary>
        /// Yapılan değişiklikleri veritabanına kaydeder.
        /// </summary>
        /// <returns>İşlem başarılıysa true, değilse false döner.</returns>
        bool Save();
    }
}
