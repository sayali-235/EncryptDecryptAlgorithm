import { Component } from '@angular/core';
import { EncryptionService } from '../../service/encryption.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tripledesencryption',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './tripledesencryption.component.html',
  styleUrl: './tripledesencryption.component.css'
})
export class TripledesencryptionComponent {
input = '';
  result = '';
copyButtonText = 'Copy';
  constructor(private encryptionService: EncryptionService,private router: Router) {}

  encrypt() {
    this.encryptionService.eccEncrypt(this.input).subscribe(res => {  
      this.result = res.output;
    });
  }

  decrypt() {
    this.encryptionService.eccDecrypt(this.input).subscribe(res => {
      this.result = res.output;
    });
  }
  goBack(path: string) {
  this.router.navigateByUrl(path);
}
copyOutput() {
  if (!this.result) return;

  navigator.clipboard.writeText(this.result).then(() => {
    this.copyButtonText = 'Copied!';

    setTimeout(() => {
      this.copyButtonText = 'Copy';
    }, 1500); // revert after 1.5 seconds
  });
}
}
