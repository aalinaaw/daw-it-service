import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewUserTypesComponent } from './view-user-types.component';

describe('ViewUserTypesComponent', () => {
  let component: ViewUserTypesComponent;
  let fixture: ComponentFixture<ViewUserTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewUserTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewUserTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
