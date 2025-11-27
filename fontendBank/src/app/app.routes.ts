import { Routes } from '@angular/router';
import { Customerss } from './components/customers/customers';
import { Transactions } from './components/transactions/transactions';
import { App } from './app';
import { Home } from './components/home/home';
import { About } from './components/about/about';

export const routes: Routes = [
     {path:'', component: Home, pathMatch:'full'  },
    {path:'cus', component: Customerss},
    {path:'transac', component: Transactions},
    {path:'about', component: About}
];
