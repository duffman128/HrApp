import { Guid } from 'guid-typescript';

export enum ContactDetailType{
  Landline,
  Cellphone,
  Email,
  'Social Media'
}
export interface ContactDetail{
  Id: Guid;
  ContactInfo: string;
  Type: ContactDetailType;
  EmployeeId: string;
}
