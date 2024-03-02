import { CommonModule, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginRequest, RegistrationRequest, User } from '../../models/Account.model';
import { PersonService } from '../../services/account.service';
import { HttpClientModule } from '@angular/common/http';
import { MatFormField } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.component';


@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule,FormsModule,NgIf,HttpClientModule,MatFormField,MatInputModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent{

  action: 'login' | 'register' = 'login';

  switchTo(action: 'login' | 'register') {
    this.action = action;
  }

  Registration:RegistrationRequest;
  Login:LoginRequest;

  constructor(private personService:PersonService, public dialog: MatDialog){
    this.Registration={
      username:'',
      firstname:'',
      lastname:'',
      email:'',
      password:'',
    };

    this.Login={
      username:'',
      password:'',
    };
  }
  signup() {
  this.personService.Registration(this.Registration)
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
    this.personService.Login(this.Login)
    .subscribe({
      next:(response) =>{
       var header="Thank you for login";
       var message="You successfully sign in your account!";
        this.openDialog('0ms', '0ms',header,message)
      },
      error:(response) =>{
        var header="Oooops!";
        var message="Login failed!";
         this.openDialog('0ms', '0ms',header,message)
       },
    });
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
