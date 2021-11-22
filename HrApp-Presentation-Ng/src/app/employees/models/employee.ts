import { Address } from "./address";
import { ContactDetail } from "./contactdetail";
import { Guid } from 'guid-typescript';

export interface Employee{
  Id: string;
  EmployeeNumber: number;
  FirstName: string;
  LastName: string;
  DateOfBirth: Date;
  Addresses: Array<Address>;
  ContactDetails: Array<ContactDetail>;
  IsActive: boolean;
}
