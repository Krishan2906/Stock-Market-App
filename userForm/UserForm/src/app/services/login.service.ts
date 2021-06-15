import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LogIn } from './login.module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) {

   }

   baseURL='https://localhost:44346/user/login';

  login(userLogin:LogIn) {
    return this.http.post(this.baseURL,userLogin);
  }

}
