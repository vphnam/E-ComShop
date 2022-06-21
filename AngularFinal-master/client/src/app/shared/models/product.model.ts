export interface Products {
  count: number;
  products: Product[];
}

export interface Product {
  serialNo: Number;
  productNo: string;
  title: string;
  image: string;
  price: number;
  shortDesc: string;
  color: string;
  promotion: any;
  quantity: number;
}

export interface IUser {
  customerNo: string,
  customerName: string,
  customerAddress: string,
  phoneNumber: string,
  email: string,
  passWord: string,
}
