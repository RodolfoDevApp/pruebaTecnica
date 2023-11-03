import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Cliente } from 'src/app/models/Cliente.model';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  filterText: string = '';
  p:number=1; 
  registerForm: FormGroup;
  
  data: Cliente[] = []; 
  filteredData: Cliente[] = [];
  id:number=0;
 
  @ViewChild('content', { static: true }) content: ElementRef | undefined;

  constructor(private modalService: NgbModal,private formBuilder: FormBuilder,private clienteService:ClienteService) {
    this.registerForm = this.formBuilder.group({
      nombre: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      direccion: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
    this.filterData();
   }

  ngOnInit(): void {
    this.getClientes();
  }
  getClientes(){
    this.clienteService.getAll().subscribe(res =>{
      this.data= res;
      this.filteredData = this.data;
    });
  }
  
  filterData(): void {
    this.filteredData = this.data
      .filter(item => item.nombre.toLowerCase().includes(this.filterText.toLowerCase()));
  }

  editItem(): void {
    // Lógica para editar un elemento
    if (!this.registerForm.valid) {
      return;
    }
    const {nombre="",apellidos="",dirección="",password=""} = {...this.registerForm.value};
    this.clienteService.update(this.id,nombre,apellidos,dirección,password).subscribe(res =>{
      this.getClientes();
      this.registerForm.reset();
      this.id = 0;
      this.modalService.dismissAll('close');
    })
  }

  deleteItem(index: number): void {
    // Lógica para eliminar un elemento
    this.clienteService.delete(index).subscribe(res =>{
      this.getClientes();
    });
  }
  openModal(content: any,data?:Cliente) {
    this.registerForm.reset();
    this.id = data?data.clienteId:0;
    if (this.id>0 && data) {
      data.password = ""
      this.registerForm.patchValue(data)
    }
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }
  onSubmit() {
    if (!this.registerForm.valid) {
      return;
    }
    const {nombre="",apellidos="",direccion="",password=""} = {...this.registerForm.value};
    this.clienteService.register(nombre,apellidos,direccion,password).subscribe(res =>{
      this.getClientes();
      this.registerForm.reset();
      this.modalService.dismissAll('close');
    })
  }
  
}
