import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageKorisniciComponent } from './administrator-page-korisnici.component';

describe('AdministratorPageKorisniciComponent', () => {
  let component: AdministratorPageKorisniciComponent;
  let fixture: ComponentFixture<AdministratorPageKorisniciComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageKorisniciComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageKorisniciComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
