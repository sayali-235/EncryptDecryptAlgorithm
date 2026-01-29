import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ECCEncryptionComponent } from './eccencryption.component';

describe('ECCEncryptionComponent', () => {
  let component: ECCEncryptionComponent;
  let fixture: ComponentFixture<ECCEncryptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ECCEncryptionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ECCEncryptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
