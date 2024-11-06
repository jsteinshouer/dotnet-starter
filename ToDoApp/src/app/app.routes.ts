import { inject } from '@angular/core';
import { Routes, Router, CanActivateFn, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ToDoList } from '../todo/todos.component';

export const routes: Routes = [
  { path: '', component: ToDoList}
];
