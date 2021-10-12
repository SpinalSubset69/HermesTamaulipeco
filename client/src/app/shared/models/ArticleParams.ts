import { Sanitizer } from "@angular/core";

export class ArticleParams{    
    authorId:number;
    category:string;
    name:string;
    sort:string = "orderDesc";
    date:string;
    pageIndex:number = 1;
    pageSize:number = 6;
}