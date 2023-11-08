namespace GMS.Entities.Endpoint.FAQ.GetAll
{
    public class FAQGetAllResponse
    {
        public List<FAQGetAllResponseRow> FAQ { get; set; }
    }

    public class FAQGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Pitanje { get; set; }
        public string Odgovor { get; set; }
    }


}
