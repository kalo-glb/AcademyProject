using System;
using King;

namespace KingSurvivalGame
{
    class KingSurvivalGame : BaseGame
    {
        #region Part for refactoring. Author: Georgi Georgiev
        static bool check(int[] positionCoodinates)
        {
            int a = positionCoodinates[0];
            bool flag = (a >= ygliNaDyskata[0, 0]) && (a <= ygliNaDyskata[3, 0]);
            int b = positionCoodinates[1];
            bool flag2 = (b >= ygliNaDyskata[0, 1]) && (b <= ygliNaDyskata[3, 1]);
            return flag && flag2;
        }

        static void PokajiDyskata()
        {
            //tova printira prazen red na konzolata
            Console.WriteLine();
            //tuka kato cqlo si pravq nekvi shareniiki
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
                                //i neka byde zelenina
                                Console.BackgroundColor = ConsoleColor.Green;
                                //tva go prai cherno
                                Console.ForegroundColor = ConsoleColor.Black;
                                //i stignaxme nai posle do printiraneto na elementa
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

        static void START(int moveCounter)
        {
            if (gameIsOver)
            { //igrata svyrshi
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (moveCounter % 2 == 0)
                {
                    PokajiDyskata();
                    ProcessKingSide();
                }
                else
                {
                    PokajiDyskata();
                    ProcessPawnSide();
                }
            }
        }

        static bool proverka2(string checkedString)
        {
            if (kingsMovesCounter % 2 == 0)
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
                    //    break;
                }
            }
            return true;
        }
        #endregion

        #region Part for refactoring. Author: vlado
        internal static bool proverkaIProcess(string command)
        {
            bool isCommandValid = proverka2(command);
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
            pawnNewPosition = CheckNextPawnPosition(pawnOldPosition, 'R', 'D');

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
            pawnNewPosition = CheckNextPawnPosition(pawnOldPosition, 'L', 'D');

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
            pawnNewPosition = CheckNextPawnPosition(pawnOldPosition, 'R', 'C');

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
            pawnNewPosition = CheckNextPawnPosition(pawnOldPosition, 'L', 'C');

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
            pawnNewPosition = CheckNextPawnPosition(pawnOldPosition, 'R', 'B');

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
            pawnNewPosition = CheckNextPawnPosition(pawnOldPosition, 'L', 'B');

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
            pawnNewPosition = CheckNextPawnPosition(pawnOldPosition, 'R', 'A');

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
            pawnNextPosition = CheckNextPawnPosition(pawnOldPosition, 'L', 'A');

            if (pawnNextPosition != null)
            {
                pawnsPositions[0, 0] = pawnNextPosition[0];
                pawnsPositions[0, 1] = pawnNextPosition[1];
            }
        }
        #endregion

        #region Part for refactoring. Author: Kaloqn
        static void checkForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", kingsMovesCounter / 2);
                gameIsOver = true;
            }
        }

        static int[] CheckNextPawnPosition(int[] currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = field[currentCoordinates[0], currentCoordinates[1]];
                    field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                    field[newCoords[0], newCoords[1]] = sign;
                    kingsMovesCounter++;
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
                            Console.WriteLine("ERROR!");
                            break;
                    }

                    return newCoords;
                }
                else
                {
                    /* switch (currentPawn)
                    {
                    case 'A':
                    pawnExistingMoves[0, 0] = false;
                    break;
                    case 'B':
                    pawnExistingMoves[1, 0] = false;
                    break;
                    case 'C':
                    pawnExistingMoves[2, 0] = false;
                    break;
                    case 'D':
                    pawnExistingMoves[3, 0] = false;
                    break;
                    default:
                    Console.WriteLine("ERROR!");
                    break;
                    }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[0,i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'B':
                            pawnExistingMoves[1, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[1, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'C':
                            pawnExistingMoves[2, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[2, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'D':
                            pawnExistingMoves[3, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[3, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        default:
                            Console.WriteLine("ERROR!");
                            break;
                    }
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
                    if (allAreFalse)
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
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = field[currentCoordinates[0], currentCoordinates[1]];
                    field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                    field[newCoords[0], newCoords[1]] = sign;
                    kingsMovesCounter++;
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
                            Console.WriteLine("ERROR!");
                            break;
                    }
                    return newCoords;
                }
                else
                {
                    /*   switch (currentPawn)
                    {
                    case 'A':
                    pawnExistingMoves[0, 1] = false;
                    break;
                    case 'B':
                    pawnExistingMoves[1, 1] = false;
                    break;
                    case 'C':
                    pawnExistingMoves[2, 1] = false;
                    break;
                    case 'D':
                    pawnExistingMoves[3, 1] = false;
                    break;
                    default:
                    Console.WriteLine("ERROR!");
                    break;
                    }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[0, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'B':
                            pawnExistingMoves[1, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[1, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'C':
                            pawnExistingMoves[2, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[2, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'D':
                            pawnExistingMoves[3, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[3, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        default:
                            Console.WriteLine("ERROR!");
                            break;
                    }

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

                    if (allAreFalse)
                    {
                        gameIsOver = true;
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
            START(kingsMovesCounter);
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
            START(kingsMovesCounter);
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
                        kingsMovesCounter++;
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
                        kingsMovesCounter++;
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
                        kingsMovesCounter++;
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
                        kingsMovesCounter++;
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
            START(kingsMovesCounter);
            Console.WriteLine("\nThank you for using this game!\n\n");
        }
    }
}
