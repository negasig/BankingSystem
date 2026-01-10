import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, provideHttpClient } from '@angular/common/http';
import { error, log } from 'console';
import { Observable } from 'rxjs/internal/Observable';
interface Transactionss{

 firstName:string
 lastName :string
 senderAccount :string
 receiverAccount :string
 amount :number
 reason :string
 createdAt: Date
}
@Component({
  selector: 'app-transactions',
  imports: [CommonModule, FormsModule, HttpClientModule],
  standalone: true,
  templateUrl: './transactions.html',
  styleUrl: './transactions.css',
})

export class Transactions {
  constructor(private http: HttpClient, private cd: ChangeDetectorRef){}
   transactions$!: Observable<Transactionss[]>;
  
   ngOnInit(): void {
        this.transactions$ =
      this.http.get<Transactionss[]>('https://localhost:40443/api/transactions');
  }
}
