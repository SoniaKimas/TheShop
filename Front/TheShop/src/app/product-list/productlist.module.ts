import { NgModule } from "@angular/core";
import { ProductListComponent } from "./product-list.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from "../shared/shared.module";
import { ReceiptComponent } from "./receipt/receipt.component";

@NgModule({
  declarations: [
    ProductListComponent,
    ReceiptComponent
  ],
  imports: [
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: []
})
export class ProductListModule {}
