import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageGradoviComponent } from './administrator-page-gradovi.component';

describe('AdministratorPageGradoviComponent', () => {
  let component: AdministratorPageGradoviComponent;
  let fixture: ComponentFixture<AdministratorPageGradoviComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageGradoviComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageGradoviComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
