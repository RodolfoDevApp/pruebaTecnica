import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tienda } from '../models/Tienda.model';

@Injectable({
  providedIn: 'root'
})
export class TiendaService {

  constructor(private http:HttpClient) { }

  register(Sucursal:string,Direccion:string){
    let urlAuth = '/tienda';
    return this.http.post(urlAuth,{Sucursal,Direccion});
  }
  getAll() {
    let urlAuth = '/tienda';
    return this.http.get<Tienda[]>(urlAuth);
  }
  update(TiendaId:number,Sucursal:string,Direccion:string) {
    let urlAuth = '/tienda/'+TiendaId;
    return this.http.put(urlAuth,{TiendaId,Sucursal,Direccion});
  }
  delete(id:number) {
    let urlAuth = '/tienda/'+id;
    return this.http.delete(urlAuth);
  }

}
