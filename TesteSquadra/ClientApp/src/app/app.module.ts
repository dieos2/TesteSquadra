import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//import { BlogPostsComponent } from './blog-posts/blog-posts.component';
//import { BlogPostComponent } from './blog-post/blog-post.component';
//import { BlogPostAddEditComponent } from './blog-post-add-edit/blog-post-add-edit.component';
//import { BlogPostService } from './services/blog-post.service';
import { SistemasComponent } from './sistemas/sistemas.component';
import { SistemaComponent } from './sistema/sistema.component';
import { SistemaAddEditComponent } from './sistema-add-edit/sistema-add-edit.component';
import { SistemaService } from './services/sistema.service';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    AppComponent,
    //BlogPostsComponent,
    //BlogPostComponent,
    //BlogPostAddEditComponent,
    SistemasComponent,
    SistemaComponent,
    SistemaAddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgxPaginationModule,
  ],
  providers: [
    //BlogPostService,
    SistemaService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
