namespace GMS.Entities.ViewModels
{
    public class SuplementAddVM
    {
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public float Gramaza { get; set; }
        public string Opis { get; set; }

        // public IFormFile Slika { get; set; }
        public int DobavljacID { get; set; }
        public int KategorijaID { get; set; }
    }
}
