import { ChangeDetectorRef, Component } from '@angular/core';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { log } from 'console';
import { CommonModule, NgIf } from '@angular/common';
import { Router } from 'express';
import { FormControl, FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BehaviorSubject, map, Observable } from 'rxjs';
declare var bootstrap: any;

interface Customern{
  id:number
   firstName: string
   lastName:string
   email:string
   city:string
   balance:number
   username:string
   password:string
   accountNumber:string
}
@Component({
  selector: 'app-customers',
  imports: [HttpClientModule, CommonModule, FormsModule],
  standalone: true,
  templateUrl: './customers.html',
  styleUrl: './customers.css',
})

export class Customerss {
  editing:boolean=false;
  status:string | any
  selectedCustomer: Customern | null = null;
  private customersSubject = new BehaviorSubject<Customern[]>([]);
  public customers$ = this.customersSubject.asObservable();
  newcustomer:Customern={} as Customern
  constructor(private http: HttpClient, private cd: ChangeDetectorRef){}
  
  ngOnInit(): void {
    this.http.get<Customern[]>('https://localhost:40443/api/customers')
    .subscribe(customers=>this.customersSubject.next(customers)) //populate initial value
  }
deletecustomer(id: string){
   console.log("Clicked Delete ID =", id);
   alert("are you sure you want dlete customer with id "+id)
  this.http.delete(`https://localhost:40443/api/deletecus/${id}`, { responseType: 'text' })
  .subscribe((res)=>{
    console.log(res);
  })
       const filterd= this.customersSubject.value.filter(u=>u.accountNumber !== id); // Remove row from U
        this.customersSubject.next(filterd)
}

opendEditModal(customer: Customern){
  this.selectedCustomer={...customer};
  const modal=new bootstrap.Modal(document.getElementById("editModal"));
  modal.show();
}
updateCustomer() {
  if (!this.selectedCustomer) return;

  this.http.put(
    `https://localhost:40443/api/updateCustomer/${this.selectedCustomer.accountNumber}`,
    this.selectedCustomer,
    { responseType: 'text' }
  ).subscribe(() => {

    const customers = [...this.customersSubject.value];
    const index = customers.findIndex(c => c.accountNumber === this.selectedCustomer!.accountNumber);

    if (index !== -1) {
      customers[index] = this.selectedCustomer!;
      this.customersSubject.next(customers);
    }

    alert("✔ Customer updated!");
  });
}

opendAddModal(){
    this.newcustomer = {} as Customern; // reset form
    const modall=new bootstrap.Modal(document.getElementById("addcustomer"));
  modall.show();
}
rgisterCustomer(){

  this.http.post('https://localhost:40443/api/register', this.newcustomer,  {responseType: 'text'})
        .subscribe({
      next: (res) => {
        this.status=res;
        const curent=this.customersSubject.value;
        this.customersSubject.next([...curent, this.newcustomer]);
       const modalEl = document.getElementById('addcustomer');
          bootstrap.Modal.getInstance(modalEl!)?.hide(); 
      }
})
}
}
