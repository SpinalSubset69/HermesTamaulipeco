import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { SearchComponent } from './Components/search/search.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@NgModule({
  declarations: [
    NavbarComponent,
    SearchComponent
  ],
  imports: [
    CommonModule,
    CarouselModule.forRoot()
  ], exports : [
    NavbarComponent,
    SearchComponent,
    CarouselModule
  ]
})
export class SharedModule { }
