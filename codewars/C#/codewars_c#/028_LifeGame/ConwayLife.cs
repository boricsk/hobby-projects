using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028_LifeGame
{
    public class ConwayLife
    {
        public static int[][] GetGeneration(int[][] cells, int generations)
        {
            var current = cells;

            for (int gen = 0; gen < generations; gen++)
            {
                current = NextGeneration(current);
            }

            return Crop(current);
        }

        private static int[][] NextGeneration(int[][] cells)
        {
            int rows = cells.Length;
            int cols = cells[0].Length;

            // Kiterjesztjük a mátrixot körbe eggyel (padding), hogy az új élő sejteket is kezelni tudjuk
            int[][] extended = new int[rows + 2][];
            for (int i = 0; i < rows + 2; i++)
                extended[i] = new int[cols + 2];

            // Másoljuk az eredeti cellákat középre
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    extended[i + 1][j + 1] = cells[i][j];

            // Létrehozunk egy új generációs mátrixot
            int[][] nextGen = new int[rows + 2][];
            for (int i = 0; i < rows + 2; i++)
                nextGen[i] = new int[cols + 2];

            // Conway szabályok alkalmazása
            for (int i = 1; i < rows + 1; i++)
            {
                for (int j = 1; j < cols + 1; j++)
                {
                    int aliveNeighbors = CountAliveNeighbors(extended, i, j);

                    if (extended[i][j] == 1)
                    {
                        // Élő sejt túlél, ha 2 vagy 3 szomszédja van
                        nextGen[i][j] = (aliveNeighbors == 2 || aliveNeighbors == 3) ? 1 : 0;
                    }
                    else
                    {
                        // Halott sejt újraéled, ha pontosan 3 szomszédja van
                        nextGen[i][j] = (aliveNeighbors == 3) ? 1 : 0;
                    }
                }
            }

            return nextGen;
        }

        // Segédfüggvény a szomszédok számlálására
        private static int CountAliveNeighbors(int[][] grid, int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if ((i != x || j != y) && grid[i][j] == 1)
                        count++;
            return count;
        }

        // Körülvágja a mátrixot, hogy csak az élő cellák maradjanak
        private static int[][] Crop(int[][] cells)
        {
            int minRow = int.MaxValue, maxRow = int.MinValue;
            int minCol = int.MaxValue, maxCol = int.MinValue;

            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    if (cells[i][j] == 1)
                    {
                        minRow = Math.Min(minRow, i);
                        maxRow = Math.Max(maxRow, i);
                        minCol = Math.Min(minCol, j);
                        maxCol = Math.Max(maxCol, j);
                    }
                }
            }

            // Ha nincs élő sejt, térjünk vissza üres mátrixszal
            if (minRow == int.MaxValue)
                return new int[][] { new int[0] };

            // Körülvágott mátrix létrehozása
            int[][] cropped = new int[maxRow - minRow + 1][];
            for (int i = minRow; i <= maxRow; i++)
            {
                cropped[i - minRow] = new int[maxCol - minCol + 1];
                for (int j = minCol; j <= maxCol; j++)
                {
                    cropped[i - minRow][j - minCol] = cells[i][j];
                }
            }

            return cropped;
        }

        // Debug célra: Szép szöveges kirajzolás
        public static string Htmlize(int[][] cells)
        {
            return string.Join("\n", cells.Select(row =>
                string.Concat(row.Select(cell => cell == 1 ? "▓▓" : "░░"))
            ));
        }

        public static int[][] ToJaggedArray(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[][] jagged = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jagged[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    jagged[i][j] = matrix[i, j];
                }
            }
            return jagged;
        }
    }
}
