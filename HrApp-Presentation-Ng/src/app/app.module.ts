import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { ContactDetailsComponent } from './employees/employee/contact-details/contact-details.component';
import { ContactDetailComponent } from './employees/employee/contact-details/contact-detail/contact-detail.component';
import { AddressesComponent } from './employees/employee/addresses/addresses.component';
import { AddressComponent } from './employees/employee/addresses/address/address.component';
import { AddEmployeeComponent } from './employees/employee/add-employee/add-employee.component';

const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'employees', component: EmployeesComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    EmployeesComponent,
    EmployeeComponent,
    ContactDetailsComponent,
    ContactDetailComponent,
    AddressesComponent,
    AddressComponent,
    AddEmployeeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
