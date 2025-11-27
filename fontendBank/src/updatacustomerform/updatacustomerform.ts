import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { response } from 'express';
import { log } from 'console';
interface Customern{
  id:number
   firstName: string
   lastName:string
   email:string
   city:string
   balance:number
}
@Component({
  selector: 'app-updatacustomerform',
  imports: [],
  templateUrl: './updatacustomerform.html',
  styleUrl: './updatacustomerform.css',
})
export class Updatacustomerform {
constructor(private http: HttpClient){}

registerCustomer(customer:Customern){
  this.http.post('https://localhost:40443/api/customer/addcustomer', customer, {responseType: 'text'}).subscribe(
    (result)=>{
   console.log(result);
    }
  )
}


}
