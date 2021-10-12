import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  @Output() search = new EventEmitter<string>();
  @ViewChild('input') term;

  constructor() { }

  ngOnInit(): void {
    this.onHoverEvent();
  }

  onHoverEvent(){
    const search = document.querySelector('.search-container');
    const btn = document.querySelector('.btn-search');
    const input:any = document.querySelector('.inpt');

    btn.addEventListener('click', () => {
        search.classList.toggle('active');
        input.focus();
    });
  }

  onSearchTerm(){        
    if(this.term.nativeElement.value){
      this.search.emit(this.term.nativeElement.value);
      this.term.nativeElement.value = "";
    }    
  }

}
