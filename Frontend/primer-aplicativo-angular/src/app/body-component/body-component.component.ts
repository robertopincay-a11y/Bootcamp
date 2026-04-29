import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; //

interface Materia {
  nombre: string;
  creditos: number;
  aprobada: boolean;
}

@Component({
  selector: 'app-body-component',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './body-component.component.html',
  styleUrl: './body-component.component.scss'
})

export class BodyComponentComponent {
busqueda: string = '';
  creditos: number = 45; 

  materias: Materia[] = [
    { nombre: 'Cálculo', creditos: 4, aprobada: true },
    { nombre: 'Física', creditos: 4, aprobada: false },
    { nombre: 'Programación', creditos: 3, aprobada: true },
    { nombre: 'Base de Datos', creditos: 3, aprobada: false },
    { nombre: 'Inglés', creditos: 2, aprobada: true },
  ];

  sumar() { 
    if (this.creditos + 10 <= 120) {
    this.creditos += 10;
  } else {
    this.creditos = 120;
  } 
}
  restar() { 
    if (this.creditos - 10 >= 0) {
    this.creditos -= 10;
  } else {
    this.creditos = 0;
  }
  }

  get porcentaje(): number {
    return (this.creditos / 120) * 100;
  }


  get colorBarra(): string {
    const porcentaje = (this.creditos / 120) * 100;
    
    if (porcentaje < 40) return 'red';
    if (porcentaje <= 70) return 'orange';
    return 'green';
  }
}
