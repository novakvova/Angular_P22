import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {Category} from '../models/Category';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {

  private apiUrl = 'http://localhost:5242/api/';

  constructor(private http: HttpClient) { }

  getCategories() : Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl + 'categories');
  }
}
