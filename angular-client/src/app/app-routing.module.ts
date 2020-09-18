import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTodoComponent } from './components/add-todo/add-todo.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { TodoTableComponent } from './components/todo-table/todo-table.component';


const routes: Routes = [
  { path: "dashboard", component: DashboardComponent },
  { path: "todo", component: TodoTableComponent },
  { path: "todo-add", component: AddTodoComponent },
  { path: "**", redirectTo: "dashboard" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
