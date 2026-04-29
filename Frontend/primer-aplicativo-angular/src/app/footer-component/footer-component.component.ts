import { Component } from '@angular/core';

@Component({
  selector: 'app-footer-component',
  standalone: true,
  imports: [],
  templateUrl: './footer-component.component.html',
  styleUrl: './footer-component.component.scss'
})
export class FooterComponentComponent {
anioActual: number = new Date().getFullYear();
  mensajeCopyright: string = '';

  mostrarCopyright() {
    this.mensajeCopyright = '© 2026 Sistema Universitario - Todos los derechos reservados.';
  }
}
