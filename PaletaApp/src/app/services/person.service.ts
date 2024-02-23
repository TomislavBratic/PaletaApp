import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { LoginRequest, RegistrationRequest } from '../models/PersonRequest.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http:HttpClient) { }
  
  Registration(model:RegistrationRequest):Observable<void>{
    return this.http.post<void>('https://localhost:44330/api/User/register',model)
  }
  
  Login(model:LoginRequest):Observable<void>{
    return this.http.post<void>('https://localhost:44330/api/User/login',model)
  }
}
