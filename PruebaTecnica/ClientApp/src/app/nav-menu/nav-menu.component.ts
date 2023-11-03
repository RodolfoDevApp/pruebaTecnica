import { Component, ElementRef, ViewChild } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Articulo } from '../models/Articulo.model';
import { ArticuloService } from '../services/articulo.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  p: number = 1;
  ArticulosList:Articulo[] = [];
  isExpanded = false;
  @ViewChild('content', { static: true }) content: ElementRef | undefined;

  constructor(private authS:AuthService,private articulos:ArticuloService,private modalService: NgbModal){}
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout(){
    this.authS.logout();
    
  }
  
  loadCart(content:any) {
    const idString = localStorage.getItem('id');

    if (idString !== null) {
      const idNumber = parseInt(idString, 10); 
      if (!isNaN(idNumber)) {
        // Conversion was successful, and idNumber now holds the numeric value
        this.articulos.getCart(idNumber).subscribe(res=>{
          this.ArticulosList = res;
          this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });

        })
      } else {
        console.log('Failed to parse "id" as a number');
      }
    } else {
      console.log('No value found for "id" in localStorage');
    }
    
  }
}
