using GMS.Entities.Endpoint.Korisnik_Trener.GetById;

namespace GMS.Entities.Endpoint.Trener_Seminar.GetById
{
    public class Trener_SeminarGetResponse
    {
        public int TrenerID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<Trener_SeminarGetResponseOdrzanSeminar> OdrzanSeminar { get; set; }
    }

    public class Trener_SeminarGetResponseOdrzanSeminar
    {
        public int TrenerID { get; set; }
        public int SeminarID { get; set; }
    }
}
