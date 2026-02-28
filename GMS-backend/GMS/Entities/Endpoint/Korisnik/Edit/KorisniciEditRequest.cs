namespace GMS.Entities.Endpoint.Korisnik.Edit
{
    public class KorisniciEditRequest
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string? Slika { get; set; }

        public string BrojTelefona { get; set; }
        public float Visina { get; set; }
        public float Tezina { get; set; }

        public int GradID { get; set; }
        public int SpolID { get; set; }
        public int TeretanaID { get; set; }
       
    }
}
