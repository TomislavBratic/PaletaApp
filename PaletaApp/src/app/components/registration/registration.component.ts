import { CommonModule, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginRequest, RegistrationRequest, User } from '../../models/Account.model';
import { AccountService, } from '../../services/account.service';
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
import { Router } from '@angular/router';
;


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

  constructor(private accountervice:AccountService, public dialog: MatDialog, private router: Router){
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
  this.accountervice.Registration(this.Registration)
  .subscribe({
    next:(response) =>{
     var header="Thank you for registration";
     var message="You successfully registered account!";
      this.openDialog('0ms', '0ms',header,message)
    },
    error:(response) =>{
      var header="Oooops!";
       this.openDialog('0ms', '0ms',header,response)
     },
  });
  }

  signin() {
    this.accountervice.Login(this.Login)
    .subscribe({
      next:() =>this.router.navigateByUrl("/"),
      error:(response) =>{
        var header="Oooops!";
        JSON.stringify(response);
        console.log(response);
         this.openDialog('0ms', '0ms',header,response)
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
