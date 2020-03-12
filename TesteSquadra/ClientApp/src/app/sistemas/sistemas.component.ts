import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SistemaService } from '../services/sistema.service';
import { Sistema } from '../models/sistemas';

import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-sistemas',
  templateUrl: './sistemas.component.html',
  styleUrls: ['./sistemas.component.scss']
})
export class SistemasComponent implements OnInit {
  sistemas$: Observable<Sistema[]>;
  public p: number = 1;
  public count: number = 2;
  pesquisaForm: any;
  buscando = false;
  constructor(private SistemaService: SistemaService, private formbulider: FormBuilder) {
  }

  ngOnInit() {
    this.pesquisaForm = this.formbulider.group({
      Descricao: [''],
      Sigla: [''],
      Email: ['', [Validators.compose([Validators.email])]],
    });  
  }
  onPesquisaFormSubmit() {
   
    const pesquisa = this.pesquisaForm.value;
    this.loadSistemas(pesquisa);
    this.buscando = true;
    this.p = 1;
  } 
  loadSistemas(pesquisa) {
   
    this.sistemas$ = this.SistemaService.getSistemas(pesquisa);
    
  }
  resetForm() {
    
    this.pesquisaForm.reset();
    this.onPesquisaFormSubmit();
    this.buscando = false;
  }

  delete(Id) {
    const ans = confirm('Você deseja deletar o sistema de id: ' + Id);
    
    if (ans) {
      this.SistemaService.deleteSistema(Id).subscribe((data) => {
        this.p = 1;
      });
    }
  }
  get email() { return this.pesquisaForm.get('Email'); }
}

