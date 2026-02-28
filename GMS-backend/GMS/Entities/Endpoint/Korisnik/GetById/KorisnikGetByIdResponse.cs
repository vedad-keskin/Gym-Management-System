using GMS.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Entities.Endpoint.Korisnik.GetById;

public class KorisnikGetByIdResponse
{
    public int KorisnikID { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Username { get; set; }

    public string? Slika { get; set; }

    public string BrojTelefona { get; set; }
    public float Visina { get; set; }
    public float Tezina { get; set; }


    public string NazivGrada { get; set; }

    public string NazivSpola { get; set; }

    public string NazivTeretane { get; set; }

}

