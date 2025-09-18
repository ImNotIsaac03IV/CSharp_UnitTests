/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Solve DameProblem
* see: https://de.wikipedia.org/wiki/Damenproblem
*--------------------------------------------------------------
*/

namespace DameProblem
{
    public class Dame
    {
        public static bool IsValid(bool[,] field)
        {
            int size = 8;
            int queenCount = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col])
                    {
                        queenCount++;

                        for (int c = 0; c < size; c++)
                        {
                            if (c != col && field[row, c])
                                return false;
                        }

                        for (int r = 0; r < size; r++)
                        {
                            if (r != row && field[r, col])
                                return false;
                        }

                        int i = row - 1;
                        int j = col - 1;
                        while (i >= 0 && j >= 0)
                        {
                            if (field[i, j])
                                return false;
                            i--;
                            j--;
                        }

                        i = row + 1;
                        j = col + 1;
                        while (i < size && j < size)
                        {
                            if (field[i, j])
                                return false;
                            i++;
                            j++;
                        }

                        i = row - 1;
                        j = col + 1;
                        while (i >= 0 && j < size)
                        {
                            if (field[i, j])
                                return false;
                            i--;
                            j++;
                        }

                        i = row + 1;
                        j = col - 1;
                        while (i < size && j >= 0)
                        {
                            if (field[i, j])
                                return false;
                            i++;
                            j--;
                        }
                    }
                }
            }

            return queenCount == 8;
        }
    }

}