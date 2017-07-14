import { Product } from './model/product';
import { ProductService } from './service/product.service';
import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/map';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: Product[];
  constructor(private _productService: ProductService) { }

  ngOnInit() {
    this._productService.getProducts().subscribe(
      prds => {
        this.products = prds;
      }
    );
  }
}
