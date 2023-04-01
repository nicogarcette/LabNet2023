import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { employee } from 'src/app/models/employee';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  apiUrl: string = environment.apiEmployees;
  endPoint: string = 'employee';
  
  constructor(private http:HttpClient) { }

  public getAll(): Observable<Array<employee>>{
    let url = this.apiUrl + this.endPoint;
    return this.http.get<Array<employee>>(url);
  }
  public getOne(id:number): Observable<employee>{
    let url = this.apiUrl + this.endPoint + `/${id}`;
    return this.http.get<employee>(url);
  }
  public deleteEmploye(id:number): Observable<string>{
    let url = this.apiUrl + this.endPoint +`/${id}`;
    return this.http.delete<string>(url);
  }
  public updateEmploye(emp:employee):Observable<string>{
    let url = this.apiUrl + this.endPoint;
    return this.http.put<string>(url,emp);
  }
  public createEmploye(emp:employee):Observable<string>{
    let url = this.apiUrl + this.endPoint;
    return this.http.post<string>(url,emp);
  }
}
