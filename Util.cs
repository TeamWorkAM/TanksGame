using System;

namespace Tanks.Engine
{
    public class ReadObjectException : Exception
    {
        public ReadObjectException() : base("Ошибка чтения данных объекта") { }
        public ReadObjectException(string message) : base(message) { }
    }
    public class WriteObjectException : Exception
    {
        public WriteObjectException() : base("Ошибка записи данных в объект") { }
        public WriteObjectException(string message) : base(message) { }
    }
    public class CommandException : Exception
    {
        public CommandException() : base("Ошибка выполнения команды") { }
        public CommandException(string message) : base(message) { }
    }
}
