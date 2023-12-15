import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageKorisnikClanarineComponent } from './administrator-page-korisnik-clanarine.component';

describe('AdministratorPageKorisnikClanarineComponent', () => {
  let component: AdministratorPageKorisnikClanarineComponent;
  let fixture: ComponentFixture<AdministratorPageKorisnikClanarineComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageKorisnikClanarineComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageKorisnikClanarineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
