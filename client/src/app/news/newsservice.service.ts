import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ArticleParams } from '../shared/models/ArticleParams';
import { IPaginationArticle } from '../shared/models/Pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NewsserviceService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http:HttpClient) { }

  getLastArticle(articleParams:ArticleParams){
    let params = new HttpParams();

    if(articleParams.category){
      params = params.append('category', articleParams.category);
    }

    if(articleParams.date){
      params = params.append('date', articleParams.date);
    }

    if(articleParams.name){
      params = params.append('name', articleParams.name);
    }

    if(articleParams.authorId){
      params = params.append('authorId', articleParams.authorId);
    }

    params = params.append('pageSize',articleParams.pageSize);
    params = params.append('pageIndex', articleParams.pageIndex);

    return this.http.get<IPaginationArticle>(`${this.baseUrl}article`, {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body; //Retornamos el cuerpo de la respuesta del servidor
      })
    );
  }
  
}
