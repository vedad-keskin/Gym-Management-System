namespace GMS.Entities.Endpoint.Suplement.Edit
{
    public class SuplementiEditRequest
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public float Gramaza { get; set; }
        public string Opis { get; set; }
        public string? Slika { get; set; }
        public int DobavljacID { get; set; }
        public int KategorijaID { get; set; }
        
    }
}
