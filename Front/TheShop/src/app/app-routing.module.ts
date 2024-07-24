import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ProductListComponent } from "./product-list/product-list.component";
import { ReceiptComponent } from "./product-list/receipt/receipt.component";


const appRoutes: Routes = [
  { path: '', component: ProductListComponent, pathMatch: 'full' },
  { path: 'productlist', component: ProductListComponent },
  { path: 'receipt', component: ReceiptComponent },
  { path: 'auth',
    loadChildren: () =>
    import('./auth/auth.module').then(m => m.AuthModule)
   },
  { path: '**', redirectTo: 'productlist' }
];

@NgModule({
  imports: [
    // RouterModule.forRoot(appRoutes, {useHash: true}) // suport for older browsers
    RouterModule.forRoot(appRoutes)
    //RouterModule.forRoot(appRoutes,{preloadingStrategy: PreloadAllModules})
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
