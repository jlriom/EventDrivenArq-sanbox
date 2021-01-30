export const environment = {
  production: false,
  apiUrl: 'https://localhost:5001/api/v1',
  openIdConnectSettings: {
    authority: 'https://localhost:5100',
    client_id: 'sandboxdocui',
    redirect_uri: 'http://localhost:4200/signin-oidc',
    post_logout_redirect_uri: 'http://localhost:4200',
    response_type: 'code',
    scope: 'openid profile sandbox:doc:api',
    automaticSilentRenew: true,
    silent_redirect_uri: 'http://localhost:4200/redirect-silentrenew',
    loadUserInfo: true,
    revokeAccessTokenOnSignout: true
    }
};
 