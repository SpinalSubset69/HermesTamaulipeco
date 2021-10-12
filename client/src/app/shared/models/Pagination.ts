import { IArticle } from "./Article";
import { IAuthor } from "./Author";

export interface IPaginationAuthor{
    pageSize:number,
    pageIndex:number,
    count:number,
    data:IAuthor[]
}

export interface IPaginationArticle{
    pageSize:number,
    pageIndex:number,
    count:number,
    data:IArticle[]
}