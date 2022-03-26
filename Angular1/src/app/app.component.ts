import { Component } from '@angular/core';
import { MyConfig } from './MyConfig';


@Component({
  selector: 'app-registration',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular1';
  ime: string = "Ado";

 

  preuzmiPodatke() {
    let url: string = MyConfig.adresaServer + "/TipAutomobilas/Index";

  }
}
