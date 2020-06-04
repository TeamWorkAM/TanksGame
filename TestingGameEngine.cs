using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tanks.Engine;
using Tanks.Engine.EntityProp;
using Tanks.Engine.Commands;
using System;

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
        [TestMethod]
        public void test_Tank_Couldnt_read_angle()
        {
            var tank = new Mock<Rotatable>();
            tank.Setup(a => a.Angle).Throws<ReadObjectException>().Verifiable();
            tank.Setup(a => a.Velocity).Returns(5).Verifiable();

            Rotate cmd = new Rotate(tank.Object);
            cmd.Action();
        }
        [TestMethod]
        public void test_Tank_Couldnt_write_angle()
        {
            var tank = new Mock<Rotatable>();
            tank.Setup(a => a.Angle).Returns(3).Verifiable();
            tank.Setup(a => a.Velocity).Returns(5).Verifiable();
            tank.SetupSet(a => a.Angle = 8).Throws<WriteObjectException>().Verifiable();

            Rotate cmd = new Rotate(tank.Object);
            cmd.Action();
        }
    }
}
