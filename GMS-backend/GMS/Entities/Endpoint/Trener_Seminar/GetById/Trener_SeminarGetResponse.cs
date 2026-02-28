using GMS.Entities.Endpoint.Korisnik_Trener.GetById;

namespace GMS.Entities.Endpoint.Trener_Seminar.GetById
{
    public class TrenerSeminarGetResponse
    {
        public int TrenerID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<TrenerSeminarGetResponseOdrzanSeminar> OdrzanSeminar { get; set; }
    }

    public class TrenerSeminarGetResponseOdrzanSeminar
    {
        public int TrenerID { get; set; }
        public int SeminarID { get; set; }

        public string Tema { get; set; }
        public string Predavac { get; set; }
        public DateTime Datum { get; set; }
    }
}
