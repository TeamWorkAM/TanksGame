using Tanks.Engine.EntityProp;

namespace Tanks.Engine.Commands
{
    public class MoveCommand:Command
    {
        Movable Entity;

        public MoveCommand(Movable movable)
        {
            if (movable != null)
            {
                Entity = movable;
            }
            else
                throw new CommandException("Объект не загружен");
        }
        public void Action()
        {
            try
            {
                Entity.Position = Entity.Position + Entity.Velocity;
            }
            catch(ReadObjectException)
            {
                throw new CommandException("Комaнда не выполнена: не удалось получить данные");
            }
            catch(WriteObjectException)
            {
                throw new CommandException("Команда не выполнена: не удалось записать данные");
            
        }
    }
}

