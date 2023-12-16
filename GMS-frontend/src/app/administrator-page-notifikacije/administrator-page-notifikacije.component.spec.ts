import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageNotifikacijeComponent } from './administrator-page-notifikacije.component';

describe('AdministratorPageNotifikacijeComponent', () => {
  let component: AdministratorPageNotifikacijeComponent;
  let fixture: ComponentFixture<AdministratorPageNotifikacijeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageNotifikacijeComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageNotifikacijeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
