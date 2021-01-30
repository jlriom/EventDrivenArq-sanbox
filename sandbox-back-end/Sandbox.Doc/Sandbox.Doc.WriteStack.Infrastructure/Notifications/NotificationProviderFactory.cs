using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentCreation;
using Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentDeletion;
using Sandbox.Doc.WriteStack.Infrastructure.Notifications.DocumentUpdate;

namespace Sandbox.Doc.WriteStack.Infrastructure.Notifications
{
    public class NotificationProviderFactory : INotificationProviderFactory
    {
        public INotificationProvider CreateDocumentCreatedSuccessFullyNotification()
        {
            return new DocumentCreatedSuccessFullyNotificationProvider();
        }

        public INotificationProvider CreateDocumentCreatedSuccessFullyButProblemSendingEmailNotification()
        {
            return new DocumentCreatedSuccessFullyButProblemSendingEmailNotificationProvider();
        }

        public INotificationProvider CreateDocumentHasNotBeenCreatedDueToTechnicalErrorNotification()
        {
            return new DocumentHasNotBeenCreatedDueToTechnicalErrorNotificationProvider();
        }

        public INotificationProvider CreateDocumentUpdatedSuccessFullyNotification()
        {
            return new DocumentUpdatedSuccessFullyNotificationProvider();
        }

        public INotificationProvider CreateDocumentUpdatedSuccessFullyButProblemSendingEmailNotification()
        {
            return new DocumentUpdatedSuccessFullyButProblemSendingEmailNotificationProvider();
        }

        public INotificationProvider CreateDocumentHasNotBeenUpdatedDueToTechnicalErrorNotification()
        {
            return new DocumentHasNotBeenUpdatedDueToTechnicalErrorNotificationProvider();
        }

        public INotificationProvider CreateDocumentDeletedSuccessFullyNotification()
        {
            return new DocumentDeletedSuccessFullyNotificationProvider();
        }

        public INotificationProvider CreateDocumentDeletedSuccessFullyButProblemSendingEmailNotification()
        {
            return new DocumentDeletedSuccessFullyButProblemSendingEmailNotificationProvider();
        }

        public INotificationProvider CreateDocumentHasNotBeenDeletedDueToTechnicalErrorNotification()
        {
            return new DocumentHasNotBeenDeletedDueToTechnicalErrorNotificationProvider();
        }
    }
}
