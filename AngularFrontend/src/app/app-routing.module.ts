import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BodyComponent } from './employee/body/body.component';
import { EmployeeFormComponent } from './employee/employee-form/employee-form.component';

const routes: Routes = [
  {path:'',redirectTo:'Empleados',pathMatch:'full'},
  {path:'Empleados', component: BodyComponent},
  {path:'AgregarEmpleado', component: EmployeeFormComponent},
  {path:'EditarEmpleado/:id', component: EmployeeFormComponent},
  {path:'**', redirectTo:'Empleados',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
