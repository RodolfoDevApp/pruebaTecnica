import { Injectable } from '@angular/core';
import { jwtDecode} from  'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class JwtService {
  getTokenExpirationDate(token: string): Date | null {
    const decoded: AuthClaims = jwtDecode(token);
    const dnsClaim = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns'];

    localStorage.setItem('id', dnsClaim!.toString())
    if (decoded && decoded.exp) {
      return new Date(decoded.exp * 1000); // Convert seconds to milliseconds
    }
    return null;
  }

  


  isTokenExpired(token: string): boolean {
    const expirationDate = this.getTokenExpirationDate(token);
    if (!expirationDate) {
      return false;
    }
    return Date.now() > expirationDate.getTime();
  }
}
export interface AuthClaims {
  unique_name: string;
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns'?: string;
  exp: number;
  // Add other claims here if needed
}