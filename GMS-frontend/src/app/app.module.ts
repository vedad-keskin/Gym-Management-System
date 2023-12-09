import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {OsobljePageComponent} from "./osoblje-page/osoblje-page.component";
import {SuplementiPageComponent} from "./suplementi-page/suplementi-page.component";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { LoginPageComponent } from './login-page/login-page.component';
import {MyAuthInterceptor} from "./helpers/auth/my-auth-interceptor-service";
import {FaqPageComponent} from "./faq-page/faq-page.component";
import {HomePageComponent} from "./home-page/home-page.component";
import {KorisnikPageComponent} from "./korisnik-page/korisnik-page.component";
import {AdministratorPageComponent} from "./administrator-page/administrator-page.component";
import {AutorizacijaGuardKorisnik} from "./helpers/auth/autorizacija-guard-korisnik.service";
import {
    AutorizacijaGuardAdministrator
} from "./helpers/auth/autorizacija-guard-administrator.service";
import { AdministratorPageGradoviComponent } from './administrator-page-gradovi/administrator-page-gradovi.component';
import { AdministratorPageClanarineComponent } from './administrator-page-clanarine/administrator-page-clanarine.component';
import { AdministratorPageDobavljaciComponent } from './administrator-page-dobavljaci/administrator-page-dobavljaci.component';



@NgModule({
    declarations: [
        AppComponent,
        FaqPageComponent,
        OsobljePageComponent,
        SuplementiPageComponent,
        HomePageComponent,
        LoginPageComponent,
        KorisnikPageComponent,
        AdministratorPageComponent,
        AdministratorPageGradoviComponent,
        AdministratorPageClanarineComponent,
        AdministratorPageDobavljaciComponent
    ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', redirectTo: '/HomePage', pathMatch: 'full' },
      {path:'HomePage', component: HomePageComponent },
      {path:'FAQPage', component: FaqPageComponent },
      {path:'OsobljePage', component: OsobljePageComponent },
      {path:'SuplementiPage', component: SuplementiPageComponent },
      {path:'LoginPage', component: LoginPageComponent },
      {path:'KorisnikPage', component: KorisnikPageComponent, canActivate: [AutorizacijaGuardKorisnik] },
      {path:'AdministratorPage', component: AdministratorPageComponent, canActivate: [AutorizacijaGuardAdministrator]  },
      {path:'AdministratorPageGradovi', component: AdministratorPageGradoviComponent, canActivate: [AutorizacijaGuardAdministrator] },
      {path:'AdministratorPageClanarine', component: AdministratorPageClanarineComponent, canActivate: [AutorizacijaGuardAdministrator] },
      {path:'AdministratorPageDobavljaci', component: AdministratorPageDobavljaciComponent  },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: MyAuthInterceptor, multi: true },
      AutorizacijaGuardKorisnik,
      AutorizacijaGuardAdministrator
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
