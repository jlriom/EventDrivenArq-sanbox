namespace Sandbox.Doc.WriteStack.Domain.Emails
{
    public interface IEmailProvider
    {
        string GetSubject();
        string GetBody();
        string[] GetTo();
        string[] GetCc();
    }
}
