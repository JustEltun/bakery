import { Component } from '@angular/core';
import { BakeryService } from '../../bakery.service';
import { FormsModule, NgModel } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-bakery-control',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './bakery-control.component.html',
  styleUrl: './bakery-control.component.css'
})
export class BakeryControlComponent {

  startSection:boolean = true;
  bunCount: any;

  constructor(private bakeryService: BakeryService, private _router : Router) {
  }


  Start(): void {
    if (this.bunCount > 0) {
      this.startSection = false;
      this.bakeryService.startBakery(this.bunCount);
      this._router.navigateByUrl('/list')
    }
  }
}
