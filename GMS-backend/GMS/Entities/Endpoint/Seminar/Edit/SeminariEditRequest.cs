namespace GMS.Entities.Endpoint.Seminar.Edit
{
    public class SeminariEditRequest
    {
        public int ID { get; set; }
        public string Tema { get; set; }
        public string Predavac { get; set; }
        public DateTime Datum { get; set; }
    }
}
