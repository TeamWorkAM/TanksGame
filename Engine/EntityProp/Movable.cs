using Tanks.Engine.Math;

namespace Tanks.Engine.EntityProp
{
    public interface Movable
    {
        Vector Position { get; set; }

        Vector Velocity { get; }
    }
}
