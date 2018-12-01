import { Component, Input } from "@angular/core";

@Component({
  selector: "gruppe",
  templateUrl: './gruppe.component.html',
  styleUrls: ['./gruppe.component.css']
})

export class GruppeComponent {
  @Input() gruppe: Gruppe;
}
