import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageTreneriComponent } from './administrator-page-treneri.component';

describe('AdministratorPageTreneriComponent', () => {
  let component: AdministratorPageTreneriComponent;
  let fixture: ComponentFixture<AdministratorPageTreneriComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageTreneriComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageTreneriComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
