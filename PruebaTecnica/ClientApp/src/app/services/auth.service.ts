import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtService } from './jwt.service';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly authKey = 'isAuthenticated';
  constructor(private http:HttpClient,private jwtService: JwtService, private router: Router){}
  // Implementa la lógica para iniciar sesión y establecer isAuthenticated en true
  login(Nombre: string, password: string): void {
    let urlAuth = '/auth/login';
    // Lógica de autenticación, por ejemplo, verifica las credenciales
    this.http.post(urlAuth,{Nombre,password}).subscribe( (res:any) =>{
      console.log(res);
      if (res.token) {
        localStorage.setItem(this.authKey, 'true');
        localStorage.setItem('token', res.token);
        this.router.navigate(['/inicio']);
      }else{
        localStorage.setItem(this.authKey, 'false');
      }
    }
    );
  }

  // Implementa la lógica para cerrar sesión y establecer isAuthenticated en false
  logout(): void {
    localStorage.clear();
    this.router.navigate(['/login']); // Redirige al usuario a la página de inicio de sesión

    }

    isAuthenticated(): boolean {
    let checkToken = localStorage.getItem('token') !== null?this.jwtService.isTokenExpired(localStorage.getItem('token')||""):true;
    return localStorage.getItem(this.authKey) === 'true' && !checkToken;
  }

 
}
