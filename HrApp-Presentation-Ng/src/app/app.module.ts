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
import { HttpClientModule } from '@angular/common/http';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCommonModule, MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { LayoutModule } from '@angular/cdk/layout';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { FormaddressComponent } from './formaddress/formaddress.component';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { ReactiveFormsModule } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import 'moment/locale/fr';

const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'employees', component: EmployeesComponent },
  { path: 'addemployee', component: AddEmployeeComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeeComponent,
    ContactDetailsComponent,
    ContactDetailComponent,
    AddressesComponent,
    AddressComponent,
    AddEmployeeComponent,
    HomeComponent,
    FormaddressComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatCommonModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    LayoutModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatMomentDateModule
  ],
  providers: [{provide: MAT_DATE_LOCALE, useValue: 'en-ZA'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
