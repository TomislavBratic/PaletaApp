import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-familyfarm',
  standalone: true,
  imports: [MatButtonModule,MatCardModule],
  templateUrl: './familyfarm.component.html',
  styleUrl: './familyfarm.component.css'
})
export class FamilyfarmComponent {

}
