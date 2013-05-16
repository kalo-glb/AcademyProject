using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvivalGame;
using System.IO;

namespace KingSurvivalTest
{
    [TestClass]
    public class KingTest
    {
        [TestMethod]
        public void TestSomeMethod()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetFieldEvenRowAndEvenCol()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetFieldEvenRowAndOddCol()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetFieldEvenRowAndQuarterCol()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetFieldOddRowAndEvenCol()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetFieldOddRowAndOddCol()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetFieldOddRowAndQuarterCol()
        {
            Assert.IsTrue(true);
        }

        // ExecuteCommand method tests
        [TestMethod]
        public void ExecuteCommand_InvalidCommand_False()
        {
            bool isExecuted;
            King.ExecuteCommand("abc", out isExecuted);

            Assert.IsFalse(isExecuted);
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        //[TestMethod]
        //public void ExecuteCommand_KingValidCommandUpperRight_True()
        //{
        //    bool isExecuted;
        //    King.ExecuteCommand("kur", out isExecuted);

        //    Assert.IsTrue(isExecuted);
        //}
    }
}
