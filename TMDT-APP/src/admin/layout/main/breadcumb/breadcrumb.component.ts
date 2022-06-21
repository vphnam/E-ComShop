import { Component, OnInit } from '@angular/core';
import { BreadCrumbService } from 'src/services/breadcrumb.service';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
})
export class BreadCrumbComponent implements OnInit {

  constructor(public breadCrumbService: BreadCrumbService) { }

  ngOnInit(): void {
  } 

}
