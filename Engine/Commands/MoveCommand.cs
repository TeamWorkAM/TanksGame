using Tanks.Engine.EntityProp;
using System;
using Tanks.Engine.Tanks.Engine;

namespace Tanks.Engine.Commands
{
    public class MoveCommand:Command
    {
        Movable Entity;

        public MoveCommand(Movable movable)
        {
            Entity = movable;
        }
        public void Action()
        {
            if (Entity != null)
            {
                Entity.Position = Entity.Position + Entity.Velocity;
            }
            else
                throw new CommandException();
        }
    }
}

