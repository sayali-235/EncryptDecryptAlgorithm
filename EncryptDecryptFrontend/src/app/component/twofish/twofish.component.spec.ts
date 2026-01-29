import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwofishComponent } from './twofish.component';

describe('TwofishComponent', () => {
  let component: TwofishComponent;
  let fixture: ComponentFixture<TwofishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TwofishComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TwofishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
