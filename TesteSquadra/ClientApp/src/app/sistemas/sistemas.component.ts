import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SistemaService } from '../services/sistema.service';
import { Sistema } from '../models/sistemas';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-sistemas',
  templateUrl: './sistemas.component.html',
  styleUrls: ['./sistemas.component.scss']
})
export class SistemasComponent implements OnInit {
  sistemas$: Observable<Sistema[]>;
  public p: number = 1; //pagina atual na paginação
  public count: number = 2; //itens por pagina
  pesquisaForm: any; //formulario para pesquisa
  buscando = false; //saber se esta sendo feito uma busca
  constructor(private SistemaService: SistemaService, private formbulider: FormBuilder, private router: Router) {
  }

  ngOnInit() {
    this.pesquisaForm = this.formbulider.group({
      Descricao: [''],
      Sigla: [''],
      Email: ['', [Validators.compose([Validators.email])]],
    });  
  }
  onPesquisaFormSubmit() {
   //recebe os dados da busca
    const pesquisa = this.pesquisaForm.value;
    //busca na api
    this.loadSistemas(pesquisa);
    //avisa que ta buscando
    this.buscando = true;
    //volta para a pagina 1 da paginação
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
       debugger
        this.resetForm();
        this.p = 1;
      });
    }
  }
  get email() { return this.pesquisaForm.get('Email'); }
}

