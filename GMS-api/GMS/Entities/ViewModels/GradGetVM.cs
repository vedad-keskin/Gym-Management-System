namespace GMS.Entities.ViewModels
{
    public class GradGetVM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public string Opis => ID + " " + Naziv;
    }
}
