import { ConstantPool } from '@angular/compiler';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss'],
})
export class ProductCardComponent implements OnInit {

  @Input() serialNo: string;
  @Input() productNo: string;
  @Input() title: string;
  @Input() image: string;
  @Input() price: string;
  @Input() shortDesc: number;
  @Input() color: number;
  @Input() promotion: any;
  @Input() quantity: number;
  @Input() onAdd: any;

  constructor() {
    console.warn();
  }

  ngOnInit(): void {}
}
