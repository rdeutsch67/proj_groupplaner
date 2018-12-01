import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "gruppen-liste",
  templateUrl: './gruppen-liste.component.html',
  styleUrls: ['./gruppen-liste.component.css']
})

export class GruppenListeComponent {
  title: string;
  selectedGruppe: Gruppe;
  gruppen: Gruppe[];

  constructor(private http: HttpClient,
              @Inject('BASE_URL') baseUrl: string) {

    this.title = "Verfügbare Gruppen";
    let url = baseUrl + "api/gruppen/alle/5";
    this.http.get<Gruppe[]>(url).subscribe(result => {
      this.gruppen = result;
    }, error => console.error(error));

  }

  onSelect(gruppe: Gruppe) {
    this.selectedGruppe = gruppe;
    console.log("quiz with Id "
      + this.selectedGruppe.Id
      + " ist ausgewählt.");
  }
}

