﻿namespace GMS.Entities.Endpoint.Nutricionisti.GetAll
{
    public class NutricionistiGetAllResponse
    {
        public List<NutricionistiGetAllResponseRow> Nutricionisti { get; set; }
    }

    public class NutricionistiGetAllResponseRow
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string? Slika { get; set; }
    }
}
