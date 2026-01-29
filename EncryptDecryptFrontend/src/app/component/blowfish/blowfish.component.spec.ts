import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlowfishComponent } from './blowfish.component';

describe('BlowfishComponent', () => {
  let component: BlowfishComponent;
  let fixture: ComponentFixture<BlowfishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BlowfishComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlowfishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
