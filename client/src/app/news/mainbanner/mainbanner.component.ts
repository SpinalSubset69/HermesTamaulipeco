import { Component, Input, OnInit, ViewChildren } from '@angular/core';
import { IArticle } from 'src/app/shared/models/Article';

@Component({
  selector: 'app-mainbanner',
  templateUrl: './mainbanner.component.html',
  styleUrls: ['./mainbanner.component.scss']
})
export class MainbannerComponent implements OnInit {
  @Input() article:IArticle;
  
  
  constructor() { }

  ngOnInit(): void {
       
  }

 

}
