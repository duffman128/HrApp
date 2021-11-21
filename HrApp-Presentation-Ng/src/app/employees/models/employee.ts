import { Address } from "./address";
import { ContactDetail } from "./contactdetail";

export interface Employee{
  Id: string;
  FirstName: string;
  LastName: string;
  DateOfBirth: Date;
  Addresses: Array<Address>;
  ContactDetails: Array<ContactDetail>;
}
