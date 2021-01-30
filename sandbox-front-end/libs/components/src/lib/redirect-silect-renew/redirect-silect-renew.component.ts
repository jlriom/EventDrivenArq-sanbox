import { Component, OnInit } from '@angular/core';
import { OpenIdConnectService } from '@sandbox-front-end/core';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'redirect-silect-renew',
  templateUrl: './redirect-silect-renew.component.html',
  styleUrls: ['./redirect-silect-renew.component.css']
})
export class RedirectSilentRenewComponent implements OnInit {

  constructor(private openIdConnectService : OpenIdConnectService) { }

  ngOnInit() {
    this.openIdConnectService.handleSilentCallback();
  }

}
