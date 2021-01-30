import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AddAuthorizationHeaderInterceptor, ErrorLoggerService, GlobalErrorHandler, OpenIdConnectService, RequireAuthenticatedUserRouteGuardService, TestService, WriteOutJsonInterceptor } from '@sandbox-front-end/core';
import { UserManager } from 'oidc-client';
import { environment } from '../environments/environment';


const userManager: UserManager = new UserManager(environment.openIdConnectSettings);

@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [    
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AddAuthorizationHeaderInterceptor,
      multi: true
    },  
    {
      provide: HTTP_INTERCEPTORS,
      useClass: WriteOutJsonInterceptor,
      multi: true
    },
    GlobalErrorHandler, 
    ErrorLoggerService,  
    {
      provide: OpenIdConnectService,
      useFactory: () => {
        return new OpenIdConnectService(userManager);
      }
    },    
    // {
    //   provide: TestService,
    //   useFactory: (http: HttpClient) => {
    //     return new TestService(http, environment.apiUrl);
    //   }
    // },
    TestService,
    RequireAuthenticatedUserRouteGuardService],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(openIdConnectService: OpenIdConnectService){
    openIdConnectService.Init();
  }
}
