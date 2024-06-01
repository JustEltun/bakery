import { Component, OnInit } from '@angular/core';
import { BakeryService } from '../../bakery.service';
import { Bun } from "../../interfaces/bun";
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [MatTable, MatTableModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent implements OnInit {

  displayedColumns: string[] = ['id', 'type', 'price', 'expectedPrice', 'estimatedTime'];
  dataSource = new MatTableDataSource<Bun>();
  count:any =1 ;

  constructor(private bakeryService: BakeryService) {
  }

  getData() {    
    this.bakeryService.buns
    .subscribe(buns => {
      this.dataSource.data = buns;    
    });
  }

  ngOnInit(): void {
    this.getData();
  }

}
