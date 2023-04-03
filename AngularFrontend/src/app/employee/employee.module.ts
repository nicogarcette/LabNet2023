import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BodyComponent } from './body/body.component';
import { SharedModule } from '../shared/shared.module';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
import { DialogDeleteComponent } from './dialog-delete/dialog-delete.component';

@NgModule({
  declarations: [
    BodyComponent,
    EmployeeFormComponent,
    EmployeeFormComponent,
    EmployeeViewComponent,
    DialogDeleteComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class EmployeeModule { }
