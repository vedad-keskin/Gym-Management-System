namespace GMS.Entities.Endpoint.Nutricionist.Edit
{
    public class NutricionistiEditRequest
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string? Slika { get; set; }
    }
}
