using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvivalGame;
using System.IO;

namespace KingSurvivalTest
{
    [TestClass]
    public class KingTest
    {
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
        public void ExecuteCommand_PawnAValidCommandButOutOfTheField_ProperOutput()
        {
            string expectedOutput = "You can't go in this direction! " + Environment.NewLine;
            TextWriter defaultOutput = Console.Out;

            // Skip king's move
            bool isExecuted;
            King.ExecuteCommand("kul", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("adl", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.AreEqual(expectedOutput, realOutput.ToString());
        }

        [TestMethod]
        public void ExecuteCommand_PawnAValidCommand_True()
        {
            TextWriter defaultOutput = Console.Out;

            // Skip king's move
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("adr", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.IsTrue(isExecuted);
        }

        [TestMethod]
        public void ExecuteCommand_PawnBValidCommand_True()
        {
            TextWriter defaultOutput = Console.Out;

            // Skip king's move
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("bdr", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.IsTrue(isExecuted);
        }

        [TestMethod]
        public void ExecuteCommand_PawnCValidCommand_True()
        {
            TextWriter defaultOutput = Console.Out;

            // Skip king's move
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("cdl", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.IsTrue(isExecuted);
        }

        [TestMethod]
        public void ExecuteCommand_PawnDValidCommand_True()
        {
            TextWriter defaultOutput = Console.Out;

            // Skip king's move
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("ddl", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.IsTrue(isExecuted);
        }

        [TestMethod]
        public void ExecuteCommand_KingMoveDownLeft_True()
        {
            TextWriter defaultOutput = Console.Out;

            // Skip first king's move
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            // Skip pawn's first move
            King.ExecuteCommand("adr", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("kdl", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.IsTrue(isExecuted);
        }

        [TestMethod]
        public void ExecuteCommand_KingMoveDownRight_True()
        {
            TextWriter defaultOutput = Console.Out;

            // Skip first king's move
            bool isExecuted;
            King.ExecuteCommand("kur", out isExecuted);

            // Skip pawn's first move
            King.ExecuteCommand("bdr", out isExecuted);

            StringWriter realOutput = new StringWriter();
            using (realOutput)
            {
                Console.SetOut(realOutput);
                King.ExecuteCommand("kdr", out isExecuted);
            }
            Console.SetOut(defaultOutput);

            Assert.IsTrue(isExecuted);
        }
    }
}
