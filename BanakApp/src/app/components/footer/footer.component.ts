import { Component } from '@angular/core';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatListModule} from '@angular/material/list';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [MatSidenavModule,MatIconModule,MatToolbarModule,MatListModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {

}
