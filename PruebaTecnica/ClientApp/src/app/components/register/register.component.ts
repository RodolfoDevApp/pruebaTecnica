import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private clienteService:ClienteService,private router: Router,private auth:AuthService) {
    this.registerForm = this.formBuilder.group({
      nombre: ['', [Validators.required]],
      apellido: ['', [Validators.required]],
      direccion: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
   }

  ngOnInit(): void {
    this.toInicio();
  }

  onSubmit() {
    if (!this.registerForm.valid) {
      return;
    }
    const {nombre="",apellidos="",direccion="",password=""} = {...this.registerForm.value};
    this.clienteService.register(nombre,apellidos,direccion,password).subscribe(res =>{
      this.registerForm.reset();
      this.router.navigate(['/login']);

    })
    
  }
  toInicio(){
    if (this.auth.isAuthenticated()) { // Implementa tu lógica de autenticación
      this.router.navigate(['/inicio']);
    }
  }

}
