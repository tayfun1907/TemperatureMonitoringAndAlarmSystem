import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemperatureDashboardComponent } from './temperature-dashboard';

describe('TemperatureDashboard', () => {
  let component: TemperatureDashboardComponent;
  let fixture: ComponentFixture<TemperatureDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TemperatureDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemperatureDashboardComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
