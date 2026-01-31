import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class TemperatureService {

  private hubConnection!: signalR.HubConnection;

  startConnection(onData: (data: any) => void) {

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5100/temperatureHub')
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('SignalR connected'))
      .catch(err => console.error('SignalR error:', err));

    this.hubConnection.on('temperatureUpdated', (data) => {
      onData(data);
    });
  }
}
