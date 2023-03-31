import { Component, OnInit } from '@angular/core';
import { MatTableDataSource, } from '@angular/material/table';
import { employee } from 'src/app/models/employee';
import { EmployeesService } from '../services/employees.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {

  public employeesList: Array<employee> = []; 
  public dataSource: any;
  displayedColumns: string[] = ['Id', 'FirstName', 'LastName','Acciones'];

  constructor(private employeeService : EmployeesService) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(){
    this.employeeService.getAll().subscribe(data =>{
      this.employeesList = data;
      console.log('list employees',this.employeesList);//delete
      this.dataSource = new MatTableDataSource(this.employeesList);
    })
  }
}
