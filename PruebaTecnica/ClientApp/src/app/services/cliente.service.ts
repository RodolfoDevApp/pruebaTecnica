import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cliente } from '../models/Cliente.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http:HttpClient) { }

  register(Nombre:string,Apellidos:string,Direccion:string,password:string) {
    let urlAuth = '/cliente';
    return this.http.post(urlAuth,{Nombre,Apellidos,Direccion,password});
  }
  getAll() {
    let urlAuth = '/cliente';
    return this.http.get<Cliente[]>(urlAuth);
  }
  update(ClienteId:number,Nombre:string,Apellidos:string,Direccion:string,password:string) {
    let urlAuth = '/cliente/'+ClienteId;
    return this.http.put(urlAuth,{ClienteId,Nombre,Apellidos,Direccion,password});
  }
  delete(id:number) {
    let urlAuth = '/cliente/'+id;
    return this.http.delete(urlAuth);
  }
}
