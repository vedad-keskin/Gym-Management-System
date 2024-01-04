import {Component, OnInit} from '@angular/core';
import {MyAuthService} from "../services/MyAuthService";
import {KorisnikGetByIdEndpoint, KorisnikGetByIdResponse} from "../endpoints/korisnik-endpoints/korisnik-get-endpoint";
import {
  Korisnik_ClanarinaGetAllEndpoint, Korisnik_ClanarinaGetAllResponse, Korisnik_ClanarinaGetAllResponseKorisnikClanarina
} from "../endpoints/korisnik-endpoints/korisnik-clanarina-endpoints/korisnik-clanarina-getall-endpoint";
import {
  Korisnik_SuplementGetAllEndpoint, Korisnik_SuplementGetAllResponse,
  Korisnik_SuplementGetAllResponseKorisnik_Suplement
} from "../endpoints/korisnik-endpoints/korisnik-suplementi-endpoints/korisnik-suplement-getall-endpoint";
import {
  Korisnik_TrenerGetAllEndpoint, Korisnik_TrenerGetAllResponse, Korisnik_TrenerGetAllResponseKorisnik_Trener
} from "../endpoints/korisnik-endpoints/korisnik-treneri-endpoints/korisnik-trener-getall-endpoint";
import {
  Korisnik_NutricionistGetAllEndpoint,
  Korisnik_NutricionistGetAllResponse,
  Korisnik_NutricionistGetAllResponseKorisnik_Nutricionist
} from "../endpoints/korisnik-endpoints/korisnik-nutricionst-endpoints/korisnik-nutricionist-getall-endpoint";


@Component({
  selector: 'app-korisnik-page',
  templateUrl: './korisnik-page.component.html',
  styleUrls: ['./korisnik-page.component.css']
})
export class KorisnikPageComponent implements OnInit{

  constructor(private myAuthService: MyAuthService,
              private KorisnikGetByIdEndpoint:KorisnikGetByIdEndpoint,
              private Korisnik_ClanarinaGetAllEndpoint:Korisnik_ClanarinaGetAllEndpoint,
              private Korisnik_SuplementGetAllEndpoint:Korisnik_SuplementGetAllEndpoint,
              private Korisnik_TrenerGetAllEndpoint:Korisnik_TrenerGetAllEndpoint,
              private Korisnik_NutricionistGetAllEndpoint:Korisnik_NutricionistGetAllEndpoint) {
  }

  korisnik_clanarine: Korisnik_ClanarinaGetAllResponseKorisnikClanarina[] = [];
  korisnikSuplement: Korisnik_SuplementGetAllResponseKorisnik_Suplement[] = [];
  korisnikTrener: Korisnik_TrenerGetAllResponseKorisnik_Trener[] = [];
  korisnikNutricionist: Korisnik_NutricionistGetAllResponseKorisnik_Nutricionist[] = [];


  public odabraniKorisnik : KorisnikGetByIdResponse | null = null;
  id:number = 0
  ngOnInit() {
    this.id = this.myAuthService.returnId()!;

    this.KorisnikGetByIdEndpoint.Handle(this.id).subscribe({
          next: x => {
            this.odabraniKorisnik = x;
          }
        }
    )

    this.fetchKorisniciClanarine();
    this.fetchKorisniciSuplementi();
    this.fetchKorisniciTreneri();
    this.fetchKorisniciNutricionsti();
  }


  GetFiltiraneClanarine() {
    return this.korisnik_clanarine.filter(x=> x.korisnikID == this.id );
  }

  GetFiltiraneSuplemente() {
    return this.korisnikSuplement.filter(x=> x.korisnikID == this.id );
  }

  GetFiltiraneTreninzi() {
    return this.korisnikTrener.filter(x=> x.korisnikID == this.id );
  }
  GetFiltiraneTerminiNutricioniste() {
    return this.korisnikNutricionist.filter(x=> x.korisnikID == this.id );
  }

  private fetchKorisniciNutricionsti() {
    this.Korisnik_NutricionistGetAllEndpoint.Handle().subscribe((x:Korisnik_NutricionistGetAllResponse )=>{
      this.korisnikNutricionist = x.korisnikNutricionist;
    });
  }

  private fetchKorisniciTreneri() {
    this.Korisnik_TrenerGetAllEndpoint.Handle().subscribe((x:Korisnik_TrenerGetAllResponse )=>{
      this.korisnikTrener = x.korisnikTrener;
    });
  }

  private fetchKorisniciSuplementi() {
    this.Korisnik_SuplementGetAllEndpoint.Handle().subscribe((x:Korisnik_SuplementGetAllResponse )=>{
      this.korisnikSuplement = x.korisnikSuplement;
    });
  }

  private fetchKorisniciClanarine() {
    this.Korisnik_ClanarinaGetAllEndpoint.Handle().subscribe((x:Korisnik_ClanarinaGetAllResponse )=>{
      this.korisnik_clanarine = x.korisnik_Clanarina;
    });
  }
}
