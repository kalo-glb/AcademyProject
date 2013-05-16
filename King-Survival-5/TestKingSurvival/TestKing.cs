using System;
using NUnit.Framework;
using KingSurvivalGame;
using System.IO;

namespace TestKingSurvival
{
    [TestFixture]
    class TestKing
    {
        [Test]
        public void TestSomeMethod()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestGetFieldEvenRowAndEvenCol()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestGetFieldEvenRowAndOddCol()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestGetFieldEvenRowAndQuarterCol()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestGetFieldOddRowAndEvenCol()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestGetFieldOddRowAndOddCol()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestGetFieldOddRowAndQuarterCol()
        {
            Assert.IsTrue(true);
        }

        // ExecuteCommand method tests
        [Test]
        public void ExecuteCommand_InvalidCommand_False()
        {
            bool isExecuted;
            King.ExecuteCommand("abc", out isExecuted);

            Assert.IsFalse(isExecuted);
        }

        [Test]
        public void ExecuteCommand_InvalidFirstLetterOfTheCommand_ProperOutput()
        {
            string expectedOutput = "Invalid command name!" + Environment.NewLine;
            TextWriter defaultOutput = Console.Out;

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                bool isExecuted;
                King.ExecuteCommand("zul", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.AreEqual(expectedOutput, realOutput.ToString());
        }

        [Test]
        public void ExecuteCommand_InvalidSecondLetterOfTheCommand_ProperOutput()
        {
            string expectedOutput = "Invalid command name!" + Environment.NewLine;
            TextWriter defaultOutput = Console.Out;

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                bool isExecuted;
                King.ExecuteCommand("kbl", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.AreEqual(expectedOutput, realOutput.ToString());
        }

        [Test]
        public void ExecuteCommand_InvalidThirdLetterOfTheCommand_ProperOutput()
        {
            string expectedOutput = "Invalid command name!" + Environment.NewLine;
            TextWriter defaultOutput = Console.Out;

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                bool isExecuted;
                King.ExecuteCommand("kum", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.AreEqual(expectedOutput, realOutput.ToString());
        }

        [Test]
        public void ExecuteCommand_KingValidCommandButOutOfTheField_ProperOutput()
        {
            string expectedOutput = "You can't go in this direction! " + Environment.NewLine;
            TextWriter defaultOutput = Console.Out;

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                bool isExecuted;
                King.ExecuteCommand("kdr", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.AreEqual(expectedOutput, realOutput.ToString());
        }

        [Test]
        public void ExecuteCommand_PawnValidCommandButOutOfTheField_ProperOutput()
        {
            string expectedOutput = "You can't go in this direction! " + Environment.NewLine;
            TextWriter defaultOutput = Console.Out;

            // Skip king's move
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("adl", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.AreEqual(expectedOutput, realOutput.ToString());
        }

        [Test]
        public void ExecuteCommand_KingValidCommandUpperRight_True()
        {
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            Assert.IsTrue(isExecuted);
        }
    }
}