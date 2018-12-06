import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsDatepickerModule} from "ngx-bootstrap";
import {GruppenListeComponent} from "./components/gruppe/gruppen-liste.component";
import {GruppeComponent} from "./components/gruppe/gruppe.component";
import {AboutComponent} from "./components/about/about.component";
import {PageNotFoundComponent} from "./components/pagenotfound.component/pagenotfound.component";
import {GruppeEditComponent} from "./components/gruppe/gruppe-edit.component";
import {Code_aktivitaetenEditComponent} from "./components/code_aktivitaeten/code_aktivitaeten-edit.component";
import {Code_aktivitaetenListeComponent} from "./components/code_aktivitaeten/code_aktivitaeten-liste.component";
import {TeilnehmerListeComponent} from "./components/teilnehmer/teilnehmer-liste.component";
import {TeilnehmerEditComponent} from "./components/teilnehmer/teilnehmer-edit.component";
import {TerminEditComponent} from "./components/termin/termin-edit.component";
import {TerminListeComponent} from "./components/termin/termin-liste.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GruppenListeComponent,
    GruppeComponent,
    GruppeEditComponent,
    Code_aktivitaetenEditComponent,
    Code_aktivitaetenListeComponent,
    TeilnehmerListeComponent,
    TeilnehmerEditComponent,
    TerminEditComponent,
    TerminListeComponent,
    AboutComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: GruppenListeComponent },
      { path: 'gruppen/alle/:count', component: GruppenListeComponent },
      { path: 'gruppen/create', component: GruppeEditComponent},
      { path: 'gruppen/edit/:id', component: GruppeEditComponent},
      { path: 'gruppen/:id', component: GruppeComponent},
      { path: 'codesaktivitaeten/alle/:id', component: Code_aktivitaetenListeComponent }, // alle Codes zur Gruppe
      { path: 'codesaktivitaeten/create/:id', component: Code_aktivitaetenEditComponent},
      { path: 'codesaktivitaeten/edit/:id', component: Code_aktivitaetenEditComponent},
      { path: 'codesaktivitaeten/alle/0', component: Code_aktivitaetenListeComponent }, // alle Codes anzeigen
      { path: 'teilnehmer/alle/:id', component: TeilnehmerListeComponent },
      { path: 'teilnehmer/create/:id', component: TeilnehmerEditComponent },
      { path: 'teilnehmer/edit/:id', component: TeilnehmerEditComponent },
      { path: 'termine/alle/:id', component: TerminListeComponent },
      { path: 'termine/create/:id', component: TerminEditComponent },
      { path: 'termine/edit/:id', component: TerminEditComponent },
      { path: 'about', component: AboutComponent },
      { path: '**', component: PageNotFoundComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
