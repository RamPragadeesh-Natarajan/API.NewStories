import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {MatPaginator, MatPaginatorModule, PageEvent} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import { StoriesService } from './stories.service';
import { response } from 'express';

export interface PeriodicElement {
  URL: string;
  StoryNumber: number;
  Title: string;
 
}

var ELEMENT_DATA: any;

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatTableModule, MatPaginatorModule, MatInputModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit  {
   constructor(private _service:StoriesService){
    
  }
 responseStories:any;
  page: any;
  displayedColumns: string[] = ['Story', 'URL', 'Title'];
  dataSource :any;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  ngOnInit(): void {
    
    this.getnewStories();
    this.dataSource = new MatTableDataSource<any>(ELEMENT_DATA);
  } 
  
  handlePageEvent(e: PageEvent) {
    this.page = e.pageIndex;
  }

  getnewStories(){
    if(this.page == undefined){
      this.page = 0
    }
    this._service.getNewStories(this.page+1)
        .subscribe((response:any)=> {
         ELEMENT_DATA = response;
         this.dataSource = new MatTableDataSource<any>(ELEMENT_DATA);
        
        });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
