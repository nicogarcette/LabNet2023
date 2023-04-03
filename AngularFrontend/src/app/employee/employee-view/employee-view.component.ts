import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../services/employees.service';
import { ActivatedRoute } from '@angular/router';
import { employee } from 'src/app/models/employee';

@Component({
  selector: 'app-employee-view',
  templateUrl: './employee-view.component.html',
  styleUrls: ['./employee-view.component.css']
})
export class EmployeeViewComponent implements OnInit {

  id: number;
  employee: employee;
  constructor(private employeeService:EmployeesService,private route:ActivatedRoute) {
    
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    this.getEmploye(this.id);
  }

  getEmploye(id:number){
    this.employeeService.getOne(id).subscribe(res=>{
      this.employee = res;
    })
  }
}
