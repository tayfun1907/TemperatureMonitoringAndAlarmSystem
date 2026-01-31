import { Component, OnInit, signal } from '@angular/core';
import { NgIf } from '@angular/common';
import { TemperatureService } from '../../services/temperature.service';

@Component({
  selector: 'app-temperature-dashboard',
  standalone: true,
  imports: [NgIf],
  templateUrl: './temperature-dashboard.html',
  styleUrl: './temperature-dashboard.css'
})
export class TemperatureDashboardComponent implements OnInit {

  temperature = signal<number>(0);
  isAlarm = signal<boolean>(false);

  constructor(private temperatureService: TemperatureService) {}

  ngOnInit(): void {
    this.temperatureService.startConnection((reading) => {
      this.temperature.set(reading.value);
      this.isAlarm.set(reading.value >= 80);
    });
  }
}
