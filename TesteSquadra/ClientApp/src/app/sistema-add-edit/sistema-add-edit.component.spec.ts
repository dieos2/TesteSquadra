import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SistemaAddEditComponent } from './sistema-add-edit.component';

describe('SistemaAddEditComponent', () => {
  let component: SistemaAddEditComponent;
  let fixture: ComponentFixture<SistemaAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SistemaAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SistemaAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
