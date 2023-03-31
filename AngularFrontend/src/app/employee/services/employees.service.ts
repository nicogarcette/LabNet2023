import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { employee } from 'src/app/models/employee';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  endPoint: string = 'employee';
  constructor(private http:HttpClient) { }

  public getAll(): Observable<Array<employee>>{
    let url = environment.apiEmployees + this.endPoint;
    return this.http.get<Array<employee>>(url);
  }

  public deleteEmploye(id:any){
    let url = environment.apiEmployees + this.endPoint;
    return this.http.delete(url,id);
  }

  public updateEmploye(id:any){
    let url = environment.apiEmployees + this.endPoint;
    return this.http.delete(url,id);
  }

}
