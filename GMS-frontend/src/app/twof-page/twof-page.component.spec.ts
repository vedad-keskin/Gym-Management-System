import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwofPageComponent } from './twof-page.component';

describe('TwofPageComponent', () => {
  let component: TwofPageComponent;
  let fixture: ComponentFixture<TwofPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TwofPageComponent]
    });
    fixture = TestBed.createComponent(TwofPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
