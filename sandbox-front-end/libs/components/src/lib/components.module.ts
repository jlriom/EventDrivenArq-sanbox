import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';
import { RedirectSilentRenewComponent } from './redirect-silect-renew/redirect-silect-renew.component';
import { SignoutCallbackOidcComponent } from './signout-callback-oidc/signout-callback-oidc.component';

@NgModule({
  declarations: [
    SigninOidcComponent,
    RedirectSilentRenewComponent,
    SignoutCallbackOidcComponent
  ],
  imports: [CommonModule],
  exports: [
    SigninOidcComponent,
    SignoutCallbackOidcComponent,
    RedirectSilentRenewComponent,
  ]
})
export class ComponentsModule {}