import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageDobavljaciComponent } from './administrator-page-dobavljaci.component';

describe('AdministratorPageDobavljaciComponent', () => {
  let component: AdministratorPageDobavljaciComponent;
  let fixture: ComponentFixture<AdministratorPageDobavljaciComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageDobavljaciComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageDobavljaciComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
