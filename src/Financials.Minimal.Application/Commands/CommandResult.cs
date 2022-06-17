namespace Financials.Minimal.Application.Commands
{
    public struct CommandResult
    {
        public CommandResult(string message, bool completed)
        {
            Message = message;
            Completed = completed;
        }

        public string Message { get; init; }
        public bool Completed { get; init; }
    }
}
