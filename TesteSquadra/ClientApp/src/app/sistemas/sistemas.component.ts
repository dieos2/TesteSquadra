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
  public p: number = 1;
  public count: number = 1;
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
