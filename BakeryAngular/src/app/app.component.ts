import { Component } from '@angular/core';
import { TableComponent } from './components/table/table.component';
import { HttpClientModule } from '@angular/common/http';
import { BakeryControlComponent } from './components/bakery-control/bakery-control.component';
import { RouterOutlet } from '@angular/router';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BakeryControlComponent,TableComponent,HttpClientModule,RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BakeryAngular';
}
