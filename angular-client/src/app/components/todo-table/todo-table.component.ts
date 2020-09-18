import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ITodo } from 'src/app/models/todo';
import { TodoService } from 'src/app/services/todo.service';


@Component({
  selector: 'ac-todo-table',
  templateUrl: './todo-table.component.html',
  styleUrls: ['./todo-table.component.scss']
})
export class TodoTableComponent implements AfterViewInit, OnInit {
  todos: ITodo[];
  constructor(private todoService: TodoService){

  }
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'title', 'completed'];

  ngOnInit() {
    this.todoService.getAllTodos().subscribe(todos => {
      this.todos = todos;
    });
  }

  ngAfterViewInit() {

  }
}
