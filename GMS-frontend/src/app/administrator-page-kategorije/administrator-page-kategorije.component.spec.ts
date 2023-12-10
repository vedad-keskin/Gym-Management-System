import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageKategorijeComponent } from './administrator-page-kategorije.component';

describe('AdministratorPageKategorijeComponent', () => {
  let component: AdministratorPageKategorijeComponent;
  let fixture: ComponentFixture<AdministratorPageKategorijeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageKategorijeComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageKategorijeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
