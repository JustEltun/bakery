import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BakeryControlComponent } from './bakery-control.component';

describe('BakeryControlComponent', () => {
  let component: BakeryControlComponent;
  let fixture: ComponentFixture<BakeryControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BakeryControlComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BakeryControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
