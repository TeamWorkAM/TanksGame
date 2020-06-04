using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tanks.Engine.Commands;
using Tanks.Engine.EntityProp;
using Tanks.Engine.Math;
using Tanks.Engine;

namespace TestingGameEngine
{
    [TestClass]
    public class TestingGameEngine
    {
        [TestMethod]
        public void TankShouldMove2D()
        {
            var tank = new Mock<Movable>();
            tank.Setup(a => a.Position).Returns(new Vector(new double[] { 2, 3 })).Verifiable();
            tank.Setup(a => a.Velocity).Returns(new Vector(new double[] { 0, 5 })).Verifiable();

            tank.SetupSet(a => a.Position = new Vector(new double[] { 2, 8 })).Verifiable();
            MoveCommand cmd = new MoveCommand(tank.Object);
            cmd.Action();
            tank.Verify();
        }
        [TestMethod]
        public void TestVectorClassAllGood()
        {
            var vector1 = new Mock<Vector>();
            vector1.Setup(a => a.Data).Returns(new double[] { 2, 4 }).Verifiable();
            var vector2 = new Mock<Vector>();
            vector2.Setup(a => a.Data).Returns(new double[] { 2, 5 }).Verifiable();

            var result = new Mock<Vector>();
            /*
            result = vector1 + vector2;
            result.SetupSet(a => a.Data = new double[] { 4, 9 }).Verifiable;
            */
        }
        [TestMethod]
        public void CantRead()
        {
            var tank = new Mock<Movable>();
            tank.Setup(a => a.Position).Throws<ReadObjectException>().Verifiable();
            tank.Setup(a => a.Velocity).Returns(new Vector(new double[] { 6, 5 })).Verifiable();

            MoveCommand cmd = new MoveCommand(tank.Object);
            cmd.Action();
        }
        [TestMethod]
        public void CantWrite()
        {
            var tank = new Mock<Movable>();
            tank.Setup(a => a.Position).Returns(new Vector(new double[] { 0, 5 })).Verifiable();
            tank.Setup(a => a.Velocity).Returns(new Vector(new double[] { 2, 5 })).Verifiable();
            tank.SetupSet(a => a.Position.Data = new double[] { 2, 10 }).Throws<WriteObjectException>().Verifiable();

            MoveCommand cmd = new MoveCommand(tank.Object);
            cmd.Action();
        }
    }
}

