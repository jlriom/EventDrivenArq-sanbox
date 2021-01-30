import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SigninOidcComponent, RedirectSilentRenewComponent, SignoutCallbackOidcComponent } from '@sandbox-front-end/components';
import { RequireAuthenticatedUserRouteGuardService } from '@sandbox-front-end/core';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent ,   canActivate: [RequireAuthenticatedUserRouteGuardService]  },
  { path: 'signin-oidc', component: SigninOidcComponent },
  { path: 'signout-callback-oidc', component: SignoutCallbackOidcComponent },
  { path: 'redirect-silentrenew', component: RedirectSilentRenewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }