import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageRecenzijeComponent } from './administrator-page-recenzije.component';

describe('AdministratorPageRecenzijeComponent', () => {
  let component: AdministratorPageRecenzijeComponent;
  let fixture: ComponentFixture<AdministratorPageRecenzijeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageRecenzijeComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageRecenzijeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
