import { Component, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import { Router } from '@angular/router';
@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.css'
})
export class NotFoundComponent implements OnInit {

constructor(private router:Router) {}  

  ngOnInit(): void {
  }

  toHomepage(){
  this.router.navigateByUrl("/home");
  }
}
