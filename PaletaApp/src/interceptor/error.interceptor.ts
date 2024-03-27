import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AccountService } from '../app/services/account.service';
import { MatDialog } from '@angular/material/dialog';
import { NavigationExtras, Router } from '@angular/router';
import { catchError } from 'rxjs';
import { DialogComponent } from '../app/components/dialog/dialog.component';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  console.log("u interceptoru")
  const router=inject(Router);
const dialog=inject(MatDialog);
  return next(req).pipe(
    catchError((error:HttpErrorResponse)=>{
      if(error)
      {
        switch(error.status){
          case 400:
          if(error.error.errors)
          {
            const modelStateErrors=[];
            for (const key in error.error.errors)
            {
              if(error.error.errors[key])
              {
                modelStateErrors.push(error.error.errors[key]);
              }
            }
            throw modelStateErrors.flat();
          }
          else{
            dialog.open(DialogComponent, {
              data: { header: error.error,
                      message:error.status.toString() },
            });
          }
          break;
          case 401:
            dialog.open(DialogComponent, {
              data: { header: "Unathorised!",
                      message:error.status.toString() },
            });
            break;
          case 404:
           router.navigateByUrl('/not-found');

           break;
          case 500:
            const navigationExtras:NavigationExtras={state:{error:error.error}};
            router.navigateByUrl('/server-error',navigationExtras);
            break;
          default:
            console.log("aaa");
            console.log(error);
            break;
        }
       
      }
     throw error;
    }
    )
  );
};
