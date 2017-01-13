import { Routes } from '@angular/router';

import { AboutRoutes } from './about/about.routes';
import { ExampleRoutes } from './example/example.routes';
import { TodoRoutes} from './todo/todo.routes';
import { EmployeeRoutes} from './employee/employee.routes';

export const routes: Routes = [
    {
        path: '',
        redirectTo: '/employee/list',
        pathMatch: 'full'
    },
  ...AboutRoutes,
  ...ExampleRoutes,
  ...TodoRoutes,
  ...EmployeeRoutes,
];
