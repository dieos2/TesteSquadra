import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SistemaService } from '../services/sistema.service';
import { Sistema } from '../models/sistemas';

@Component({
  selector: 'app-sistemas',
  templateUrl: './sistemas.component.html',
  styleUrls: ['./sistemas.component.scss']
})
export class SistemasComponent implements OnInit {
  sistemas$: Observable<Sistema[]>;

  constructor(private SistemaService: SistemaService) {
  }

  ngOnInit() {
    this.loadSistemas();
  }

  loadSistemas() {
    this.sistemas$ = this.SistemaService.getSistemas();
  }

  delete(Id) {
    const ans = confirm('Do you want to delete blog post with id: ' + Id);
    if (ans) {
      this.SistemaService.deleteSistema(Id).subscribe((data) => {
        this.loadSistemas();
      });
    }
  }
}
