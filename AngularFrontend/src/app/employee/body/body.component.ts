import { Component, OnInit } from '@angular/core';
import { employee } from 'src/app/models/employee';
import { MatTableDataSource, } from '@angular/material/table';
import { EmployeesService } from '../services/employees.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {MatDialog} from '@angular/material/dialog';
import { DialogDeleteComponent } from '../dialog-delete/dialog-delete.component';

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

  constructor(private employeeService : EmployeesService,private snack: MatSnackBar,public dialog: MatDialog) { 
    this.loading = true;
  }

  ngOnInit(): void {
    this.simulateLoading();
    this.getEmployees();
  }

  getEmployees(){
    this.employeeService.getAll().subscribe({
      next:(data)=>{
        this.employeesList = data;
        this.dataSource = new MatTableDataSource(this.employeesList);
      },
      error:()=>{
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
      error:(e) =>this.alert(e.error.Message)
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
      duration:3000,
      horizontalPosition:'right',
      verticalPosition:'top'
    });
  }

  openDialog(id:number): void {
    const dialogoref = this.dialog.open(DialogDeleteComponent, {
      width: '350px'
    });
    dialogoref.afterClosed().subscribe(res=>{
      res && this.delete(id)
    })
  }
}
