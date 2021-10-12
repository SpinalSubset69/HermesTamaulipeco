import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { SharedModule } from '../shared/shared.module';
import { CarouselConfig } from 'ngx-bootstrap/carousel';
import { CardFeedComponent } from './Components/card-feed/card-feed.component';



@NgModule({
  declarations: [
    HomeComponent,
    CardFeedComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ], providers: [
    {provide: CarouselConfig, useValue: { interval: 2500, noPause: false, showIndicators: true }}
  ] 
})
export class HomeModule { }
