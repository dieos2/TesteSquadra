import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { SistemaService } from '../services/sistema.service';
import { Sistema } from '../models/sistemas';

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
  formUsuarioResponsavel: string;
  formStatus: string;

  postId: number;
  errorMessage: any;
  existingSistema: Sistema;

  constructor(private sistemaservice: SistemaService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formDescricao = 'descricao';
    this.formSigla = 'sigla';
    this.formUrl = 'url';
    this.formEmail = 'email';
    this.formJustificativa = '';
    this.formStatus = '';
    if (this.avRoute.snapshot.params[idParam]) {
      this.postId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        postId: 0,
        descricao: ['', [Validators.required]],
        sigla: ['', [Validators.required]],
        email: "",
        url: "",
      }
    )
  }

  ngOnInit() {

    if (this.postId > 0) {
      this.actionType = 'Edit';
      this.sistemaservice.getSistema(this.postId)
        .subscribe(data => (
          this.existingSistema = data,
          this.form.controls[this.formDescricao].setValue(data.descricao),
          this.form.controls[this.formSigla].setValue(data.sigla),
          this.form.controls[this.formEmail].setValue(data.email),
          this.form.controls[this.formSigla].setValue(data.sigla)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let sistema: Sistema = {
        dataEdicao: new Date(),
        status: 'Ativo',
        descricao: this.form.get(this.formDescricao).value,
        sigla: this.form.get(this.formSigla).value,
        justificativa: "Inclusão",
        email: "",
        uRL: this.form.get(this.formUrl).value,
        usuarioResponsavel: 'Diego Serra'
      };

      this.sistemaservice.saveSistema(sistema)
        .subscribe((data) => {
          this.router.navigate(['/blogpost', data.id]);
        });
    }

    if (this.actionType === 'Edit') {
      let sistema: Sistema = {
        id: this.existingSistema.id,
        dataEdicao: this.existingSistema.dataEdicao,
        uRL: this.existingSistema.uRL,
        justificativa: this.existingSistema.justificativa,
        email: this.existingSistema.email,
        status: this.existingSistema.status,
        usuarioResponsavel: this.existingSistema.usuarioResponsavel,
        descricao: this.form.get(this.formDescricao).value,
        sigla: this.form.get(this.formSigla).value
      };
      this.sistemaservice.updateSistema(sistema.id, sistema)
        .subscribe((data) => {
          this.router.navigate([this.router.url]);
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get descricao() { return this.form.get(this.formDescricao); }
  get sigla() { return this.form.get(this.formSigla); }
}
