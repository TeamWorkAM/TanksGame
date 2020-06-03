using Tanks.Engine.EntityProp;

namespace Tanks.Engine.Commands
{
    public class RotateCommand : Command
    {
        Rotatable entity;

        public Rotate(Rotatable rotatable)
        {
            entity = rotatable;
        }

        public void Action()
        {
            try
            {
                if (entity != null)
                {
                    entity.Angle += entity.Velocity;
                }
                else throw new CommandException();
            }
            catch
            {
                
            }
        }
    }
}
