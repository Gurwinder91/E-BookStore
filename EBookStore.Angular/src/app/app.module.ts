import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BsCoreModule } from './core/bs-core.module';
import { HTTP_INTERCEPTORS_PROVIDERS } from './http-interceptors';
import { PageNotfoundComponent } from './pages/page-notfound/page-notfound.component';

@NgModule({
  declarations: [
    AppComponent,
    PageNotfoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    BsCoreModule
  ],
  providers: [...HTTP_INTERCEPTORS_PROVIDERS],
  bootstrap: [AppComponent]
})
export class AppModule { }
