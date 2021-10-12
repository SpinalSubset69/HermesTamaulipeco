import { Component, OnInit } from '@angular/core';
import { IArticle } from '../shared/models/Article';
import { ArticleParams } from '../shared/models/ArticleParams';
import { IPaginationArticle } from '../shared/models/Pagination';
import { NewsserviceService } from './newsservice.service';

@Component({
  selector: 'app-news-component',
  templateUrl: './news-component.component.html',
  styleUrls: ['./news-component.component.scss']
})
export class NewsComponentComponent implements OnInit {
  articles:IArticle[];    
  articlesParams = new ArticleParams();
  constructor(private newsService:NewsserviceService) { }

  ngOnInit(): void {    
    this.getArticles();
    this.getLastArticles();
  }

  getArticles(){
      this.newsService.getLastArticle(this.articlesParams).subscribe(response => {
        this.articles = response.data;
        console.log(this.articles);
      });
  }

  getLastArticles(){
    this.articlesParams.pageSize = 8;
    this.articlesParams.pageIndex = 1;
    this.getArticles();
  }
 
}
