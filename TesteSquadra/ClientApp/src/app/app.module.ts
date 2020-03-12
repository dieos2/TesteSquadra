import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlertModule } from "ngx-bootstrap";
import { SistemasComponent } from './sistemas/sistemas.component';
import { SistemaComponent } from './sistema/sistema.component';
import { SistemaAddEditComponent } from './sistema-add-edit/sistema-add-edit.component';
import { SistemaService } from './services/sistema.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { FlashAlertComponent } from './flash-alert/flash-alert.component';

@NgModule({
  declarations: [
    AppComponent,
    SistemasComponent,
    SistemaComponent,
    SistemaAddEditComponent,
    FlashAlertComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    AlertModule.forRoot()
  ],
  providers: [
    SistemaService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
