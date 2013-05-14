using System;
using King;

namespace KingSurvivalGame
{
    class KingSurvivalGame : BaseGame
    {
        #region Part for refactoring. Author: Georgi Georgiev
        /// <summary>
        /// check position coordinates
        /// </summary>
        /// <param name="positionCoordinates"></param>
        static bool check(int[] positionCoordinates)
        {
            int a = positionCoordinates[0];
            bool flag = (a >= gameEdges[0, 0]) && (a <= gameEdges[3, 0]);
            int b = positionCoordinates[1];
            bool flag2 = (b >= gameEdges[0, 1]) && (b <= gameEdges[3, 1]);
            return flag && flag2;
        }

        //Write Game Field in Console and change
        //Background and Foreground colors of Game Field
        static void GetField()
        {
            Console.WriteLine();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = check(coordinates);
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
        /// start game
        /// </summary>
        /// <param name="moveCounter"></param>
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

        static bool CheckCommands(string checkedString)
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
            return true;
        }
        #endregion

        #region Part for refactoring. Author: vlado
        internal static bool proverkaIProcess(string command)
        {
            bool isCommandValid = CheckCommands(command);
            if (isCommandValid)
            {
                char figureLetter = command[0];
                char verticalDirection = command[1];
                char horizontalDirection = command[2];
                switch (figureLetter)
                {
                    case 'A':
                        {
                            if (horizontalDirection == 'L')
                            {
                                MovePawnALeft();
                            }
                            else
                            {
                                MovePawnARight();
                            }

                            break;
                        }
                    case 'B':
                        {
                            if (horizontalDirection == 'L')
                            {
                                MovePawnBLeft();
                            }
                            else
                            {
                                MovePawnBRight();
                            }

                            break;
                        }
                    case 'C':
                        {
                            if (horizontalDirection == 'L')
                            {
                                MovePawnCLeft();
                            }
                            else
                            {
                                MovePawnCRight();
                            }

                            break;
                        }
                    case 'D':
                        {
                            if (horizontalDirection == 'L')
                            {
                                MovePawnDLeft();
                            }
                            else
                            {
                                MovePawnDRight();
                            }

                            break;
                        }
                    case 'K':
                        if (verticalDirection == 'U')
                        {
                            if (horizontalDirection == 'L')
                            {
                                MoveKingUpperLeft();
                            }
                            else
                            {
                                MoveKingUpperRight();
                            }
                        }
                        else
                        {
                            if (horizontalDirection == 'L')
                            {
                                MoveKingDownLeft();
                            }
                            else
                            {
                                MoveKingDownRight();
                            }
                        }

                        break;
                    default:
                        throw new FormatException("The format of the command is not correct!");
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private static void MoveKingDownRight()
        {
            int[] kingOldPosition = new int[2];
            kingOldPosition[0] = kingPosition[0];
            kingOldPosition[1] = kingPosition[1];

            int[] kingNewPosition = new int[2];
            kingNewPosition = CheckNextKingPosition(kingOldPosition, 'D', 'R');

            if (kingNewPosition != null)
            {
                kingPosition[0] = kingNewPosition[0];
                kingPosition[1] = kingNewPosition[1];
            }
        }

        private static void MoveKingDownLeft()
        {
            int[] kingOldPosition = new int[2];
            kingOldPosition[0] = kingPosition[0];
            kingOldPosition[1] = kingPosition[1];

            int[] kingNewPosition = new int[2];
            kingNewPosition = CheckNextKingPosition(kingOldPosition, 'D', 'L');

            if (kingNewPosition != null)
            {
                kingPosition[0] = kingNewPosition[0];
                kingPosition[1] = kingNewPosition[1];
            }
        }

        private static void MoveKingUpperRight()
        {
            int[] kingOldPosition = new int[2];
            kingOldPosition[0] = kingPosition[0];
            kingOldPosition[1] = kingPosition[1];

            int[] kingNewPosition = new int[2];
            kingNewPosition = CheckNextKingPosition(kingOldPosition, 'U', 'R');

            if (kingNewPosition != null)
            {
                kingPosition[0] = kingNewPosition[0];
                kingPosition[1] = kingNewPosition[1];
            }
        }

        private static void MoveKingUpperLeft()
        {
            int[] kingOldPosition = new int[2];
            kingOldPosition[0] = kingPosition[0];
            kingOldPosition[1] = kingPosition[1];

            int[] kingNewPosition = new int[2];
            kingNewPosition = CheckNextKingPosition(kingOldPosition, 'U', 'L');

            if (kingNewPosition != null)
            {
                kingPosition[0] = kingNewPosition[0];
                kingPosition[1] = kingNewPosition[1];
            }
        }

        private static void MovePawnDRight()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[3, 0];
            pawnOldPosition[1] = pawnsPositions[3, 1];

            int[] pawnNewPosition = new int[2];
            pawnNewPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'R', 'D');

            if (pawnNewPosition != null)
            {
                pawnsPositions[3, 0] = pawnNewPosition[0];
                pawnsPositions[3, 1] = pawnNewPosition[1];
            }
        }

        private static void MovePawnDLeft()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[3, 0];
            pawnOldPosition[1] = pawnsPositions[3, 1];

            int[] pawnNewPosition = new int[2];
            pawnNewPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'L', 'D');

