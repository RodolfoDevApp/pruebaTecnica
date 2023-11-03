import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private auth:AuthService,private router: Router) {
    this.loginForm = this.formBuilder.group({
      nombre: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
   }

  ngOnInit(): void {
    this.toInicio();
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const {nombre="",password=""} = {...this.loginForm.value};
      this.auth.login(nombre,password);
      
      // Llamar a tu servicio de autenticación para enviar los datos al servidor
    }
  }
  toInicio(){
    if (this.auth.isAuthenticated()) { // Implementa tu lógica de autenticación
      this.router.navigate(['/inicio']);
    }
  }

}
