import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';
import { CategoryService } from 'src/app/services/category.service';

// export interface infor {
//   isSuccess: boolean;
//   message: string;
//   data: {
//     id: number;
//     categoryName: string;
//     categoryDescription: string;
//   };
// }
interface Category {
  id: number;
  categoryName: string;
  categoryDescription: string;
}

// interface Category {
//   id: number;
//   categoryName: string;
//   categoryDescription: string;
// }

// interface detail {
//   id: number;
//   categoryName: string;
//   categoryDescription: string;
// }

// interface AllCategory {
//   id: number;
//   title: string;
//   content: string;
//   categoryName: string;
//   categoryDescription: string;
// }

@Component({
  selector: 'app-categorym',
  templateUrl: './categorym.component.html',
  styleUrls: ['./categorym.component.scss'],
})
export class CategorymComponent implements OnInit {
  catName: string = '';
  content: string = '';
  // [x: string]: any;
  showm: boolean = false;
  // category: Category[] = [];
  allCat: {
    id: number;
    title: string;
    content: string;
    categoryName: string;
    categoryDescription: string;
  }[] = [];
  allCategory: Category[] = [];

  // detailCategory: detail = {
  //   id: 0,
  //   categoryName: '',
  //   categoryDescription: '',
  // };

  constructor(
    private categoryService: CategoryService,
    public appService: AppService
  ) {}

  ngOnInit() {
    this.catName = '';
    this.content = '';
    // this.categoryService.getAllCategory().subscribe((res: Category[]) => {
    //   this.category = res;
    // });
  }
  cl() {
    this.showm = false;
  }

  onBtnClick() {
    console.log('Clicked!');
  }
  addNew(input: { value: any }) {
    console.log(input.value);
    this.allCat.push({
      id: 5,
      title: this.catName,
      content: this.content,
      categoryName: '',
      categoryDescription: '',
    });
  }

  // allCategory(input: { value: any }) {
  //   console.log(input.value);
  //   this.category.push({
  //     id: 5,
  //     categoryName: '',
  //     categoryDescription: '',
  //   });
  // }
  deleteCat(index: number) {
    this.allCat.splice(index, 1);
  }
}
