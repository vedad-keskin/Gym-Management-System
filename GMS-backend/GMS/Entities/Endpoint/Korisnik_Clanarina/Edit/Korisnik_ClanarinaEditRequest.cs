namespace GMS.Entities.Endpoint.Korisnik_Clanarina.Edit
{
    public class Korisnik_ClanarinaEditRequest
    {
        public int KorisnikID { get; set; }
        public int ClanarinaID { get; set; }
      
        public DateTime DatumUplate { get; set; }
        public DateTime DatumIsteka { get; set; }
    }
}
