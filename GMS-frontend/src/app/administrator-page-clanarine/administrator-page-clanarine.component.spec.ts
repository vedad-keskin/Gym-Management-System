import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageClanarineComponent } from './administrator-page-clanarine.component';

describe('AdministratorPageClanarineComponent', () => {
  let component: AdministratorPageClanarineComponent;
  let fixture: ComponentFixture<AdministratorPageClanarineComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageClanarineComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageClanarineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
