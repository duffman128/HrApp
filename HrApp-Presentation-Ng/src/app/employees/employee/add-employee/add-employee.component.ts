import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
} from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS }
  ]
})
export class AddEmployeeComponent implements OnInit {

  employeeForm: FormGroup = this.fb.group({
    employeeNumber: [null, Validators.required],
    firstName: [null, Validators.required],
    lastName: [null, Validators.required],
    dateOfBirth: [null, Validators.required],
  });

  employee: Employee;

  constructor(private employeeService: EmployeeService, private fb: FormBuilder) {
    this.employee = {
      Id: Guid.createEmpty().toString(),
      EmployeeNumber: 0,
      FirstName: "",
      LastName: "",
      DateOfBirth: new Date("1900/01/01"),
      Addresses: [],
      ContactDetails: [],
      IsActive: true
    }
  }

  ngOnInit(): void { }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      this.employee.EmployeeNumber = this.employeeForm.value.employeeNumber;
      this.employee.FirstName = this.employeeForm.value.firstName;
      this.employee.LastName = this.employeeForm.value.lastName;
      this.employee.DateOfBirth = this.employeeForm.value.dateOfBirth;

      this.employeeService.postEmployee(this.employee)
        .subscribe((response) => this.employee.Id = response);
    }
  }
}
