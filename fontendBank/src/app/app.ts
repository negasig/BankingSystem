import { Component, signal } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { Customerss } from './components/customers/customers';
import { NavMenu } from './components/nav-menu/nav-menu';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterModule, NavMenu],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('fontendBank');
}
