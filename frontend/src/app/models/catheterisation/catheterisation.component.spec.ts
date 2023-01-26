import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatheterisationComponent } from './catheterisation.component';

describe('CatheterisationComponent', () => {
  let component: CatheterisationComponent;
  let fixture: ComponentFixture<CatheterisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatheterisationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatheterisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
