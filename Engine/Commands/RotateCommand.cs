using Tanks.Engine.EntityProp;

namespace Tanks.Engine.Commands
{
    public class Rotate : Command
    {
        Rotatable entity;

        public Rotate(Rotatable rotatable)
        {
            if (rotatable != null)
            {
                entity = rotatable;
            }
            else throw new CommandException("Объект не загружен");
        }

        public void Action()
        {
            try
            {
                entity.Angle += entity.Velocity;                             
            }
            catch(ReadObjectException)
            {
                throw new CommandException("Команада не выполнена: не удалось получить данные");
            }
            catch(WriteObjectException)
            {
                throw new CommandException("Команада не выполнена: не удалось записать данные");
            }
        }
    }
}
