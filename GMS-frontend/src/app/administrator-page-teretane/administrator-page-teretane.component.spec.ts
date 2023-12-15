import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageTeretaneComponent } from './administrator-page-teretane.component';

describe('AdministratorPageTeretaneComponent', () => {
  let component: AdministratorPageTeretaneComponent;
  let fixture: ComponentFixture<AdministratorPageTeretaneComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageTeretaneComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageTeretaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
