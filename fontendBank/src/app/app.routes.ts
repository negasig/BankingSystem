import { Routes } from '@angular/router';
import { Customerss } from './components/customers/customers';
import { Transactions } from './components/transactions/transactions';
import { App } from './app';
import { Home } from './components/home/home';
import { About } from './components/about/about';
import { Login } from './components/login/login';
import { Test } from './components/test/test';
import { AuthGuard } from './components/auth-guard';

export const routes: Routes = [
     {path:'', component: Home, pathMatch:'full'  },
    {path:'cus', component: Customerss, canActivate:[AuthGuard]},
    {path:'transac', component: Transactions},
    {path:'about', component: About},
    {path:'login', component: Login},
    {path: 'test', component: Test}
];
