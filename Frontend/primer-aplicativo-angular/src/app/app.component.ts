import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// Importa los nombres exactos de tus clases
import { HeaderComponentComponent } from './header-component/header-component.component';
import { BodyComponentComponent } from './body-component/body-component.component';
import { FooterComponentComponent } from './footer-component/footer-component.component';

@Component({
  selector: 'app-root',
  standalone: true,
  // Aquí es donde Angular los registra para usarlos en el HTML
  imports: [
    RouterOutlet, 
    HeaderComponentComponent, 
    BodyComponentComponent, 
    FooterComponentComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'primer-aplicativo-angular';
}