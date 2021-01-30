namespace Sandbox.Shared.Api.Constants.Idp
{
    public static class ClientId
    {
        public const string SandboxAdminPortal = "sandboxadminui";
        public const string SandboxDocPortal = "sandboxdocui";
        public const string SandboxDocApi = "sandboxdocapi";
        public const string SandboxSwagger = "swaggerapi";

        public const string RedirectUri = "signin-oidc";
        public const string PostLogoutRedirectUri = "signout-callback-oidc";
    }
}
