import { Component, OnInit } from '@angular/core';
import { OpenIdConnectService, TestService } from '@sandbox-front-end/core';
import { environment } from '../../environments/environment';

@Component({
  selector: 'sandbox-front-end-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  claims: string[] = [];
  
  constructor(private openIdConnectService: OpenIdConnectService, private testService: TestService) { }

  ngOnInit() {
    Object.keys(this.openIdConnectService.user.profile).forEach(property => {
      this.claims.push(
        `${property} : ${this.openIdConnectService.user.profile[property]}`
      );
    });
    console.log('profile claims: ', this.claims);
  }

  callApi(): void {
    this.testService.test(environment.apiUrl).subscribe( result => {
      console.log('result -->', result);
    },
    err => console.error(err));
  }

}
