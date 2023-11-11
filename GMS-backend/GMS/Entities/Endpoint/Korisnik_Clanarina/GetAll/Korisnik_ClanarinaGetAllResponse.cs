namespace GMS.Entities.Endpoint.Korisnik_Clanarina.GetAll
{
    public class Korisnik_ClanarinaGetAllResponse
    {
        public List<KorisnikClanarinaGetAllResponseRow> Korisnik_Clanarina { get; set; }
    }

    public class KorisnikClanarinaGetAllResponseRow
    {
        public int KorisnikID { get; set; }
        public int ClanarinaID { get; set; }
        public DateTime DatumUplate { get; set; }
        public DateTime DatumIsteka { get; set; }
    }
}
