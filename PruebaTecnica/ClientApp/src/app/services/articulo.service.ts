import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Articulo } from '../models/Articulo.model';

@Injectable({
  providedIn: 'root'
})
export class ArticuloService {
  
  constructor(private http:HttpClient) { }

  register(Codigo:string,Descripcion:string,Precio:number,Imagen:string,Stock:number){
    let urlAuth = '/articulo';
    return this.http.post(urlAuth,{Codigo,Descripcion,Precio,Imagen,Stock});
  }
  relationCA(ClienteId:number,ArticuloId:number ){
    let urlAuth = '/articulo/cliente/articulo';
    return this.http.post(urlAuth,{ClienteId,ArticuloId});
  }
  getAll(){
    let urlAuth = '/articulo';
    return this.http.get<Articulo[]>(urlAuth);
  }
  update(ArticuloId:number,Codigo:string,Descripcion:string,Precio:number,Imagen:string,Stock:number){
    let urlAuth = '/articulo/'+ArticuloId;
    return this.http.put(urlAuth,{ArticuloId,Codigo,Descripcion,Precio,Imagen,Stock});
  }
  delete(id:number){
    let urlAuth = '/articulo/'+id;
    return this.http.delete(urlAuth);
  }
  getCart(id:number){
    let urlAuth = '/articulo/cliente/articulo/'+id;
    return this.http.get<Articulo[]>(urlAuth);
  }
}
