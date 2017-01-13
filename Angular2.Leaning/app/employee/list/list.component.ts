import { Component,Input} from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';
import { Observable }  from 'rxjs/Observable';
import {FormControl} from "@angular/forms";


@Component({
  selector: 'employee-list',
  templateUrl: 'app/employee/list/list.component.html',
})

export class EmployeeListComponent {
  @Input() employee: Employee;
  errorMessage: string;
  employees: Observable<Employee[]>;
  mode = 'Observable';
  newEmployee: Employee = new Employee();

  term = new FormControl();
  ngOnInit():void {
    this.employees=new Observable<Employee[]>();
    this.employeeService.getAllEmployees().subscribe(emp=>this.getEmployees(emp),err=>this.errorMessage=err);

     this.employees=this.term.valueChanges
        .debounceTime(400)
        .distinctUntilChanged()
        .switchMap(term => this.employeeService.search(term));
  }

  constructor(private employeeService: EmployeeService,private router:Router) { }

  addEmployee() {
    this.employeeService.addEmployee(this.newEmployee).subscribe(
        success=>this.employeeService.getAllEmployees().subscribe(emp=>this.getEmployees(emp),err=>this.errorMessage=err),
        err=>this.errorMessage=err);
    this.newEmployee = new Employee();
  }

  delete(id:string){
    this.employeeService.deleteEmployeeById(id).subscribe(
        success=>this.employeeService.getAllEmployees().subscribe(emp=>this.getEmployees(emp),err=>this.errorMessage=err),
        err=>this.errorMessage=err);
  }

  updateEmployee(employee:Employee){
    this.employeeService.updateEmployeeById(employee).subscribe(
        success=>this.employeeService.getAllEmployees().subscribe(emp=>this.getEmployees(emp),err=>this.errorMessage=err),
        err=>this.errorMessage=err);
  }

  gotoDetail(employee:Employee){
    this.router.navigate(['/employee/detail', employee.Id]);
  }
  getEmployees(emps:any){
    this.employees=emps
  }
}