using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Recreo;

namespace Recreo.UnitTests
{
    public class RoverTests
    {
        private Plateau _plateau;
        private Rover _rover1;
        private Rover _rover2;

        [SetUp]
        public void Setup()
        {
            _plateau = new Plateau(new List<int>() { 5, 5 });
            _rover1 = new Rover(new List<string>() { "1","2","N" }, _plateau);
            _rover2 = new Rover(new List<string>() { "3","3","E" }, _plateau);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Explore_InstructionStringIsNull_ThrowArgumentNullException(string instructionString)
        {
            Assert.That(() => _rover1.Explore(instructionString), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("123")]
        [TestCase("+%}")]
        [TestCase("BCD")]
        public void Explore_InvalidInstructions_ThrowInvalidEnumException(string instructionString)
        {
            Assert.That(() => _rover1.Explore(instructionString), Throws.Exception.TypeOf<InvalidEnumArgumentException>());
        }

        [Test]
        [TestCase("LMLMLMLMM")]
        public void Explore_ValidInstructionsRover1_ExpectedOutput(string instructionString)
        {
            _rover1.Explore(instructionString);
            Assert.That(_rover1.Point,Is.EqualTo(new Point(1,3)));
            Assert.That(_rover1.Orientation,Is.EqualTo(Orientation.N));
        }
        
        [Test]
        [TestCase("MMRMMRMRRM")]
        public void Explore_ValidInstructionsRover2_ExpectedOutput(string instructionString)
        {
            _rover2.Explore(instructionString);
            Assert.That(_rover2.Point, Is.EqualTo(new Point(5,1)));
            Assert.That(_rover2.Orientation, Is.EqualTo(Orientation.E));
        }
    }
}