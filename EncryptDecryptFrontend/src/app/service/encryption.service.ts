import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable'; 
@Injectable({
  providedIn: 'root'
})
export class EncryptionService {
private baseUrl="https://localhost:7263/api/Common"
  constructor(private http:HttpClient) { }

aesEncrypt(input: string): Observable<any> {
   return this.http.post(`${this.baseUrl}/encrypt/aes`, { input });
}

  aesDecrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/decrypt/aes`, { input });
  }

  blowfishEncrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/encrypt/blowfish`, { input });
  }

  blowfishDecrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/decrypt/blowfish`, { input });
  }
  eccEncrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/encrypt/ecc`, { input });
  }

  eccDecrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/decrypt/ecc`, { input });
  }
  rsaEncrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/encrypt/rsa`, { input });
  }

  rsaDecrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/decrypt/rsa`, { input });
  }
  tripleDesEncrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/encrypt/TripleDes`, { input });
  }

  tripleDesDecrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/decrypt/TripleDes`, { input });
  }
  twofishEncrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/encrypt/twofish`, { input });
  }

  twofishDecrypt(input: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/decrypt/twofish`, { input });
  }
}
