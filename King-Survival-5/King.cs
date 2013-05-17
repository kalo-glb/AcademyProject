using System;

namespace KingSurvivalGame
{
    public class King : Engine
    {
        /// <summary>
        /// Move the king into the given position
        /// </summary>
        /// <param name="verticalDirection">Vertical position</param>
        /// <param name="horizontalDirection">Horizontal position</param>
        public static void MoveKing(char verticalDirection, char horizontalDirection)
        {
            int[] kingOldPosition = new int[2];
            kingOldPosition[0] = kingPosition[0];
            kingOldPosition[1] = kingPosition[1];

            int[] kingNewPosition;
            bool isThereNextKingPosition = CheckNextKingPosition(
                kingOldPosition, verticalDirection,
                horizontalDirection, out kingNewPosition);

            // If there are next valid position - move the king there
            if (isThereNextKingPosition)
            {
                kingPosition[0] = kingNewPosition[0];
                kingPosition[1] = kingNewPosition[1];
            }
        }

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

        private static bool CheckNextKingPosition(
            int[] currentCoordinates, char firstDirection,
            char secondDirection, out int[] newCoords)
        {
            newCoords = new int[2];
            int[,] displasments = new int[,] { { -1, -2 }, { -1, 2 }, { 1, -2 }, { 1, 2 } };

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    return MakeKingTurn(0, newCoords, displasments, currentCoordinates);
                }
                else
                {
                    return MakeKingTurn(1, newCoords, displasments, currentCoordinates);
                }
            }
            else
            {
                if (secondDirection == 'L')
                {
                    return MakeKingTurn(2, newCoords, displasments, currentCoordinates);
                }
                else
                {
                    return MakeKingTurn(3, newCoords, displasments, currentCoordinates);
                }
            }
        }

        private static bool MakeKingTurn(int displasmentIndex, int[] newCoords,
            int[,] displasments, int[] currentCoordinates)
        {
            newCoords[0] = currentCoordinates[0] + displasments[displasmentIndex, 0];
            newCoords[1] = currentCoordinates[1] + displasments[displasmentIndex, 1];
            if (CheckCoordinates(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
            {
                char sign = field[currentCoordinates[0], currentCoordinates[1]];
                field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                field[newCoords[0], newCoords[1]] = sign;
                movesCounter++;
                for (int i = 0; i < kingExistingMoves.Length; i++)
                {
                    kingExistingMoves[i] = true;
                }

                CheckForKingExit(newCoords[0]);
                return true;
            }
            else
            {
                kingExistingMoves[displasmentIndex] = false;
                bool allAreFalse = true;
                for (int i = 0; i < kingExistingMoves.Length; i++)
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
                    return false;
                }

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You can't go in this direction! ");
                Console.ResetColor();
                return false;
            }
        }
    }
}
