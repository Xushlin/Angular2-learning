import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'employee-detail',
  templateUrl: 'app/employee/detail/detail.component.html',
  //styleUrls: ['app/employee/detail/detail.component.css']
})

export class EmployeeDetailComponent implements OnInit {
  selectedEmployee: Employee;
  errorMessage:string;
  constructor(
      private route: ActivatedRoute,
      private router: Router,
      private employeeService: EmployeeService) { }

    ngOnInit() {
    this.selectedEmployee=new Employee();
    let employeeId = this.route.snapshot.params['id'];
    this.employeeService.getEmployeeById(employeeId).subscribe(
        employee=>this.selectedEmployee=employee,
        error=>this.errorMessage=error);
  }

  goBack() {
    window.history.back();
  }
}