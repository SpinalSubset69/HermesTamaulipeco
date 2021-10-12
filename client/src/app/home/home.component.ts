import { Component, OnInit } from '@angular/core';
import { NewsserviceService } from '../news/newsservice.service';
import { IArticle } from '../shared/models/Article';
import { ArticleParams } from '../shared/models/ArticleParams';
import { HostListener } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  articleParams = new ArticleParams();
  mainArticles:IArticle[];

  
  constructor(private articleService:NewsserviceService) { }

  ngOnInit(): void {
    this.onActivePanel();
    this.getLastArticles();
  }

  getLastArticles(){
    this.articleParams.pageSize = 3;    
    this.articleService.getLastArticle(this.articleParams).subscribe(response => {
      this.mainArticles = response.data;
      console.log(this.mainArticles);
    }, err => {
      console.log(err);
    })
  }

  onActivePanel(){
    let panels = document.querySelectorAll('.panel');
    console.log(panels);
    panels.forEach((panel => {
      panel.addEventListener('mouseover', () => {
        this.removeActiveClass(panels);
        panel.classList.add('active');
      });
    }));
  }

  removeActiveClass(panels:any){
    panels.forEach(panel => {
      panel.classList.remove('active');
    })
  }


}
