import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sandbox-front-end-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'admin-portal';

  constructor() {}

  ngOnInit(): void {
  }
}
