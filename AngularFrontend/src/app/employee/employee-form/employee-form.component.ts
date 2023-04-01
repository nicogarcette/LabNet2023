import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { employee } from 'src/app/models/employee';
import { EmployeesService } from '../services/employees.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  form: FormGroup;
  id: number;

  constructor(private fb: FormBuilder,private employeeService:EmployeesService,private snack: MatSnackBar,
    private route:ActivatedRoute) {

    this.form = this.fb.group({
      FirstName:['',Validators.required],
      LastName:['',Validators.required],
    });
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    this.id != 0 && this.getEmploye(this.id);
  }
  getEmploye(id:number){
    this.employeeService.getOne(id).subscribe(res=>{
      this.form.setValue({
        FirstName: res.FirstName,
        LastName: res.LastName,
      });
    })
  }
  addEmployee(){
    const emp: employee = { 
      Id:this.id,
      FirstName:this.form.value.FirstName,
      LastName: this.form.value.LastName
    }

    this.id == 0 ? this.create(emp) : this.update(emp);
  }

  create(emp:employee){
    this.employeeService.createEmploye(emp).subscribe({
      next:(res)=> this.alert(res.toString()),
      error:(e) =>this.alert(e)
    })
  }
  update(emp:employee){
    this.employeeService.updateEmploye(emp).subscribe({
      next:(res)=> this.alert(res.toString()),
      error:(e) =>this.alert(e)
    })
  }
  alert(msj:string){
    this.snack.open(msj,'',{
      duration:4000,
      horizontalPosition:'right',
      verticalPosition:'top'
    });
  }

}
