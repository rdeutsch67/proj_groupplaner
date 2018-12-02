import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {GruppenListeComponent} from "./components/gruppe/gruppen-liste.component";
import {GruppeComponent} from "./components/gruppe/gruppe.component";
import {TeilnehmerComponent} from "./components/teilnehmer/teilnehmer.component";
import {AboutComponent} from "./components/about/about.component";
import {PageNotFoundComponent} from "./components/pagenotfound.component/pagenotfound.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GruppenListeComponent,
    GruppeComponent,
    TeilnehmerComponent,
    AboutComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'gruppen/alle/:count', component: GruppenListeComponent },
      { path: 'teilnehmer', component: TeilnehmerComponent },
      { path: 'about', component: AboutComponent },
      { path: '**', component: PageNotFoundComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
