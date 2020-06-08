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
            Vector vec1 = new Vector(new double[] { 5, 34 });
            Vector vec2 = new Vector(new double[] { 15, 5 });

            Vector result = new Vector(new double[] { 0, 0 });
            result = vec1 + vec2;

            Assert.AreEqual(20, result.Data[0]);
            Assert.AreEqual(39, result.Data[1]);
        }
        [TestMethod]
        public void TestVectorClassBad()
        {
            Vector vec1 = new Vector(new double[] { 5, 34 });
            Vector vec2 = new Vector(new double[] { 15, 5, 6 });

            Vector result = new Vector(new double[] { 0, 0 });
            result = vec1 + vec2;

            Assert.AreEqual(20, result.Data[0]);
            Assert.AreEqual(39, result.Data[1]);
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

