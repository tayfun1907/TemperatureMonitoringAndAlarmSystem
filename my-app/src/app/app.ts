import { Component } from '@angular/core';
import { TemperatureDashboardComponent } from './components/temperature-dashboard/temperature-dashboard';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TemperatureDashboardComponent],
  template: '<app-temperature-dashboard />'
})
export class App {}
