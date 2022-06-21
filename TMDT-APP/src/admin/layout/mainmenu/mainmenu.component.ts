import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/services/authentication.service';
import { IUSer } from 'src/services/interface.service';

@Component({
  selector: 'app-mainmenu',
  templateUrl: './mainmenu.component.html',
})
export class MainMenuComponent implements OnInit, OnDestroy {

  constructor(private router: Router,public authService: AuthenticationService) {
  }
  currentUserRole!: string;
  ngOnDestroy(): void {
    //throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
  } 
  logout() {
    this.authService.logout();
}
}
