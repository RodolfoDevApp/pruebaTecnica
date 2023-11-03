import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Articulo } from 'src/app/models/Articulo.model';
import { ArticuloService } from 'src/app/services/articulo.service';

@Component({
  selector: 'app-articulos',
  templateUrl: './articulos.component.html',
  styleUrls: ['./articulos.component.css']
})
export class ArticulosComponent implements OnInit {
  filterText: string = '';
  p: number = 1;
  registerForm: FormGroup;

  data: Articulo[] = [];
  filteredData: Articulo[] = [];
  id: number = 0;

  @ViewChild('content', { static: true }) content: ElementRef | undefined;

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private articuloService: ArticuloService) {
    this.registerForm = this.formBuilder.group({
      codigo: ['', [Validators.required]],
      descripcion: ['', [Validators.required]],
      precio: ['', [Validators.required]],
      imagen: ['', [Validators.required]],
      stock: ['', [Validators.required]],
    });
    this.filterData();
  }

  ngOnInit(): void {
    this.getClientes();
  }
  getClientes() {
    this.articuloService.getAll().subscribe(res => {
      this.data = res;
      this.filteredData = this.data;
    });
  }

  filterData(): void {
    this.filteredData = this.data
      .filter(item => item.codigo.toLowerCase().includes(this.filterText.toLowerCase()));
  }
  addToCart(index: number): void {
    const idString = localStorage.getItem('id');

    if (idString !== null) {
      const idNumber = parseInt(idString, 10); 
      if (!isNaN(idNumber)) {
        // Conversion was successful, and idNumber now holds the numeric value
        this.articuloService.relationCA(idNumber,index).subscribe(res=>{
          console.log();
          this.getClientes();
        });
        console.log(idNumber);
      } else {
        console.log('Failed to parse "id" as a number');
      }
    } else {
      console.log('No value found for "id" in localStorage');
    }
  }
  addToStore(index: number) {

  }
  editItem(): void {
    // Lógica para editar un elemento
    if (!this.registerForm.valid) {
      return;
    }
    const { codigo = "", descripcion = "", precio = "", imagen = "", stock = "" } = { ...this.registerForm.value };
    this.articuloService.update(this.id, codigo, descripcion, precio, imagen, stock).subscribe(res => {
      this.getClientes();
      this.registerForm.reset();
      this.id = 0;
      this.modalService.dismissAll('close');
    })
  }

  deleteItem(index: number): void {
    // Lógica para eliminar un elemento
    this.articuloService.delete(index).subscribe(res => {
      this.getClientes();
    });
  }


  openModal(content: any, data?: Articulo) {
    this.registerForm.reset();
    this.id = data ? data.articuloId : 0;
    if (this.id > 0 && data) {
      this.registerForm.patchValue(data)
    }
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }
  onSubmit() {
    if (!this.registerForm.valid) {
      return;
    }
    const { codigo = "", descripcion = "", precio = "", imagen = "", stock = "" } = { ...this.registerForm.value };
    this.articuloService.register(codigo, descripcion, precio, imagen, stock).subscribe(res => {
      this.getClientes();
      this.registerForm.reset();
      this.modalService.dismissAll('close');
    })

  }
}
