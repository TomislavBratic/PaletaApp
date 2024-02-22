import { CommonModule, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AddPersonRequest } from '../../models/PersonRequest.model';
import { PersonService } from '../../services/person.service';
import { HttpClientModule } from '@angular/common/http';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { Inject } from '@angular/core';
import { DialogComponent } from '../dialog/dialog.component';


@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule,FormsModule,NgIf,HttpClientModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  isSignupFormVisible: boolean = true;

  model:AddPersonRequest
  
  constructor(private personService:PersonService, public dialog: MatDialog){
    this.model={
      FirstName:'Ante',
      LastName:'',
      Email:''
    };
  }

  toggleForm() {
    this.isSignupFormVisible = !this.isSignupFormVisible;
  }

  signup() {
  this.personService.addPerson(this.model)
  .subscribe({
    next:(response) =>{
     var header="Thank you for registration";
     var message="You successfully registered account!";
      this.openDialog('0ms', '0ms',header,message)
    },
    error:(response) =>{
      var header="Oooops!";
      var message="Something went wrong!";
       this.openDialog('0ms', '0ms',header,message)
     },
  });
  }

  signin() {
    // Handle signin logic here
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string,header:string,message:string): void {
    this.dialog.open(DialogComponent, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
      data: { header: header,
              message:message },
           
    });
  }
  
}

