using System;

namespace KingSurvivalGame
{
    public class Pawn : Engine
    {
        public static void MovePawn(char pawnLetter, char horizontalDirection)
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
    }
}
