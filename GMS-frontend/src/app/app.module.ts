import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HttpClientModule} from "@angular/common/http";
import {FaqPageComponent } from './faq-page/faq-page.component';
import {OsobljePageComponent} from "./osoblje-page/osoblje-page.component";
import {SuplementiPageComponent} from "./suplementi-page/suplementi-page.component";
import {HomePageComponent} from "./home-page/home-page.component";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";



@NgModule({
    declarations: [
        AppComponent,
        FaqPageComponent,
        OsobljePageComponent,
        SuplementiPageComponent,
        HomePageComponent
    ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path:'HomePage', component: HomePageComponent },
      {path:'FAQPage', component: FaqPageComponent },
      {path:'OsobljePage', component: OsobljePageComponent },
      {path:'SuplementiPage', component: SuplementiPageComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
