import { Component } from '@angular/core';
import { EncryptionService } from '../../service/encryption.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-eccencryption',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './eccencryption.component.html',
  styleUrl: './eccencryption.component.css'
})
export class ECCEncryptionComponent {
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
