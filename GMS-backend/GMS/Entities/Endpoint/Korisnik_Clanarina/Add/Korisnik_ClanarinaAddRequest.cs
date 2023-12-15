namespace GMS.Entities.Endpoint.Korisnik_Clanarina.Add
{
    public class Korisnik_ClanarinaAddRequest
    {
        public int KorisnikID { get; set; }
        public int ClanarinaID { get; set; }

        public DateTime DatumUplate { get; set; }
        public DateTime DatumIsteka { get; set; }
    }
}
