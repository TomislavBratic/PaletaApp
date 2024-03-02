import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { LoginRequest, RegistrationRequest, User } from '../models/Account.model';
import { Observable, ReplaySubject, empty, map } from 'rxjs';
import { response } from 'express';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private CurrentUserSource=new ReplaySubject<User|null>(1);
  CurrentUser$=this.CurrentUserSource.asObservable();

  constructor(private http:HttpClient) { }
  
  Registration(model:RegistrationRequest):Observable<void>{
    return this.http.post<void>('https://localhost:44330/api/User/register',model)
  }
  
  Login(model:LoginRequest):Observable<void>{
    return this.http.post<User>('https://localhost:44330/api/User/login',model).pipe(
      map((response:User)=>{
        const user=response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.CurrentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user:User){
    this.CurrentUserSource.next(user);
  }

  Logout() {
    localStorage.removeItem('user');
    this.CurrentUserSource.next(null);
  }
}
