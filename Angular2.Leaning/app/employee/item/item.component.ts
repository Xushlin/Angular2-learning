import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';


@Component({
  selector: "employee-item",
  templateUrl: 'app/employee/item/item.component.html',
 // styleUrls: ['app/employee/item/item.component.css']
})

export class EmployeeItemComponent {
  @Input() todo: Employee;

  constructor(private todoService: EmployeeService,
              private router: Router) { }

  gotoDetail(todo) {
    this.router.navigate(['/employee/detail'], "320bd628-d750-4239-b6e9-199d116ec247");//todo.id);
  }

  toggleTodoComplete(todo) {
    this.todoService.toggleEmployeeComplete(todo);
  }

  removeTodo(todo) {
    this.todoService.deleteEmployeeById(todo.id);
  }
}
