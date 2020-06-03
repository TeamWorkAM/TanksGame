using System;

class CommandException : Exception
{
    public CommandException() : base("Ошибка выполнения команды") { }
}

namespace Tanks.Engine
{
    public interface Command
    {
        void Action();
    }
}
