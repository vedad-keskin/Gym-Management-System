namespace GMS.Entities.Models
{
    public class Trener_Seminar
    {
        public int TrenerID { get; set; }
        public Trener Trener { get; set; }
        public int SeminarID { get; set; }
        public Seminar Seminar { get; set; }

    }
}
