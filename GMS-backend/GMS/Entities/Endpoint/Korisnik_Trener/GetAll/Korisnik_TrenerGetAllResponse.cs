﻿namespace GMS.Entities.Endpoint.Korisnik_Trener.GetAll
{
    public class Korisnik_TrenerGetAllResponse
    {
        public List<KorisnikTrenerGetAllResponseRow> KorisnikTrener { get; set; }
    }

    public class KorisnikTrenerGetAllResponseRow
    {
        public int KorisnikID { get; set; }
        public int TrenerID { get; set; }
        public int OdrzanoSati { get; set; }
        public DateTime DatumiVrijemeOdrzavanja { get; set; }
    }
}
