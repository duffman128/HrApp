import { Component, OnInit } from '@angular/core';
import { Employee } from './models/employee';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  displayedColumns : Array<string> = ['EmployeeNumber', 'FirstName', 'LastName', 'DateOfBirth'];
  employeeList : Array<Employee> = [];
  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.getEmployees()
    .subscribe((response) => this.employeeList = response);
  }
}
