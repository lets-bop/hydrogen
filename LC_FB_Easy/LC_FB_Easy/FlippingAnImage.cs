using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
    class FlippingAnImage
    {
        public int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++) // rows
            {
                int j = 0;
                int k = A[0].Length - 1; // cols
                while (j <= k)
                {
                    if (A[i][j] == A[i][k])
                    {
                        // They are the same, so just invert their values
                        if (A[i][j] == 0)
                        {
                            A[i][j] = 1;
                            A[i][k] = 1;
                        }
                        else
                        {
                            A[i][j] = 0;
                            A[i][k] = 0;
                        }
                    }

                    j++; k--;
                }
            }

            return A;
        }
    }
}
