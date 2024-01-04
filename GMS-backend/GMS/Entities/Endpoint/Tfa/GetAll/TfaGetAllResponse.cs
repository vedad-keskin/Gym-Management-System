namespace GMS.Entities.Endpoint.Tfa.GetAll
{
    public class TfaGetAllResponse
    {
        public List<TfasGetAllResponseRow> Tfas { get; set; }
    }

    public class TfasGetAllResponseRow
    {
        public int ID { get; set; }
        public string TwoFKey { get; set; }
    }
}
