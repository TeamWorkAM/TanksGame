using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tanks.Engine.EntityProp;
using Tanks.Engine.Commands;
using System;

class ReadObjectException : Exception
{
    public ReadObjectException() : base("Ошибка чтения данных объекта") { }
}
class WriteObjectException : Exception
{
    public WriteObjectException() : base("Ошибка записи данных в объект") { }
}

namespace TanksUnitTest
{
    [TestClass]
    public class TestingGameEngine
    {
        [TestMethod]
        public void test_TankShouldRotateWithSomeVelocity()
        {
            var tank = new Mock<Rotatable>();
            tank.Setup(a => a.Angle).Returns(2).Verifiable();
            tank.Setup(a => a.Velocity).Returns(5).Verifiable();
            tank.SetupSet(a => a.Angle = 7).Verifiable();

            Rotate cmd = new Rotate(tank.Object);
            cmd.Action();

            tank.Verify();
        }
        [TestMethod]
        public void test_Tank_DIDN_T_ShouldRotateWithSomeVelocity()
        {
            var tank = new Mock<Rotatable>();
            tank.Setup(a => a.Angle).Returns(3).Verifiable();
            tank.Setup(a => a.Velocity).Returns(5).Verifiable();
            tank.SetupSet(a => a.Angle = 7).Throws<ArgumentException>();

            Rotate cmd = new Rotate(tank.Object);
            cmd.Action();

            tank.Verify();
        }

        /*не понятно*/
        [TestMethod]
        public void test_Tank_Couldnt_write_data()
        {
            var tank = new Mock<Rotatable>();
            tank.Setup(a => a.Angle).Returns(3).Verifiable();
            tank.Setup(a => a.Velocity).Returns(5).Verifiable();
            tank.SetupSet(a => a.Angle = ).Throws<WriteObjectException>().;

            Rotate cmd = new Rotate(tank.Object);
            cmd.Action();

            tank.Verify();
        }
    }
}
