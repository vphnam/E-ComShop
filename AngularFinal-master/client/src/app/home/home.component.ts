import {
  Component,
  OnInit,
  ViewEncapsulation,
  HostListener,
} from '@angular/core';
import { ApiService } from '../services/api.service';
import { CartService } from '../services/cart.service';
import { ProductService } from '../services/product.service';
import { Products, Product } from '../shared/models/product.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class HomeComponent implements OnInit {
  products: Product[] = [];
  categories: any;
  loading = false;
  productPageCounter = 1;
  additionalLoading = false;
  from: number;
  to: number;
  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private api: ApiService,
  ) {
    this.api.getTypeRequest("/Style").subscribe(
      (res: any) => {
        this.categories = res.data;
        this.additionalLoading = false;
      },
      (err) => {
        console.log(err);
        this.additionalLoading = false;
      });
  }

  public screenWidth: any;
  public screenHeight: any;
  filter() {
    if (this.from > this.to)
    {
      this.from = this.to;
      this.productService.getAllProducts(9, this.productPageCounter).subscribe(
        (res: any) => {
          this.products = res.data;
          this.loading = false;
        },
        (err) => {
          this.loading = false;
        }
      );
    }
    else if (this.to < this.from)
    {
      this.to = this.from;
      this.productService.getAllProducts(9, this.productPageCounter).subscribe(
        (res: any) => {
          this.products = res.data;
          this.loading = false;
        },
        (err) => {
          this.loading = false;
        }
      );
    }
    else {
      this.productService.getAllProducts(9, this.productPageCounter).subscribe(
        (res: any) => {
          this.products = [];
          for (let i = 0; i < res.data.length; i++) {
            console.warn(res.data[i]);
            if(res.data[i].price >= this.from && res.data[i].price <= this.to)
            {
              this.products.push({
                serialNo: res.data[i].serialNo,
                productNo: res.data[i].productNo,
                title: res.data[i].title,
                image: res.data[i].image,
                price: res.data[i].price,
                shortDesc: res.data[i].shortDesc,
                color: res.data[i].color,
                promotion: res.data[i].promotion,
                quantity: res.data[i].quantity,
              });
            }
          }
          this.loading = false;
        },
        (err) => {
          this.loading = false;
        }
      );
    }
  }
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.screenWidth = window.innerWidth;
    this.screenHeight = window.innerHeight;
  }

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
    this.screenHeight = window.innerHeight;
    this.loading = true;
    setTimeout(() => {
      this.productService.getAllProducts(9, this.productPageCounter).subscribe(
        (res: any) => {
          this.products = res.data;
          this.loading = false;
        },
        (err) => {
          this.loading = false;
        }
      );
    }, 500);
  }

  showMoreProducts(): void {
    this.additionalLoading = true;
    this.productPageCounter = this.productPageCounter + 1;
    setTimeout(() => {
      this.productService.getAllProducts(9, this.productPageCounter).subscribe(
        (res: any) => {
          this.products = [...this.products, ...res.data];
          this.additionalLoading = false;
        },
        (err) => {
          this.additionalLoading = false;
        }
      );
    }, 500);
  }
}
