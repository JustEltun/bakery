import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Bun } from './interfaces/bun';

@Injectable({
  providedIn: 'root'
})
export class BakeryService {
  private _buns = new BehaviorSubject<Bun[]>([])

  get buns() {
    return this._buns.asObservable()
  }

  private apiUrl = 'http://localhost:5146';

  constructor(private http: HttpClient) {    
    this.loadBuns();    
  }

  loadBuns() {    
    this.http.get<Bun[]>(`${this.apiUrl}/buns`).subscribe(buns=>{
      this._buns.next(buns)
    });

  }

  startBakery(count: number): void {
    this.http.post(`${this.apiUrl}/start?count=${count}`,null).subscribe(() => {
      this.loadBuns();
    });
  }
}
