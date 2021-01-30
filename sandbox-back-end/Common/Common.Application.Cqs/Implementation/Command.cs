using Common.Application.Cqs.Contracts;

namespace Common.Application.Cqs.Implementation
{
    public class Command<T> : ICommand where T : class
    {
        public Command(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}