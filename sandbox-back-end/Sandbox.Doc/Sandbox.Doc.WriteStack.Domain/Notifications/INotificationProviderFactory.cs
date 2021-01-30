namespace Sandbox.Doc.WriteStack.Domain.Notifications
{
    public interface INotificationProviderFactory
    {
        INotificationProvider CreateDocumentCreatedSuccessFullyNotification();

        INotificationProvider CreateDocumentCreatedSuccessFullyButProblemSendingEmailNotification();

        INotificationProvider CreateDocumentHasNotBeenCreatedDueToTechnicalErrorNotification();

        INotificationProvider CreateDocumentUpdatedSuccessFullyNotification();

        INotificationProvider CreateDocumentUpdatedSuccessFullyButProblemSendingEmailNotification();

        INotificationProvider CreateDocumentHasNotBeenUpdatedDueToTechnicalErrorNotification();

        INotificationProvider CreateDocumentDeletedSuccessFullyNotification();

        INotificationProvider CreateDocumentDeletedSuccessFullyButProblemSendingEmailNotification();

        INotificationProvider CreateDocumentHasNotBeenDeletedDueToTechnicalErrorNotification();

    }
}
