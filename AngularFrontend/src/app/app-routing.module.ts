import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BodyComponent } from './employee/body/body.component';
import { EmployeeFormComponent } from './employee/employee-form/employee-form.component';
import { EmployeeViewComponent } from './employee/employee-view/employee-view.component';
import { InicioComponent } from './layout/inicio/inicio.component';

const routes: Routes = [
  {path:'',redirectTo:'Inicio',pathMatch:'full'},
  {path:'Inicio', component: InicioComponent},
  {path:'Empleados', component: BodyComponent},
  {path:'AgregarEmpleado', component: EmployeeFormComponent},
  {path:'EditarEmpleado/:id', component: EmployeeFormComponent},
  {path:'VerEmpleado/:id', component: EmployeeViewComponent},
  {path:'**', redirectTo:'Inicio',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
