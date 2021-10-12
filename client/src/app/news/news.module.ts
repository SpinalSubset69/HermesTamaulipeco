import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsComponentComponent } from './news-component.component';
import { MainbannerComponent } from './mainbanner/mainbanner.component';
import { NewsCardComponent } from './news-card/news-card.component';



@NgModule({
  declarations: [
    NewsComponentComponent,
    MainbannerComponent,
    NewsCardComponent
  ],
  imports: [
    CommonModule
  ], exports: [
    NewsComponentComponent,
    MainbannerComponent
  ]
})
export class NewsModule { }
