import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageSuplementiComponent } from './administrator-page-suplementi.component';

describe('AdministratorPageSuplementiComponent', () => {
  let component: AdministratorPageSuplementiComponent;
  let fixture: ComponentFixture<AdministratorPageSuplementiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageSuplementiComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageSuplementiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
