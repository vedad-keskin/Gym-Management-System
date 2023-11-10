import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HttpClientModule} from "@angular/common/http";
import { FaqPageComponent } from './faq-page/faq-page.component';
import { OsobljePageComponent } from './osoblje-page/osoblje-page.component';


@NgModule({
  declarations: [
    AppComponent,
    FaqPageComponent,
    OsobljePageComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
