
import { Component, Inject, Input, OnChanges, SimpleChanges } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "code_aktivitaeten-liste",
  templateUrl: './code_aktivitaeten-liste.component.html',
  styleUrls: ['./code_aktivitaeten-liste.component.css']
})

export class Code_aktivitaetenListeComponent implements OnChanges {
  @Input() myGruppe: Gruppe;
  code_aktivitaeten: Code_aktivitaet[];
  code: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string,
              private router: Router) {

    this.code_aktivitaeten = [];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes['myGruppe'] !== "undefined") {

      // retrieve code_aktivitaet variable change info
      let change = changes['myGruppe'];
      // only perform the task if the value has been changed
      //if (!change.isFirstChange()) {
        // execute the Http request and retrieve the result
        this.loadData();
      //}
    }
  }

  loadData() {
    let url = this.baseUrl + "api/codesaktivitaeten/alle/" + this.myGruppe.Id;
    this.http.get<Code_aktivitaet[]>(url).subscribe(res => {
      this.code_aktivitaeten = res;
    }, error => console.error(error));
  }

  onCreate() {
    this.router.navigate(["/codesaktivitaeten/create", this.myGruppe.Id]);
  }

  onEdit(code_aktivitaet : Code_aktivitaet) {
    this.router.navigate(["/codesaktivitaeten/edit", code_aktivitaet.Id]);
  }

  onDelete(code_aktivitaet: Code_aktivitaet) {
    if (confirm("Soll diese Aktivität gelöscht werden?")) {
      let url = this.baseUrl + "api/codesaktivitaeten/" + code_aktivitaet.Id;
      this.http
        .delete(url)
        .subscribe(res => {
          console.log("Aktivität " + code_aktivitaet.Id + " wurde gelöscht.");
          // refresh the question list
          this.loadData();
        }, error => console.log(error));
    }
  }
}
