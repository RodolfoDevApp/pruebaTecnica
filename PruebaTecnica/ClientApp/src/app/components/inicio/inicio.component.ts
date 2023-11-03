import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Tienda } from 'src/app/models/Tienda.model';
import { TiendaService } from 'src/app/services/tienda.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  filterText: string = '';
  p:number=1; 
  registerForm: FormGroup;
  
  data: Tienda[] = []; 
  filteredData: Tienda[] = [];
  id:number=0;
 
  @ViewChild('content', { static: true }) content: ElementRef | undefined;

  constructor(private modalService: NgbModal,private formBuilder: FormBuilder,private tiendaService:TiendaService) {
    this.registerForm = this.formBuilder.group({
      sucursal: ['', [Validators.required]],
      direccion: ['', [Validators.required]],
    });
    
    this.filterData();
  }
  ngOnInit(): void {
   this.getTiendas();
  }

  getTiendas(){
    this.tiendaService.getAll().subscribe(res =>{
      this.data= res;
      this.filteredData = this.data;
    });
  }
  
  filterData(): void {
    this.filteredData = this.data
      .filter(item => item.sucursal.toLowerCase().includes(this.filterText.toLowerCase()));
  }

  editItem(): void {
    // Lógica para editar un elemento
    if (!this.registerForm.valid) {
      return;
    }
    const {sucursal="",direccion=""} = {...this.registerForm.value};
    this.tiendaService.update(this.id,sucursal,direccion).subscribe(res =>{
      this.getTiendas();
      this.registerForm.reset();
      this.id = 0;
      this.modalService.dismissAll('close');
    })
  }

  deleteItem(index: number): void {
    // Lógica para eliminar un elemento
    this.tiendaService.delete(index).subscribe(res =>{
      this.getTiendas();
    });
  }

  addToCart(item: any): void {
    // Lógica para agregar un elemento al carrito
    console.log(`Añadir al carrito: ${item.name}`);
  }
  
  openModal(content: any,data?:Tienda) {
    this.registerForm.reset();
    this.id = data?data.tiendaId:0;
    if (this.id>0 && data) {
      console.log('Entra?');
      this.registerForm.patchValue(data)
    }
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }
  onSubmit() {
    if (!this.registerForm.valid) {
      return;
    }
    const {sucursal="",direccion=""} = {...this.registerForm.value};
    this.tiendaService.register(sucursal,direccion).subscribe(res =>{
      this.getTiendas();
      this.registerForm.reset();
      this.modalService.dismissAll('close');
    })
    
  }

}
