import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TripledesencryptionComponent } from './tripledesencryption.component';

describe('TripledesencryptionComponent', () => {
  let component: TripledesencryptionComponent;
  let fixture: ComponentFixture<TripledesencryptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TripledesencryptionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TripledesencryptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
