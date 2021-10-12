import { Component, Input, OnInit } from '@angular/core';
import { IArticle } from 'src/app/shared/models/Article';

@Component({
  selector: 'app-card-feed',
  templateUrl: './card-feed.component.html',
  styleUrls: ['./card-feed.component.scss']
})
export class CardFeedComponent implements OnInit {
  @Input() article:IArticle;

  constructor() { }

  ngOnInit(): void {
  }

}
