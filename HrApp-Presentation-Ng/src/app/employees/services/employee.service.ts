import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employeeApiUrl: string;
  constructor(private http: HttpClient) {
    this.employeeApiUrl = environment.webApiUrl + 'employee/';
  }

  public getEmployees() : Observable<Array<Employee>> {
    let getEmployeesUrl = this.employeeApiUrl + 'getemployees/';
    return this.http.get<Array<Employee>>(getEmployeesUrl);
  }

  public getEmployee(employeeId: string) : Observable<Employee> {
    let getEmployeeUrl = this.employeeApiUrl + 'getemployee/' + employeeId;
    return this.http.get<Employee>(getEmployeeUrl);
  }

  public getEmployeeId(employeeNumber: number) : Observable<string> {
    let getEmployeeIdUrl = this.employeeApiUrl + 'getemployeeid/' + employeeNumber.toString();
    return this.http.get<string>(getEmployeeIdUrl);
  }

  public postEmployee(employee: Employee) : Observable<string> {
    let postEmployeeUrl = this.employeeApiUrl + 'postEmployee';
    return this.http.post<string>(postEmployeeUrl, employee);
  }

  public puthEmployee(employee: Employee) : Observable<void> {
    let putEmployeeUrl = this.employeeApiUrl + 'putEmployee';
    return this.http.post<void>(putEmployeeUrl, employee);
  }
}
