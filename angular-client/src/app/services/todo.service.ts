import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITodo, ITodoAdd } from '../models/todo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  constructor(private http: HttpClient) { }

  getAllTodos(): Observable<ITodo[]>{
    return this.http.get<ITodo[]>("https://localhost:6001/api/todo");
  }

  addTodo(todo: ITodoAdd) {
    return this.http.post<ITodo>(`https://localhost:6001/api/todo`, todo);
  }
}
