using System;

namespace KingSurvivalGame
{
    public class BaseGame
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

        protected static bool[,] pawnExistingMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        protected static string[] validKingInputs = { "KUL", "KUR", "KDL", "KDR" };
        protected static bool[] kingExistingMoves = { true, true, true, true };

        protected static string[] ValidPawnMovesForA = { "ADL", "ADR" };

        protected static string[] ValidPawnMovesForB = { "BDL", "BDR" };

        protected static string[] ValidPawnMovesForC = { "CDL", "CDR" };

        protected static string[] ValidPawnMovesForD = { "DDL", "DDR" };

        protected static int movesCounter = 0;

        protected static bool gameIsOver = false;
        protected static int[,] pawnsPositions = 
        {
            { 2, 4 }, { 2, 8 }, { 2, 12 }, { 2, 16 }
        };
    }
}
