import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageNutricionstiComponent } from './administrator-page-nutricionsti.component';

describe('AdministratorPageNutricionstiComponent', () => {
  let component: AdministratorPageNutricionstiComponent;
  let fixture: ComponentFixture<AdministratorPageNutricionstiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageNutricionstiComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageNutricionstiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
