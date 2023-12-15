namespace GMS.Entities.Endpoint.Korisnik_Clanarina.GetById;

public class KorisnikClanarinaGetResponse
{
    public int KorisnikID { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public List<KorisnikClanarineGetResponseUplaceneClanarine> UplaceneClanarine { get; set; }
}

public class KorisnikClanarineGetResponseUplaceneClanarine
{
    public int KorisnikID { get; set; }
    public int ClanarinaID { get; set; }
    public string NazivClanarine { get; set; }
    public float Cijena { get; set; }
    public DateTime DatumUplate { get; set; }
    public DateTime? DatumIsteka { get; set; }

}