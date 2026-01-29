import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AesencryptionComponent } from './aesencryption.component';

describe('AesencryptionComponent', () => {
  let component: AesencryptionComponent;
  let fixture: ComponentFixture<AesencryptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AesencryptionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AesencryptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
