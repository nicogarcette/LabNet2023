import { Component, OnInit } from '@angular/core';
import { employee } from 'src/app/models/employee';
import { MatTableDataSource, } from '@angular/material/table';
import { EmployeesService } from '../services/employees.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {

  public employeesList: Array<employee> = []; 
  public dataSource: any;
  displayedColumns: string[] = ['Id', 'FirstName', 'LastName','Acciones'];
  public loading : boolean;

  constructor(private employeeService : EmployeesService,private snack: MatSnackBar) { 
    this.loading = true;
  }

  ngOnInit(): void {
    this.simulateLoading();
    this.getEmployees();
  }

  getEmployees(){
    this.employeeService.getAll()
    .subscribe({
      next:(data)=>{
        this.employeesList = data;
        this.dataSource = new MatTableDataSource(this.employeesList);
      },
      error:(e)=>{
        this.alert('Hay un error al obtener la lista');
        this.loading = false;
      }
    })
  }
  
  delete(id : number){ 
    this.employeeService.deleteEmploye(id).subscribe({
      next:(res)=> {
        this.alert(res);
        this.getEmployees();
      },
      error:(e) =>console.error(e)
    })
  }
  update(){
    const emp: employee = { 
      Id:0,
      FirstName:'ángula',
      LastName: 'sii'
    }
    this.employeeService.updateEmploye(emp).subscribe({
      next:(res)=> this.alert(res.toString()),
      error:(e) => this.alert(e)
    })
  }

  simulateLoading(){
    this.loading = true;
    setTimeout(()=>{
      this.loading = false;
    },1500);
  }

  alert(msj:string){
    this.snack.open(msj,'',{
      duration:4000,
      horizontalPosition:'right',
      verticalPosition:'top'
    });
  }
}
