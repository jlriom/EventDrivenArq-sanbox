using System;

namespace Sandbox.Console.ReadStack.Application.Queries.Dtos
{
    public class LogEntryDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }

        public LogEntryDto(
            int id,
            string message,
            string messageTemplate,
            string level,
            DateTime timeStamp,
            string exception,
            string properties)
        {
            Id = id;
            Message = message;
            MessageTemplate = messageTemplate;
            Level = level;
            TimeStamp = timeStamp;
            Exception = exception;
            Properties = properties;
        }
    }
}
