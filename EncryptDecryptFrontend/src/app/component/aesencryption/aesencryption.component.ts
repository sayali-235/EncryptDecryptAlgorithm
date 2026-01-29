import { Component } from '@angular/core';
import { EncryptionService } from '../../service/encryption.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { Router } from '@angular/router';
@Component({
  selector: 'app-aesencryption',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './aesencryption.component.html',
  styleUrl: './aesencryption.component.css'
})
export class AesencryptionComponent {
 input = '';
  result = '';
copyButtonText = 'Copy';
  constructor(private encryptionService: EncryptionService,private router: Router) {}

  encrypt() {
    this.encryptionService.aesEncrypt(this.input).subscribe(res => { 
      this.result = res.output;
    });
  }

  decrypt() {
    this.encryptionService.aesDecrypt(this.input).subscribe(res => {
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
