import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyfarmComponent } from './familyfarm.component';

describe('FamilyfarmComponent', () => {
  let component: FamilyfarmComponent;
  let fixture: ComponentFixture<FamilyfarmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FamilyfarmComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FamilyfarmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
