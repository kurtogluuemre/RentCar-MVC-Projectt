using Microsoft.AspNetCore.Identity;
using MVC_CASE.Enums;

namespace MVC_CASE.Models
{
    /// <summary>
    /// Uygulamada kimlik doğrulama ve kullanıcı yönetimi için kullanılan kullanıcı sınıfı.
    /// IdentityUser sınıfından türetilmiştir.
    /// </summary>
    public class Kullanici : IdentityUser
    {
        private string _fullName;
        public UserRole Role { get; set; } = UserRole.User;
        public virtual ICollection<Rental> Kiralamalar { get; set; }

        /// <summary>
        /// Kullanıcının tam adını encapsulationla tutan property.
        /// </summary>
        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        
    }
}
