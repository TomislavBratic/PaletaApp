import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AddPersonRequest } from '../models/PersonRequest.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http:HttpClient) { }
  
  addPerson(model:AddPersonRequest):Observable<void>{
    return this.http.post<void>('https://localhost:44330/api/People/person',model)
  }
  
}
