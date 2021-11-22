import { Guid } from 'guid-typescript';

export enum AddressType
{
    Residential,
    Postal
}

export interface Address{
  Id: Guid;
  StreetNumber: string;
  StreetName: string;
  ComplexNumber: string;
  CmpplexName: string;
  Suburb: string;
  City: string;
  PostalCode: string;
  IsSameAsResidential: boolean;
  Type: AddressType;
  EmployeeId: string;
}
