using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_CASE.Models.VMs
{
    public class AdminCarVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marka alanı gereklidir.")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Model alanı gereklidir.")]
        public string? Model { get; set; }

        [Range(1900, 2100, ErrorMessage = "Yıl 1900 ile 2100 arasında olmalıdır.")]
        public int Year { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Fiyat sıfırdan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Resim URL alanı gereklidir.")]
        public string? ResimUrl { get; set; }

        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Kategori seçilmelidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kategori seçin.")]
        public int CategoryId { get; set; }

        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();
    }
}
