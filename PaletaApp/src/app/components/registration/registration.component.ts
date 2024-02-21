import { CommonModule, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule,FormsModule,NgIf],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  isSignupFormVisible: boolean = true;

  toggleForm() {
    this.isSignupFormVisible = !this.isSignupFormVisible;
  }

  signup() {
    // Handle signup logic here
  }

  signin() {
    // Handle signin logic here
  }
}

