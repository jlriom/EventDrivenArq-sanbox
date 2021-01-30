import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { ReplaySubject } from 'rxjs';

@Injectable()
export class OpenIdConnectService {
    private userManager: UserManager;

    private currentUser: User;

    userLoaded$ = new ReplaySubject<boolean>(1);

    get userAvailable() : boolean {
        return this.currentUser != null;
    }

    get user(): User {
        return this.currentUser;
    }

    constructor(userManager: UserManager) {

        console.log('OpenIdConnectService.contructor');

        this.userManager = userManager;

    } 

    Init() {
        console.log('Init user manager');
        this.userManager.clearStaleState();
        this.userManager.events.addUserLoaded(user => {
            console.log('User loaded.', user);
            this.currentUser = user;
            this.userLoaded$.next(true);
        });

        this.userManager.events.addUserUnloaded(() => {
            console.log('User unloaded.');
            this.currentUser = null;
            this.userLoaded$.next(false);
        });

        this.userManager.events.addUserSignedOut(() => {
            console.log('User signed out.');
            this.currentUser = null;
            this.userLoaded$.next(false);
        });
    }

    triggerSignIn() {
        this.userManager.signinRedirect().then(function () {
            console.log('Redirection to signin triggered.');
        });
    }

    handleCallback() {
        this.userManager.signinRedirectCallback().then(function (user) {
            console.log('Callback after signin handled.', user);
        });
    }

    handleSilentCallback() {
        this.userManager.signinSilentCallback().then(function (user) {       
            this.currentUser = user;
            console.log('Callback after silent signin handled.', user);
        });
    }

    triggerSignOut() {
        this.userManager.signoutRedirect().then(function (resp) {
            console.log('Redirection to sign out triggered.', resp);
        });
    };
}
