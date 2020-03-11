import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { SistemaService } from '../services/sistema.service';
import { Sistema } from '../models/sistemas';

@Component({
  selector: 'app-sistema',
  templateUrl: './sistema.component.html',
  styleUrls: ['./sistema.component.scss']
})
export class SistemaComponent implements OnInit {
  blogPost$: Observable<Sistema>;
  postId: number;

  constructor(private blogPostService: SistemaService, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.postId = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadBlogPost();
  }

  loadBlogPost() {
    this.blogPost$ = this.blogPostService.getSistema(this.postId);
  }
}
