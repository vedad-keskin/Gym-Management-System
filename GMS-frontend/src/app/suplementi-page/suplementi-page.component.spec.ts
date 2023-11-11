import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuplementiPageComponent } from './suplementi-page.component';

describe('SuplementiPageComponent', () => {
  let component: SuplementiPageComponent;
  let fixture: ComponentFixture<SuplementiPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SuplementiPageComponent]
    });
    fixture = TestBed.createComponent(SuplementiPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
