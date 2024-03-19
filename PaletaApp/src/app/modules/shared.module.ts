import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatPaginatorModule } from '@angular/material/paginator';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
  MatGridListModule,
  MatPaginatorModule
  ],
  exports:[
  MatGridListModule,
  MatPaginatorModule
  ]

})
export class SharedModule { }
