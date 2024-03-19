import { Component, OnInit } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import { SearchbarComponent } from '../searchbar/searchbar.component';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import {MatSelectModule} from '@angular/material/select';
import { AccountService } from '../../services/account.service';
import { CommonModule,NgIf } from '@angular/common';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatToolbarModule,MatIconModule,MatButtonModule, 
    MatMenuModule,SearchbarComponent,RouterLink,RouterLinkActive,RouterOutlet,MatSelectModule,CommonModule,NgIf],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  imagePath = 'C:\BanakFrontendApp\PaletaApp\src\app\assets\bench.png';

  constructor(public accountService:AccountService, private router:Router){}

  ngOnInit(): void {}

  logout(){
    this.accountService.Logout();
    this.router.navigateByUrl("/registration");
 }  
}