import { Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { AesencryptionComponent } from './component/aesencryption/aesencryption.component';
import { RsaencryptionComponent } from './component/rsaencryption/rsaencryption.component';
import { BlowfishComponent } from './component/blowfish/blowfish.component';
import { TwofishComponent } from './component/twofish/twofish.component';
import { TripledesencryptionComponent } from './component/tripledesencryption/tripledesencryption.component';
import { ECCEncryptionComponent } from './component/eccencryption/eccencryption.component';

export const routes: Routes = [
      { path: '', component: HomeComponent },
      {path: 'home', component: HomeComponent},
  { path: 'aes', component: AesencryptionComponent },
  { path: 'rsa', component: RsaencryptionComponent },
  { path: 'blowfish', component: BlowfishComponent },
  { path: 'twofish', component: TwofishComponent },
  { path: '3des', component: TripledesencryptionComponent },
  { path: 'ecc', component: ECCEncryptionComponent },
];
