import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Todo } from '../todo';
import { TodoService } from '../todo.service';

@Component({
    selector: 'todo-item',
    templateUrl: 'app/todo/item/item.component.html',
    styleUrls: ['app/todo/item/item.component.css']
})
export class TodoItemComponent {
    @Input() todo: Todo;
    
    constructor(private todoService: TodoService, private router: Router) {
    }

    gotoDetail(todo:Todo) {
        this.router.navigate(['/todo/detail', todo.id]);
    }

    toggleTodoComplete(todo:Todo) {
        this.todoService.toggleTodoComplete(todo);
    }
    removeTodo(todo:Todo) {
        this.todoService.deleteTodoById(todo.id);
    }
}

