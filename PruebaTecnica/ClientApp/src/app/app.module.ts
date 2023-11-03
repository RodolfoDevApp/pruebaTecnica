import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { ArticulosComponent } from './components/articulos/articulos.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    InicioComponent,
    LoginComponent,
    RegisterComponent,
    ArticulosComponent,
    ClientesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,    
    NgxPaginationModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: 'inicio', component: InicioComponent, canActivate: [AuthGuard]  },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'CrudClientes', component: ClientesComponent, canActivate: [AuthGuard] },
      { path: 'crudArticulos', component: ArticulosComponent, canActivate: [AuthGuard] },
      { path: '**', redirectTo: 'inicio' }
    ]),
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
