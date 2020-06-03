using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tanks.Engine.Commands;
using Tanks.Engine.EntityProp;
using Tanks.Engine.Math;

namespace TestingGameEngine
{
    [TestClass]
    public class TestingGameEngine
    {
        [TestMethod]
        public void TankShouldMove2D()
        {
            var tank = new Mock<Movable>();
            tank.Setup(a => a.Position).Returns(new Vector (new double[]{ 2, 3 })).Verifiable();
            tank.Setup(a => a.Velocity).Returns(new Vector(new double[] { 0, 5 })).Verifiable();

            tank.SetupSet(a => a.Position =new Vector(new double[] { 2, 8 })).Verifiable();
            MoveCommand cmd = new MoveCommand(tank.Object);
            cmd.Action();
            tank.Verify();
        }
    }
}

