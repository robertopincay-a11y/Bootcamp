import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header-component',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header-component.component.html',
  styleUrl: './header-component.component.scss'
})
export class HeaderComponentComponent {
nombreApp: string = 'Portal Universitario';
  estudiante: string = 'Roberto';
  estaConectado: boolean = true;

  toggleConexion() {
    this.estaConectado = !this.estaConectado;
  }
}
