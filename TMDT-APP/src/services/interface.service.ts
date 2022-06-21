export interface IResultViewModel{
    status: number;
    message: string;
    data: any
} 
export interface IPurchaseOrderListViewModel{
    orderNo: number;
    customerName: string;
    deliveryAddress: string;
    employeeName: string;
    note: string;
    orderDate: Date;
    voucherNo: string;
    processStatus: string;
    inTheProcessDay: number;
    sentMail: boolean;
    status: string;
}
export interface IRole{
    roleNo: string;
    roleName: string;
}
export interface IPurchaseOrderSearchForm{
    orderNo: string;
    customerInfo: string;
    employeeInfo: string;
    orderDate: string;
    voucherNo: string;
    status: string;
}
export interface IEmployeeSearchForm{
    employeeNo: string;
    employeeName: string;
    dateOfBirth: string;
    phoneNumber: string;
    email: string;
}
export interface IEmployee{
    employeeNo: string;
    employeeName: string;
    dateOfBirth: string;
    phoneNumber: string;
    email: string;
    roleNoNavigation: IRole;
}
export interface ICustomer{
    customerNo: string;
    customerName: string;
    customerAddress: string;
    phoneNumber: string;
    email: string;
}
export interface ISize{
    sizeNo: string;
    sizeName: string;
}
export interface IColor{
    colorNo: string;
    colorName: string;
}
export interface IStyle{
    styleNo: string;
    styleName: string;
}
export interface IType{
    typeNo: string;
    typeName: string;
}
export interface ICustomerSearchForm{
    customerNo: string;
    customerName: string;
    phoneNumber: string;
    email: string;
}
export interface IUSer{
    id: string;
    userName: string;
    typeUser: boolean;
    roleId: string;
    roleName: string;
    token: string;
}
export interface ICredential{
    email: string;
    passWord: string;
    type: boolean;
}