import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PlanetListComponent } from './components/planets/planet-list/planet-list.component';
import { ConfigService } from './shared/services/config.service';
import { PlanetService } from './shared/services/planet.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PlanetListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    ConfigService,
    PlanetService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
