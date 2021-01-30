namespace Sandbox.Shared.Messaging.Messages
{
    public class Failure<T>
    {
        public string Message { get; set; }
        public string Details { get; set; }

        public T Data { get; set; }

        public Failure() {}

        public Failure(T data, string message, string details)
        {
            Data = data;
            Message = message;
            Details = details;
        }
    }
}
