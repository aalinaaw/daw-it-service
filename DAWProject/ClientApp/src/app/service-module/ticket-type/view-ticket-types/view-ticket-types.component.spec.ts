import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTicketTypesComponent } from './view-ticket-types.component';

describe('ViewTicketTypesComponent', () => {
  let component: ViewTicketTypesComponent;
  let fixture: ComponentFixture<ViewTicketTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewTicketTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTicketTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
