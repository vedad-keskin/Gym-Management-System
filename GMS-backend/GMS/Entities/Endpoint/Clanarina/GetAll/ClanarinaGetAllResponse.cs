namespace GMS.Entities.Endpoint.FAQ.GetAll
{
    public class ClanarinaGetAllResponse
    {
        public List<ClanarinaGetAllResponseRow> Clanarine { get; set; }
    }

    public class ClanarinaGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public string Opis { get; set; }
    }


}
