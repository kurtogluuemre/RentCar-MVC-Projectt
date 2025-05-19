namespace MVC_CASE.Models.VMs
{
    public class CarCardViewModel
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimUrl { get; set; } // Eğer resim varsa
    }

}
