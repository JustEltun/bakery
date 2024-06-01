import { Routes } from '@angular/router';
import { BakeryControlComponent } from './components/bakery-control/bakery-control.component';
import { TableComponent } from './components/table/table.component';
import { NofoundComponent } from './components/nofound/nofound.component';

export const routes: Routes = [
    {path:"",component:BakeryControlComponent},
    {path:"start",component:BakeryControlComponent},
    {path:"list",component:TableComponent},
    {path:"**",component: NofoundComponent}
];
