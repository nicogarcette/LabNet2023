import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BodyComponent } from './body/body.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    BodyComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class EmployeeModule { }
