import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikPageComponent } from './korisnik-page.component';

describe('KorisnikPageComponent', () => {
  let component: KorisnikPageComponent;
  let fixture: ComponentFixture<KorisnikPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [KorisnikPageComponent]
    });
    fixture = TestBed.createComponent(KorisnikPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
