import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Sistema } from '../models/sistemas';


@Injectable({
  providedIn: 'root'
})
export class SistemaService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/Sistemas/';
  }

  getSistemas(pesquisa): Observable<Sistema[]> {
    return this.http.get<Sistema[]>(this.myAppUrl + this.myApiUrl + "?sigla=" + pesquisa.Sigla + "&descricao=" + pesquisa.Descricao+"&email="+pesquisa.Email)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getSistema(Id: number): Observable<Sistema> {
    return this.http.get<Sistema>(this.myAppUrl + this.myApiUrl + Id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveSistema(sistema): Observable<Sistema> {
    return this.http.post<Sistema>(this.myAppUrl + this.myApiUrl, JSON.stringify(sistema), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateSistema(postId: number, sistema): Observable<Sistema> {
    return this.http.put<Sistema>(this.myAppUrl + this.myApiUrl + postId, JSON.stringify(sistema), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteSistema(postId: number): Observable<Sistema> {
    return this.http.delete<Sistema>(this.myAppUrl + this.myApiUrl + postId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
