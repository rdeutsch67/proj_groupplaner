import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
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
  count: number;

  constructor(private http: HttpClient,
              private activatedRoute: ActivatedRoute,
              private router: Router,
              @Inject('BASE_URL') private baseUrl: string) {

    this.title = "Verfügbare Gruppen";
    let count = +this.activatedRoute.snapshot.params["count"];
    if (count) {
      console.log(count);
      let url = this.baseUrl + "api/gruppen/alle/" + count;

      this.http.get<Gruppe[]>(url).subscribe(result => {
        this.gruppen = result;
      }, error => console.error(error));
    }
    else {
      console.log("Invalid count: routing back to home...");
      this.router.navigate(["home"]);
    }
  }

  onSelect(gruppe: Gruppe) {
    this.selectedGruppe = gruppe;
    console.log("quiz with Id "
      + this.selectedGruppe.Id
      + " ist ausgewählt.");
  }
}

