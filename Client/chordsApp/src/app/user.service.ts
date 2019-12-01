import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IUser } from './user.service';
import * as jwt_webcode from 'jwt-decode';


export interface IUser {
  isLoggedIn: boolean;
  userId?: string;
  name?: string;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private user: IUser;

  public get User(): IUser {
    return this.user;
  }

  public get LoginUrl(): string {
    return '/auth/login?redirect=' + encodeURIComponent(window.location.href);
  }

  constructor(cookieService: CookieService) {
    const encoded = cookieService.get('jwt');
    const token = (encoded) ? jwt_webcode(encoded) : null;

    this.user = {
      isLoggedIn: token != null,
      userId: token != null ? token['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] : undefined,
      name: token != null ? token['name'] : undefined
    };
  }


}
