import { Component, Inject, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "code_aktivitaeten-edit.component",
  templateUrl: './code_aktivitaeten-edit.component.html',
  styleUrls: ['./code_aktivitaeten-edit.component.css']
})

export class Code_aktivitaetenEditComponent {
  code: string;
  code_aktivitaet: Code_aktivitaet;
  editMode: boolean;

  constructor(private activatedRoute: ActivatedRoute,
              private router: Router,
              private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) {

    // leeres Aktivität-Objekt erstellen
    this.code_aktivitaet = <Code_aktivitaet>{};
    let id = +this.activatedRoute.snapshot.params["id"];  // Id der Gruppe
    // check if we're in edit mode or not
    this.editMode = (this.activatedRoute.snapshot.url[1].path === "edit");

    if (this.editMode) {
      // fetch the quiz from the server
      let url = this.baseUrl + "api/zaktivitaet/" + id;
      this.http.get<Code_aktivitaet>(url).subscribe(res => {
        this.code_aktivitaet = res;
        this.code = "Edit - " + this.code_aktivitaet.Code;
      }, error => console.error(error));
    }
    else {
      this.code_aktivitaet.GruppenId = id;
      this.code = "Erstelle neue Gruppenaktivität";
    }
  }

  onSubmit(code_aktivitaet: Code_aktivitaet) {
    let url = this.baseUrl + "api/zaktivitaet";
    if (this.editMode) {
      this.http
        .post<Code_aktivitaet>(url, code_aktivitaet)
        .subscribe(res => {
          let v = res;
          console.log("Aktivität " + v.Id + " wurde aktualisiert.");
          this.router.navigate(["zaktivitaet/edit", v.GruppenId]);
        }, error => console.log(error));
    }
    else {
      this.http
        .put<Code_aktivitaet>(url, code_aktivitaet)
        .subscribe(res => {
          let v = res;
          console.log("Aktivität " + v.Id + " wurde erstellt.");
          this.router.navigate(["zaktivitaet/edit", v.GruppenId]);
        }, error => console.log(error));
    }
  }

  onBack() {
    this.router.navigate(["zaktivitaet/edit", this.code_aktivitaet.GruppenId]);
  }
}
