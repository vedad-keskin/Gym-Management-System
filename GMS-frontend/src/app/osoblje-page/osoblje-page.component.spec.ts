import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OsobljePageComponent } from './osoblje-page.component';

describe('OsobljePageComponent', () => {
  let component: OsobljePageComponent;
  let fixture: ComponentFixture<OsobljePageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OsobljePageComponent]
    });
    fixture = TestBed.createComponent(OsobljePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
