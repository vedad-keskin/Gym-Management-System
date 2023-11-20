namespace GMS.Entities.Endpoint.Korisnik_Clanarina.Add
{
    public class Korisnik_ClanarinaAddRequest
    {
        public int KorisnikID { get; set; }
        public int ČlanarinaID { get; set; }

        public DateTime DatumUplate { get; set; }
        public DateTime DatumIsteka { get; set; }
    }
}
