import { Routes } from '@angular/router';
import { Customerss } from './customers/customers';
import { Transactions } from './transactions/transactions';
import { App } from './app';
import { Home } from './home/home';
import { About } from './about/about';

export const routes: Routes = [
     {path:'', component: Home, pathMatch:'full'  },
    {path:'cus', component: Customerss},
    {path:'transac', component: Transactions},
    {path:'about', component: About}
];
