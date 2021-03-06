
import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule  }   from '@angular/forms';

import {EmployeeListComponent} from './list/list.component';
import {EmployeeDetailComponent} from './detail/detail.component';
import {EmployeeItemComponent} from './item/item.component';
import {EmployeeService } from './employee.service';

@NgModule ({
    imports: [CommonModule,FormsModule,ReactiveFormsModule],
    declarations: [EmployeeListComponent, EmployeeDetailComponent, EmployeeItemComponent],
    providers: [EmployeeService]
})

export class EmployeeModule{}

