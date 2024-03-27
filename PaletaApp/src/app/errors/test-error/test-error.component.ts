import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import { response } from 'express';

@Component({
  selector: 'app-test-error',
  standalone: true,
  imports: [MatButtonModule,CommonModule],
  templateUrl: './test-error.component.html',
  styleUrl: './test-error.component.css'
})
export class TestErrorComponent implements OnInit{
  baseUrl="https://localhost:44330/api/";
  validationErrors:string[]=[];

  constructor(private http:HttpClient){}


ngOnInit(): void {

}

get404Error(){
  this.http.get(this.baseUrl+"Buggy/not-found").subscribe({
    next:response=>console.log(response),
    error:error=>console.log(error)
  })
}

get401Error(){
  this.http.get(this.baseUrl+"Buggy/auth").subscribe({
    next:response=>console.log(response),
    error:error=>console.log(error)
  })
}
get400Error(){
  this.http.get(this.baseUrl+"Buggy/bad-request").subscribe({
    next:response=>console.log(response),
    error:error=>console.log(error)
  })
}

get500Error(){
  this.http.get(this.baseUrl+"Buggy/server-error").subscribe({
    next:response=>console.log(response),
    error:error=>console.log(error)
  })
}

get400ValidationError(){
  this.http.post(this.baseUrl+"User/login",{}).subscribe({
    next:response=>console.log(response),
    error:error=>
    {console.log(error);
      this.validationErrors=error;
    }
  })
}

}
