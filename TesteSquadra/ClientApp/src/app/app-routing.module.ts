import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SistemasComponent } from './sistemas/sistemas.component';
import { SistemaComponent } from './sistema/sistema.component';
import { SistemaAddEditComponent } from './sistema-add-edit/sistema-add-edit.component';

const routes: Routes = [
  { path: '', component: SistemasComponent, pathMatch: 'full' },
  { path: 'sistema/:id', component: SistemaComponent },
  { path: 'add', component: SistemaAddEditComponent },
  { path: 'sistema/edit/:id', component: SistemaAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