            if (pawnNewPosition != null)
            {
                pawnsPositions[3, 0] = pawnNewPosition[0];
                pawnsPositions[3, 1] = pawnNewPosition[1];
            }
        }

        private static void MovePawnCRight()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[2, 0];
            pawnOldPosition[1] = pawnsPositions[2, 1];

            int[] pawnNewPosition = new int[2];
            pawnNewPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'R', 'C');

            if (pawnNewPosition != null)
            {
                pawnsPositions[1, 0] = pawnNewPosition[0];
                pawnsPositions[1, 1] = pawnNewPosition[1];
            }
        }

        private static void MovePawnCLeft()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[2, 0];
            pawnOldPosition[1] = pawnsPositions[2, 1];

            int[] pawnNewPosition = new int[2];
            pawnNewPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'L', 'C');

            if (pawnNewPosition != null)
            {
                pawnsPositions[2, 0] = pawnNewPosition[0];
                pawnsPositions[2, 1] = pawnNewPosition[1];
            }
        }

        private static void MovePawnBRight()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[1, 0];
            pawnOldPosition[1] = pawnsPositions[1, 1];

            int[] pawnNewPosition = new int[2];
            pawnNewPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'R', 'B');

            if (pawnNewPosition != null)
            {
                pawnsPositions[1, 0] = pawnNewPosition[0];
                pawnsPositions[1, 1] = pawnNewPosition[1];
            }
        }

        private static void MovePawnBLeft()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[1, 0];
            pawnOldPosition[1] = pawnsPositions[1, 1];

            int[] pawnNewPosition = new int[2];
            pawnNewPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'L', 'B');

            if (pawnNewPosition != null)
            {
                pawnsPositions[1, 0] = pawnNewPosition[0];
                pawnsPositions[1, 1] = pawnNewPosition[1];
            }
        }

        private static void MovePawnARight()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[0, 0];
            pawnOldPosition[1] = pawnsPositions[0, 1];

            int[] pawnNewPosition = new int[2];
            pawnNewPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'R', 'A');

            if (pawnNewPosition != null)
            {
                pawnsPositions[0, 0] = pawnNewPosition[0];
                pawnsPositions[0, 1] = pawnNewPosition[1];
            }
        }

        private static void MovePawnALeft()
        {
            int[] pawnOldPosition = new int[2];
            pawnOldPosition[0] = pawnsPositions[0, 0];
            pawnOldPosition[1] = pawnsPositions[0, 1];

            int[] pawnNextPosition = new int[2];
            pawnNextPosition = CheckNextPawnPositionAndMove(pawnOldPosition, 'L', 'A');

            if (pawnNextPosition != null)
            {
                pawnsPositions[0, 0] = pawnNextPosition[0];
                pawnsPositions[0, 1] = pawnNextPosition[1];
            }
        }
        #endregion

        #region Part for refactoring. Author: Kaloqn

        /// <summary>
        /// PROBABLY: check if the king can exit the field (at the top) from these coordinates
        /// </summary>
        /// <param name="coordinatesToCheck"></param>
        static void checkForKingExit(int coordinatesToCheck)
        {
            if (coordinatesToCheck == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", movesCounter / 2);
                gameIsOver = true;
            }
        }

        static int[] CheckNextPawnPositionAndMove(int[] currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];

            // if the direction is L - left
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    movesCounter++;
                    UpdateFigureSymbolOnTheField(currentCoordinates, newCoords);
                    UpdatePawnExistingMoves(currentPawn);

                    return newCoords;
                }
                else
                {
                    UpdatePawnExistingMoves(checkDirection, currentPawn);

                    if (CheckIfAllAreFalse())
                    {
                        Console.WriteLine("King wins!");
                        gameIsOver = true;
                        return null;
                    }

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You can't go in this direction! ");
                    Console.ResetColor();
                    return null;
                }
            }
            else  // if the direction is R - right
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    movesCounter++;
                    UpdateFigureSymbolOnTheField(currentCoordinates, newCoords);
                    UpdatePawnExistingMoves(currentPawn);

                    return newCoords;
                }
                else
                {
                    UpdatePawnExistingMoves(checkDirection, currentPawn);

                    if (CheckIfAllAreFalse())
                    {
                        Console.WriteLine("King wins!");
                        gameIsOver = true;
                        return null;
                    }

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You can't go in this direction! ");
                    Console.ResetColor();
                    return null;
                }
            }
        }

        private static void UpdatePawnExistingMoves(char checkDirection, char currentPawn)
        {
            int neighbourCellY;
            if (checkDirection == 'L')
            {
                neighbourCellY = 0;
            }
            else
            {
                neighbourCellY = 1;
            }

            switch (currentPawn)
            {
                case 'A':
                    pawnExistingMoves[0, neighbourCellY] = false;
                    break;
                case 'B':
                    pawnExistingMoves[1, neighbourCellY] = false;
                    break;
                case 'C':
                    pawnExistingMoves[2, neighbourCellY] = false;
                    break;
                case 'D':
                    pawnExistingMoves[3, neighbourCellY] = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Argumen must be one of: A, B, C or D");
                    break;
            }
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
        /// updates the moves that the pawn can take (usualy calle after moving tha pawn)
        /// </summary>
        /// <param name="currentPawn">the pawn to be updated</param>
        private static void UpdatePawnExistingMoves(char currentPawn)
        {
            switch (currentPawn)
            {
                case 'A':
                    pawnExistingMoves[0, 0] = true;
                    pawnExistingMoves[0, 1] = true;
                    break;
                case 'B':
                    pawnExistingMoves[1, 0] = true;
                    pawnExistingMoves[1, 1] = true;
                    break;
                case 'C':
                    pawnExistingMoves[2, 0] = true;
                    pawnExistingMoves[2, 1] = true;
                    break;
                case 'D':
                    pawnExistingMoves[3, 0] = true;
                    pawnExistingMoves[3, 1] = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Argumen must be one of ");
                    break;
            }
        }

        /// <summary>
        /// moves the game figures symbol (A, B, C, D or K) to its next position
        /// </summary>
        /// <param name="currentCoordinates">the coordinates the figure is currently on</param>
        /// <param name="newCoords">the new coordinates for the figure</param>
        private static void UpdateFigureSymbolOnTheField(int[] currentCoordinates, int[] newCoords)
        {
            char pawnSymbol = field[currentCoordinates[0], currentCoordinates[1]];
            field[currentCoordinates[0], currentCoordinates[1]] = ' ';
            field[newCoords[0], newCoords[1]] = pawnSymbol;
        }
        #endregion

        #region Part for refactoring. Author: ???
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
                    isExecuted = proverkaIProcess(input);
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
                    isExecuted = proverkaIProcess(input);
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
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
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
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
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
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
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
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        movesCounter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
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
