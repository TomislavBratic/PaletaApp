import { Component, Input, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { CommonModule,NgFor } from '@angular/common';

@Component({
  selector: 'app-blog',
  standalone: true,
  imports: [MatButtonModule,MatCardModule,CommonModule,NgFor],
  templateUrl: './blog.component.html',
  styleUrl: './blog.component.css'
})
export class BlogComponent implements OnInit{
  @Input() blog:any;

  constructor(){}

  ngOnInit(): void {
  }

}
