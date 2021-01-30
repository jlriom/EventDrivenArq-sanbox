import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'signout-callback-oidc',
  templateUrl: './signout-callback-oidc.component.html',
  styleUrls: ['./signout-callback-oidc.component.css']
})
export class SignoutCallbackOidcComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.navigate(["./"]);
  }
}
