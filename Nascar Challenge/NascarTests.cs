using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nascar_Challenge
{
    [TestClass]
    public class NascarTests
    {
        [TestMethod]
        public void ShiftUpAndDown_ShouldSetGear()
        {
            Car car = new Car();
            car.TurnOn(); // N
            car.ShiftUp(); // 1st
            car.ShiftUp(); // 2nd
            car.ShiftUp(); // 3rd
            car.ShiftUp(); // 4th
            Assert.AreEqual(Gear.Fourth, car.Gear);
            car.ShiftDown(); // 3rd
            car.ShiftDown(); // 2nd
            car.ShiftDown(); // 1st
            car.ShiftDown(); // N
            car.ShiftDown(); // Park
            Assert.AreEqual(Gear.P, car.Gear);
        }

        [TestMethod]
        public void Drive_ShouldUseFuelAndCauseWear()
        {
            Car car = new Car();
            car.Refuel(12); // Top off
            car.TurnOn();
            car.ShiftUp();
            car.ShiftUp();
            car.Drive(100);
            Assert.AreEqual(13.5, car.Fuel);
            Assert.AreEqual(Wear.Ok, car.FrontDriverTire.Wear);

        }

        [TestMethod]
        public void PitStop_ShouldRefuelAndReplaceTires()
        {
            Car car = new Car();
            car.TurnOn();
            car.ShiftUp();
            car.ShiftUp();
            car.ShiftUp();
            car.ShiftUp();
            car.Drive(100);
            Assert.AreEqual(100, car.FrontDriverTire.Miles); // Making sure miles are being added
            Assert.AreEqual(100, car.FrontPassengerTire.Miles);
            Assert.AreEqual(100, car.RearDriverTire.Miles);
            Assert.AreEqual(100, car.RearPassengerTire.Miles);
            car.PitStop(new Tire(), new Tire(), new Tire(), new Tire(), 22);
            Assert.AreEqual(0, car.FrontDriverTire.Miles);
            Assert.AreEqual(0, car.FrontPassengerTire.Miles);
            Assert.AreEqual(0, car.RearDriverTire.Miles);
            Assert.AreEqual(0, car.RearPassengerTire.Miles);
            Assert.AreEqual(22, car.Fuel);
        }
        [TestMethod]
        public void Racing_ShouldSeemLikeARace()
        {
            Car car = new Car(19,"Toyota","Camry");
            car.TurnOn();
            car.Vroom();
            car.ShiftUp();
            car.Drive(0.25);
            car.ShiftUp();
            car.Drive(0.3);
            car.ShiftUp();
            car.Drive(0.5);
            car.ShiftUp();
            car.Drive(0.3);
            car.ShiftUp();
            car.Drive(30);
            car.Diagnostic();
        }
    }
}
