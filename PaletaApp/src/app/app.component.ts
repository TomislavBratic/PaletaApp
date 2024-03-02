import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SearchbarComponent } from './components/searchbar/searchbar.component';
import { FamilyfarmComponent } from './components/familyfarm/familyfarm.component';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatPaginatorModule} from '@angular/material/paginator';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { User } from './models/PersonRequest.model';
import { PersonService } from './services/person.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet,MatSlideToggleModule,FooterComponent,
    NavbarComponent,SearchbarComponent,FamilyfarmComponent,MatGridListModule,MatPaginatorModule,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'PaletaApp';


constructor(private personService:PersonService){

}
  ngOnInit(){
    this.setCurrentUser();
  }
  
  setCurrentUser(){
    if (typeof localStorage !== 'undefined'){
      const user:User=JSON.parse(localStorage.getItem('user')|| '{}');
      this.personService.setCurrentUser(user);
    }
    }
}

