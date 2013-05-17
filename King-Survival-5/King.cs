using System;

namespace KingSurvivalGame
{
    public class King : BaseGame
    {
        #region Part for refactoring. Author: Georgi Georgiev
        /// <summary>
        /// Check coordinates
        /// </summary>
        /// <param name="positionCoordinates">Coordinates to check</param>
        /// <returns>Return a boolean value is coordinates valid</returns>
        static bool CheckCoordinates(int[] positionCoordinates)
        {
            int firstCoordinates = positionCoordinates[0];
            bool isFirstCoordinatesValid = (firstCoordinates >= gameEdges[0, 0]) && (firstCoordinates <= gameEdges[3, 0]);
            int secondCoordinates = positionCoordinates[1];
            bool isSecondCoordinatesValid = (secondCoordinates >= gameEdges[0, 1]) && (secondCoordinates <= gameEdges[3, 1]);
            return isFirstCoordinatesValid && isSecondCoordinatesValid;
        }

        /// <summary>
        /// Write Game Field in Console and change
        /// Background and Foreground colors of Game Field
        /// </summary>
        static void GetField()
        {
            Console.WriteLine();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = CheckCoordinates(coordinates);
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
            Console.WriteLine();
        }

        /// <summary>
        /// Start game
        /// </summary>
        /// <param name="moveCounter">Get count of moves</param>
        static void Start(int moveCounter)
        {
            if (gameIsOver)
            {
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (moveCounter % 2 == 0)
                {
                    GetField();
                    ProcessKingSide();
                }
                else
                {
                    GetField();
                    ProcessPawnSide();
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
            if (movesCounter % 2 == 0)
            {
                int[] flag = new int[4];
                for (int i = 0; i < validKingInputs.Length; i++)
                {
                    string reference = validKingInputs[i];
                    int result = checkedString.CompareTo(reference);
                    if (result != 0)
                    {
                        flag[i] = 0;
                    }
                    else
                    {
                        flag[i] = 1;
                    }
                }
                bool hasAnEqual = false;
                for (int i = 0; i < 4; i++)
                {
                    if (flag[i] == 1)
                    {
                        hasAnEqual = true;
                    }
                }
                if (!hasAnEqual)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command name!");
                    Console.ResetColor();
                }
                return hasAnEqual;
            }
            else
            {
                char startLetter = checkedString[0];
                int[] checker = new int[2];
                bool hasAnEqual = false;
                switch (startLetter)
                {
                    case 'A':
                        for (int i = 0; i < ValidPawnMovesForA.Length; i++)
                        {
                            string reference = ValidPawnMovesForA[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (checker[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;

                    case 'B':
                        for (int i = 0; i < ValidPawnMovesForB.Length; i++)
                        {
                            string reference = ValidPawnMovesForB[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (checker[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;
                    case 'C':
                        for (int i = 0; i < ValidPawnMovesForC.Length; i++)
                        {
                            string reference = ValidPawnMovesForC[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (checker[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;

                    case 'D':
                        for (int i = 0; i < ValidPawnMovesForD.Length; i++)
                        {
                            string reference = ValidPawnMovesForD[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (checker[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command name!");
                        Console.ResetColor();
                        return false;
                }
            }
        }
        #endregion

        #region Part for refactoring. Author: vlado
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
                    MoveKing(verticalDirection, horizontalDirection);
                }
                else
                {
                    MovePawn(figureLetter, horizontalDirection);
                }

                isExecuted = true;
            }
            else
            {
                isExecuted = false;
                // throw new FormatException("The command was not in the right format.");
            }
        }

        private static void MoveKing(char verticalDirection, char horizontalDirection)
        {
            int[] kingOldPosition = new int[2];
            kingOldPosition[0] = kingPosition[0];
            kingOldPosition[1] = kingPosition[1];

            int[] kingNewPosition = new int[2];
            kingNewPosition = CheckNextKingPosition(
                kingOldPosition, verticalDirection, horizontalDirection);

            // If there are next valid position - move the king there
            if (kingNewPosition != null)
            {
                kingPosition[0] = kingNewPosition[0];
                kingPosition[1] = kingNewPosition[1];
            }
        }

        private static void MovePawn(char pawnLetter, char horizontalDirection)
        {
            // 0 - A; 1 - B, 2 - C, 3 - D
            int pawnPosition = pawnLetter - 'A';

            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[pawnPosition, 0];
            pawnOldPosition[1] = pawnsPositions[pawnPosition, 1];

            int[] pawnNewPosition;
            bool isThereNextPawnPosition = CheckNextPawnPosition(
                pawnOldPosition, horizontalDirection,
                pawnLetter, out pawnNewPosition);

            // If there are next valid position - move the pawn there
            if (isThereNextPawnPosition)
            {
                pawnsPositions[pawnPosition, 0] = pawnNewPosition[0];
                pawnsPositions[pawnPosition, 1] = pawnNewPosition[1];
            }
        }
        #endregion

        #region Part for refactoring. Author: Kaloqn
        /// <summary>
        /// Check if the king can exit the field (at the top) from these coordinates
        /// </summary>
        /// <param name="coordinatesToCheck">The coordinate to check from.</param>
        private static void CheckForKingExit(int coordinatesToCheck)
        {
            if (coordinatesToCheck == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", movesCounter / 2);
                gameIsOver = true;
            }
        }

        /// <summary>
        /// Check if there are any new position for the given pawn.
        /// </summary>
        /// <param name="currentCoordinates">The coordinates that the pawn is at that moment.</param>
        /// <param name="checkDirection">The direction given from the command.</param>
        /// <param name="currentPawn">Pawn letter.</param>
        /// <param name="newCoords">If there are new position, the new coordinates are returned.</param>
        private static bool CheckNextPawnPosition(
            int[] currentCoordinates, char checkDirection,
            char currentPawn, out int[] newCoords)
        {
            newCoords = new int[2];
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };

            // if the direction is L - left
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
            }
            else  // if the direction is R - right
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                
            }

            if (CheckCoordinates(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
            {
                movesCounter++;
                UpdateFigureSymbolOnTheField(currentCoordinates, newCoords);
                UpdatePawnExistingMoves(currentPawn);

                return true;
            }
            else
            {
                UpdatePawnExistingMoves(checkDirection, currentPawn);

                if (CheckIfAllAreFalse())
                {
                    Console.WriteLine("King wins!");
                    gameIsOver = true;
                    return false;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return false;
            }
        }

        /// <summary>
        /// Updates the moves that the pawn can take (usualy calle after moving tha pawn)
        /// </summary>
        /// <param name="currentPawn">The pawn to be updated</param>
        private static void UpdatePawnExistingMoves(char currentPawn)
        {
            int pawnNumber = currentPawn - 'A';
            pawnExistingMoves[pawnNumber, 0] = true;
            pawnExistingMoves[pawnNumber, 1] = true;
        }

        private static void UpdatePawnExistingMoves(char checkDirection, char currentPawn)
        {
            int pawnAvailableCell;
            if (checkDirection == 'L')
            {
                pawnAvailableCell = 0;
            }
            else
            {
                pawnAvailableCell = 1;
            }

            int pawnNumber = currentPawn - 'A';
            pawnExistingMoves[pawnNumber, pawnAvailableCell] = false;
        }

        private static bool CheckIfAllAreFalse()
        {
            bool allAreFalse = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (pawnExistingMoves[i, j] == true)
                    {
                        allAreFalse = false;
                    }
                }
            }

            return allAreFalse;
        }

        /// <summary>
        /// Moves the game figures symbol (A, B, C, D or K) to its next position
        /// </summary>
        /// <param name="currentCoordinates">The coordinates the figure is currently on</param>
        /// <param name="newCoords">The new coordinates for the figure</param>
        private static void UpdateFigureSymbolOnTheField(int[] currentCoordinates, int[] newCoords)
        {
            char pawnSymbol = field[currentCoordinates[0], currentCoordinates[1]];
            field[currentCoordinates[0], currentCoordinates[1]] = ' ';
            field[newCoords[0], newCoords[1]] = pawnSymbol;
        }
        #endregion

        #region Part for refactoring. Author: tsetso
        static void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToUpper();//! input =
                    ExecuteCommand(input, out isExecuted);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }
            Start(movesCounter);
        }

        static void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                //input = input.Trim();
                if (input != null)//"/n")
                {
                    // Console.WriteLine(input);
                    //Console.WriteLine("hahah");
                    input = input.ToUpper();//! input =
                    ExecuteCommand(input, out isExecuted);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }
            Start(movesCounter);
        }

        static int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] displasmentUpLeft = { -1, -2 };
            int[] displasmentUpRight = { -1, 2 };
            int[] newCoords = new int[2];

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpLeft[1];
                    if (CheckCoordinates(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[0] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsOver = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];
                    if (CheckCoordinates(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[1] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsOver = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
                        return null;
                    }
                }
            }
            else
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                    if (CheckCoordinates(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[2] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsOver = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                    if (CheckCoordinates(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[3] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsOver = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
                        return null;
                    }
                }
                // checkForKingExit();
            }
        }
        #endregion

        static void Main()
        {
            Start(movesCounter);
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}
