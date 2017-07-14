import { ProductService } from './service/product.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { HttpModule } from '@angular/http';
@NgModule({
  imports: [
    CommonModule,
    HttpModule
  ],
  declarations: [ProductComponent],
  providers: [ProductService],
  exports:[ProductComponent]
})
export class ProductsModule { }