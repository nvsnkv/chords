import { IUser, UserService } from './user.service';
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
  private readonly user: IUser;
  private readonly loginUrl: string;

  public get User(): IUser {
    return this.user;
  }

  constructor(userService: UserService) {
    this.user = userService.User;
    this.loginUrl = userService.LoginUrl;
  }

  public Login(): void {
    window.location.replace(this.loginUrl);
  }
}
