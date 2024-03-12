import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BlogComponent } from '../blog/blog.component';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { response } from 'express';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BlogComponent,CommonModule,NgFor,NgIf],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  blogs:any;

  constructor(private http:HttpClient){}

  ngOnInit(): void {
    this.getBlogs();
  }


  getBlogs(){
    this.http.get("https://localhost:44330/api/Blog/").subscribe({
      next:response =>this.blogs=response,
      error:error=> console.log(error),
      complete:()=>console.log("complete!")
    })
  }

}
