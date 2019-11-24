import * as WiredElements from 'wired-elements';
import { Component } from '@angular/core';

// Angular (or webpack) ignores unused imports, so added this const to keep wired-elements bundled
const ThingsIReallyWantToImport = [WiredElements];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

}
