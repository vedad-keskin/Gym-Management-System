import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageAdminComponent } from './administrator-page-admin.component';

describe('AdministratorPageAdminComponent', () => {
  let component: AdministratorPageAdminComponent;
  let fixture: ComponentFixture<AdministratorPageAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageAdminComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
