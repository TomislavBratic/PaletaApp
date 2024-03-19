import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../services/account.service';
import { RegistrationComponent } from '../components/registration/registration.component';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogTitle,
  MatDialogContent,
} from '@angular/material/dialog';
import { map } from 'rxjs';
import { DialogComponent } from '../components/dialog/dialog.component';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService=inject(AccountService);
  const dialog=inject(MatDialog);
  return this,accountService.CurrentUser$.pipe(
    map(user=>{
      if(user) return true;
      else{
        dialog.open(DialogComponent, {
          data: { header: "Whoa!",
                  message:"Log in first!" },
        });

        return false;
      }
    })
  );
};
