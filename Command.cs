using System;

class CommandException : Exception
{
    public CommandException() : base("Ошибка выполнения команды поворота танка") { }
}

namespace Tanks.Engine
{
    public interface Command
    {
        void Action();
    }
}
