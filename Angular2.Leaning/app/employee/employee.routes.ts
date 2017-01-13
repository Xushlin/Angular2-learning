import { Route } from '@angular/router';

import {EmployeeListComponent} from './list/list.component';
import { EmployeeDetailComponent } from './detail/detail.component';

export const EmployeeRoutes: Route[] = [
  {
    path: 'employee/list',
    component:EmployeeListComponent
  },
  {
    path: 'employee/detail/:id',
    component:EmployeeDetailComponent
  }
]