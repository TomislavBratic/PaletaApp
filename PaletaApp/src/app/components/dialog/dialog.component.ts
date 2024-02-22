import { CommonModule, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AddPersonRequest } from '../../models/PersonRequest.model';
import { PersonService } from '../../services/person.service';
import { HttpClientModule } from '@angular/common/http';
import { DialogModule } from '@angular/cdk/dialog';
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

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent,NgIf,CommonModule,DialogModule],
  templateUrl: './dialog.component.html',
  styleUrl: './dialog.component.css'
})
export class DialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: {header: string,message:string}, public dialogRef: MatDialogRef<DialogComponent>) {}
}
