using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Engine
{
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
}
