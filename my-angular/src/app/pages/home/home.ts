import {Component, OnInit} from '@angular/core';
import {CategoryService} from '../../services/category.service';
import {Category} from '../../models/Category';
import {CommonModule} from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})

export class Home implements OnInit {

  //Це наш список категорій
  categories: Category[] = [];

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    console.log("Home page on init");
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
      console.log("categories", categories);
    });
  }
}
