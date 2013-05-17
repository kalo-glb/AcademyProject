using System;

namespace KingSurvivalGame
{
    public class Engine
    {
        protected static char[,] field = 
        {
            { 'U', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'U', 'R' },
            { ' ', ' ', ' ', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', ' ', ' ', ' ' },
            { '0', ' ', '|', ' ', 'A', ' ', ' ', ' ', 'B', ' ', ' ', ' ', 'C', ' ', ' ', ' ', 'D', ' ', ' ', ' ', '|', ' ', '0' },
            { '1', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '1' },
            { '2', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2' },
            { '3', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '3' },
            { '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '4' },
            { '5', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '5' },
            { '6', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '6' },
            { '7', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '7' },
            { ' ', ' ', '|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|', ' ', ' ' },
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' },
        };

        protected static int[,] gameEdges = 
        {
            { 2, 4 }, { 2, 18 }, { 9, 4 }, { 9, 18 }
        };

        protected static int[] kingPosition = { 9, 10 };
        protected static int[,] pawnsPositions = 
        {
            { 2, 4 }, { 2, 8 }, { 2, 12 }, { 2, 16 }
        };

        protected static bool[] kingExistingMoves = { true, true, true, true };
        protected static bool[,] pawnExistingMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        protected static string[] validInputs = { "KUL", "KUR", "KDL", "KDR", "ADL", "ADR", "BDL", "BDR", "CDL", "CDR", "DDL", "DDR" };
        protected static int movesCounter = 0;
        protected static bool gameIsOver = false;

        /// <summary>
        /// Check coordinates
        /// </summary>
        /// <param name="positionCoordinates">Coordinates to check</param>
        /// <returns>Return a boolean value is coordinates valid</returns>
        protected static bool CheckCoordinates(int[] positionCoordinates)
        {
            int firstCoordinates = positionCoordinates[0];
            bool isFirstCoordinatesValid = (firstCoordinates >= gameEdges[0, 0]) &&
                (firstCoordinates <= gameEdges[3, 0]);

            int secondCoordinates = positionCoordinates[1];
            bool isSecondCoordinatesValid = (secondCoordinates >= gameEdges[0, 1]) &&
                (secondCoordinates <= gameEdges[3, 1]);

            bool result = isFirstCoordinatesValid && isSecondCoordinatesValid;
            return result;
        }

        /// <summary>
        /// Write Game Field in Console and change
        /// Background and Foreground colors of Game Field
        /// </summary>
        public static void GetField()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = King.CheckCoordinates(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(field[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(field[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(field[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(field[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(field[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 != 0)
                        {
                            Console.Write(field[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(field[row, col]);
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Start game
        /// </summary>
        /// <param name="moveCounter">Get count of moves</param>
        protected static void Start(int moveCounter)
        {
            if (gameIsOver)
            {
                Console.WriteLine("Game is finished!");
            }
            else
            {
                if (moveCounter % 2 == 0)
                {
                    GetField();
                    ProcessFigure('K');
                }
                else
                {
                    GetField();
                    ProcessFigure('P');
                }
            }
        }

        /// <summary>
        /// Check Commands Exist
        /// </summary>
        /// <param name="checkedString">String to check</param>
        /// <returns>Return a boolean value true if command exist</returns>
        /// <returns>Return a boolean value false if command do not exist</returns>
        static bool CheckCommandsExist(string checkedString)
        {
            bool isValid = false;
            for (int i = 0; i < validInputs.Length; i++)
            {
                string reference = validInputs[i];
                int result = checkedString.CompareTo(reference);
                if (result == 0)
                {
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command name!");
                Console.ResetColor();
            }

            return isValid;
        }

        /// <summary>
        /// Make a move with king or pawn by given command.
        /// </summary>
        /// <param name="command">The command that will be checked and executed.</param>
        /// <param name="isExecuted">If the move is made successfully return true, else false.</param>
        public static void ExecuteCommand(string command, out bool isExecuted)
        {
            // Make command in uppercase - for the tests
            command = command.ToUpper();

            bool isCommandExist = CheckCommandsExist(command);
            if (isCommandExist)
            {
                char figureLetter = command[0];
                char verticalDirection = command[1];
                char horizontalDirection = command[2];

                if (figureLetter == 'K')
                {
                    King.MoveKing(verticalDirection, horizontalDirection);
                }
                else
                {
                    Pawn.MovePawn(figureLetter, horizontalDirection);
                }

                isExecuted = true;
            }
            else
            {
                isExecuted = false;
                // throw new FormatException("The command was not in the right format.");
            }
        }

        /// <summary>
        /// Moves the game figures symbol (A, B, C, D or K) to its next position
        /// </summary>
        /// <param name="currentCoordinates">The coordinates the figure is currently on</param>
        /// <param name="newCoords">The new coordinates for the figure</param>
        protected static void UpdateFigureSymbolOnTheField(int[] currentCoordinates, int[] newCoords)
        {
            char pawnSymbol = field[currentCoordinates[0], currentCoordinates[1]];
            field[currentCoordinates[0], currentCoordinates[1]] = ' ';
            field[newCoords[0], newCoords[1]] = pawnSymbol;
        }

        static void ProcessFigure(char figureLetter)
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                if (figureLetter == 'K')
                {
                    Console.Write("Please enter king's turn: ");
                }
                else
                {
                    Console.Write("Please enter pawn's turn: ");
                }
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToUpper();
                    ExecuteCommand(input, out isExecuted);
                }
            }

            Start(movesCounter);
        }
    }
}
