using GMS.Entities.Endpoint.Korisnik_Clanarina.GetById;

namespace GMS.Entities.Endpoint.Nutricionist_Seminar.GetById
{
    public class NutricionistSeminarGetResponse
    {
        public int NutricionistID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<NutricionistSeminarGetResponsePrisustvoSeminaru> PrisustvoSeminaru { get; set; }
    }

    public class NutricionistSeminarGetResponsePrisustvoSeminaru
    {
        public int NutricionistID { get; set; }
        public int SeminarID { get; set; }
    }
}
