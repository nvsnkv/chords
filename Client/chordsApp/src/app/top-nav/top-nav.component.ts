import { Component } from '@angular/core';
import { IUser, UserService } from '../user.service';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent {
  private readonly loginUrl: string;

  constructor(userService: UserService) {
    this.user = userService.User;
    this.loginUrl = userService.LoginUrl;
  }

  readonly user: IUser;

  login(): void {
    window.location.replace(this.loginUrl);
  }
}
