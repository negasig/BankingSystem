import { ChangeDetectorRef, Component } from '@angular/core';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { log } from 'console';
import { CommonModule, NgIf } from '@angular/common';
import { Router } from 'express';
import { FormControl, FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
declare var bootstrap: any;

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
  imports: [HttpClientModule, CommonModule, FormsModule],
  templateUrl: './customers.html',
  styleUrl: './customers.css',
})

export class Customerss {
  editing:boolean=false;
  selectedCustomer: Customern | null = null;
  public customers: Customern[]=[];
  newcustomer:Customern={} as Customern
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

opendEditModal(customer: Customern){
  this.selectedCustomer={...customer};
  const modal=new bootstrap.Modal(document.getElementById("editModal"));
  modal.show();
}
updateCustomer(){

  this.http.put(`https://localhost:40443/api/customer/${this.selectedCustomer?.id}`, this.selectedCustomer, {responseType: 'text'})
        .subscribe({
      next: () => {
        alert("✔ Customer updated!");
        const index = this.customers.findIndex(c => c.id === this.selectedCustomer!.id);
        this.customers[index] = this.selectedCustomer!;
      }
})
}
opendAddModal(){
    this.newcustomer = {} as Customern; // reset form
    const modall=new bootstrap.Modal(document.getElementById("addcustomer"));
  modall.show();
}
rgisterCustomer(){

  this.http.post('https://localhost:40443/api/customer/addcustomer', this.newcustomer,  {responseType: 'text'})
        .subscribe({
      next: (res) => {
        alert("registerd");
        const index = this.customers.push(this.newcustomer);
       const modalEl = document.getElementById('addcustomer');
          bootstrap.Modal.getInstance(modalEl!)?.hide(); 
      }
})
}
}
