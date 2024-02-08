import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from '../models/login';
import { Register } from '../models/register';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  registerUrl = "User/register"
  loginUrl= "User/login"

  constructor(private http : HttpClient) {}

  public register(userObj: any){

    return this.http.post<any>(`${environment.apiUrl}/${this.registerUrl}`, userObj);
   }

   public login(loginObj: any){
    
    return this.http.post<any>(`${environment.apiUrl}/${this.loginUrl}`, loginObj );
   }
}
