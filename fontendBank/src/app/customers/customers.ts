import { ChangeDetectorRef, Component } from '@angular/core';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { log } from 'console';
import { CommonModule, NgIf } from '@angular/common';
import { Router } from 'express';
interface Customern{
  id:number
   firstName: string
   lastName:string
   email:string
   city:string
   balance:number
}
@Component({
  selector: 'app-customers',
  imports: [HttpClientModule, CommonModule],
  templateUrl: './customers.html',
  styleUrl: './customers.css',
})
export class Customerss {
  public customers: Customern[]=[];
  constructor(private http: HttpClient, private cd: ChangeDetectorRef){}
  
  ngOnInit(): void {
    this.getCustomers();
  }
getCustomers(){
  this.http.get<Customern[]>('https://localhost:40443/api/customer/list').subscribe(
    result=>{
      this.customers=result;
    console.log(this.customers);
    this.cd.detectChanges();
    },
    (error)=>{
  console.error(error);
   this.cd.detectChanges();
    }
  );


}
getCustomersdfh(){
  fetch('https://localhost:40443/api/customer/list')
  .then(c=>c.json())
  .then(c=>{
    this.customers=c;
    this.cd.detectChanges();
  })
}
deletecustomer(id: number){
   console.log("Clicked Delete ID =", id);
   alert("are you sure you want dlete customer with id "+id)
  this.http.delete(`https://localhost:40443/api/customer/deletcus/${id}`, { responseType: 'text' })
  .subscribe((res)=>{
    console.log(res);
    
  })
       
        this.customers = this.customers.filter(c => c.id !== id); // Remove row from U
}
}
