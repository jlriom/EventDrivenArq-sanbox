import { Component, OnInit } from '@angular/core';
import { OpenIdConnectService } from '@sandbox-front-end/core';

@Component({
  selector: 'sandbox-front-end-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'OpenID Connect In Depth Demo';  

  constructor(public openIdConnectService: OpenIdConnectService) {
  }
 
  ngOnInit(): void {
  }
}
