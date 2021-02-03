namespace RequestExecutor.Services
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
