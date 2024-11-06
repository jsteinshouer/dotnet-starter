import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { RouterLink, RouterLinkActive, Router } from '@angular/router';
import { NgIf } from '@angular/common'

@Component({
  selector: 'nav-bar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgIf, FormsModule],
  template: `
<nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
  <div class="container-fluid">
    <a class="navbar-brand" routerLink="/" >To Do App</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

  </div>
</nav>
  `,
  styles: [],
})
export class NavComponent {


}
