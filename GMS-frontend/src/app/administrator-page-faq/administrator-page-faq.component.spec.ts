import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorPageFaqComponent } from './administrator-page-faq.component';

describe('AdministratorPageFaqComponent', () => {
  let component: AdministratorPageFaqComponent;
  let fixture: ComponentFixture<AdministratorPageFaqComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministratorPageFaqComponent]
    });
    fixture = TestBed.createComponent(AdministratorPageFaqComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
