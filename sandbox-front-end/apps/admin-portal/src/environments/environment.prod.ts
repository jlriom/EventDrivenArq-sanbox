export const environment = {
  production: true,
  usrApiUrl: 'https://localhost:5001/api/v1',
  consoleApiUrl: 'https://localhost:5010/api/v1',
  emailerApiUrl: 'https://localhost:5003/api/v1',
  notifierApiUrl: 'https://localhost:5004/api/v1',
  openIdConnectSettings: {
    authority: 'https://localhost:5100',
    client_id: 'sandboxadminui',
    redirect_uri: 'http://localhost:4201/signin-oidc',
    post_logout_redirect_uri: 'http://localhost:4201',
    response_type: 'code',
    scope: 'openid profile sandbox:usr:api sandbox:console:api sandbox:emailer:api sandbox:notifier:api',
    automaticSilentRenew: true,
    silent_redirect_uri: 'http://localhost:4201/redirect-silentrenew',
    loadUserInfo: true,
    revokeAccessTokenOnSignout: true
  }
};
 