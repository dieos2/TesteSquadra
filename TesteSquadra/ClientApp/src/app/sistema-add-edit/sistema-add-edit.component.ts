import { AppEventService } from '../app-event.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { SistemaService } from '../services/sistema.service';
import { Sistema } from '../models/sistemas';

import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-sistema-add-edit',
  templateUrl: './sistema-add-edit.component.html',
  styleUrls: ['./sistema-add-edit.component.scss']
})
export class SistemaAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formDescricao: string;
  formSigla: string;
  formUrl: string;
  formEmail: string;
  formJustificativa: string;
  formJustificativaNova: string;
  formUsuario: string;
  formStatus: string;
  formDataedicao: string;
  pipe = new DatePipe('en-US'); // Use your own locale
  postId: number;
  errorMessage: any;
  existingSistema: Sistema;

  constructor(private sistemaservice: SistemaService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Manter';
    this.formDescricao = 'descricao';
    this.formSigla = 'sigla';
    this.formUrl = 'urlsistema';
    this.formEmail = 'emailsistema';
    this.formJustificativa = 'justificativa';
    this.formStatus = 'status';
    this.formUsuario = 'usuarioR';
    this.formDataedicao = 'dataedicao';
    this.formJustificativaNova = 'justificativaNova';

    if (this.avRoute.snapshot.params[idParam]) {
      this.postId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        postId: 0,
        descricao: ['', [Validators.required]],
        sigla: ['', [Validators.required]],
        emailsistema: ['', [Validators.compose([Validators.email])]],
        urlsistema: [''],
        status: [''],
        justificativa: [''],
        justificativaNova: ['', [Validators.required]],
        usuario: [''],
        dataedicao: [''],
      }
    )
  }

  ngOnInit() {

    if (this.postId > 0) {
      this.actionType = 'Editar';
      
      this.sistemaservice.getSistema(this.postId)
        .subscribe(data => (
          this.existingSistema = data,
        
          this.form.controls[this.formDescricao].setValue(data.descricao),

          this.form.controls[this.formSigla].setValue(data.sigla),
          this.form.controls[this.formEmail].setValue(data.email), 
          this.form.controls[this.formUrl].setValue(data.url),
          this.form.controls[this.formStatus].setValue(data.status),

          this.form.controls[this.formDataedicao].setValue(this.pipe.transform(data.dataEdicao, 'dd/MM/yyyy HH:mm:ss')),
          this.form.controls[this.formJustificativa].setValue(data.justificativa),
          this.form.controls['usuario'].setValue(data.usuarioResponsavel)


        ));

    } else {
      this.form.controls[this.formJustificativaNova].setValue("Insercao")
    }
  }

  save() {
    if (!this.form.valid) {

      return;
    }

    if (this.actionType === 'Manter') {
      let sistema: Sistema = {
        dataEdicao: new Date(),
        status: 'Ativo',
        descricao: this.form.get(this.formDescricao).value,
        sigla: this.form.get(this.formSigla).value,
        justificativa: "Inclusão",
        email: this.form.get(this.formEmail).value,
        url: this.form.get(this.formUrl).value,
        usuarioResponsavel: 'Diego Serra'
      };

      this.sistemaservice.saveSistema(sistema)
        .subscribe((data) => {
          AppEventService.set('success', 'Sistema', 'Inserido com sucesso');
               
                
        });
    }

    if (this.actionType === 'Editar') {
      let sistema: Sistema = {
        id: this.existingSistema.id,
        dataEdicao: new Date(),
        url: this.form.get(this.formUrl).value,
        justificativa: this.form.get(this.formJustificativaNova).value,
        email: this.form.get(this.formEmail).value,
        status: this.form.get(this.formStatus).value,
        usuarioResponsavel: "Diego Serra",
        descricao: this.form.get(this.formDescricao).value,
        sigla: this.form.get(this.formSigla).value
      };
      this.sistemaservice.updateSistema(sistema.id, sistema)
        .subscribe((data) => {
          AppEventService.set('success', 'Sistema', 'Editado com sucesso');
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get descricao() { return this.form.get(this.formDescricao); }
  get sigla() { return this.form.get(this.formSigla); }
  get email() { return this.form.get(this.formEmail); }
  get url() { return this.form.get(this.formUrl); }
  get justificativa() { return this.form.get(this.formJustificativaNova); }
  get status() { return this.form.get(this.formStatus); }
  get usuario() { return this.form.get(this.formUsuario); }
  get data() { return this.form.get(this.formDataedicao); }
}
