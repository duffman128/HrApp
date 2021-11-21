export enum ContactDetailType{
  Landline,
  Cellphone,
  Email,
  Social_Media
}
export interface ContactDetail{
  Id: string;
  ContactInfo: string;
  Type: ContactDetailType;
  EmployeeId: string;
}
