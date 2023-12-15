import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageSeminariComponent } from './administrator-page-seminari.component';

describe('AdministratorPageSeminariComponent', () => {
  let component: AdministratorPageSeminariComponent;
  let fixture: ComponentFixture<AdministratorPageSeminariComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageSeminariComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageSeminariComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
