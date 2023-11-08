namespace GMS.Entities.Models
{
    public class Nutricionist_Seminar
    {
        public int NutricionistID { get; set; }
        public Nutricionist Nutricionist { get; set; }
        public int SeminarID { get; set; }
        public Seminar Seminar { get; set; }
    }
}
