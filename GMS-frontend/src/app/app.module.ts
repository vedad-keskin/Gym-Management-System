import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HttpClientModule} from "@angular/common/http";
import { FaqPageComponent } from './faq-page/faq-page.component';
import { OsobljePageComponent } from './osoblje-page/osoblje-page.component';
import { SuplementiPageComponent } from './suplementi-page/suplementi-page.component';
import {FormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    AppComponent,
    FaqPageComponent,
    OsobljePageComponent,
    SuplementiPageComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
