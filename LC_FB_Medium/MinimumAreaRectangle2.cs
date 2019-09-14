using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class MinimumAreaRectangele2
    {
        public double MinArea2(int[][] points) {
            double result = double.MaxValue;
            Dictionary<string, List<int[]>> diags = new Dictionary<string, List<int[]>>();
            // The 2 diagonals of a rectangle are of the same length
            // We use dictionary where the key is the length of the diagonal and the coordinates of the its center
            // and its value are the indices of the points
            // by Pythagorean theorem, if the 2 sides of a rectangle are a & b, the diagonal c^2 = a^2 + b^2
            // diagCenterX = (double)(points[j][0] + points[i][0])/2;
            // diagCenterY = (double)(points[j][1] + points[i][1])/2;

            for (int i = 0; i < points.Length; i++) {
                for (int j = i + 1; j < points.Length; j++) {
                    long diagonal = (points[i][0] - points[j][0]) * (points[i][0] - points[j][0]) + 
                                    (points[i][1] - points[j][1]) * (points[i][1] - points[j][1]);
                    double diagCenterX = (double)(points[j][0] + points[i][0])/2;
                    double diagCenterY = (double)(points[j][1] + points[i][1])/2;
                    string key = diagonal.ToString() + "+" + diagCenterX.ToString() + "+" + diagCenterY.ToString();
                    if (!diags.ContainsKey(key)) diags[key] = new List<int[]>();
                    diags[key].Add(new int[] {i, j});
                }
            }

            foreach (var kv in diags) {
                if (diags[kv.Key].Count > 1) {
                    List<int[]> list = diags[kv.Key];
                    // there could be multiple rectangles
                    for (int i = 0; i < list.Count; i++) {
                        for (int j = i + 1; j < list.Count; j++) {
                            // p1, p2, p3 are 3 vertices of a rectangle
                            int p1 = list[i][0];
                            int p2 = list[j][0];
                            int p3 = list[j][1];

                            // len1 and len2 are the length of the sides of a rectangle
                            double len1 = Math.Sqrt((points[p1][0] - points[p2][0]) * (points[p1][0] - points[p2][0]) +  (points[p1][1] - points[p2][1]) * (points[p1][1] - points[p2][1])); 
                            double len2 = Math.Sqrt((points[p1][0] - points[p3][0]) * (points[p1][0] - points[p3][0]) +  (points[p1][1] - points[p3][1]) * (points[p1][1] - points[p3][1]));
                            double area = len1 * len2; 
                            result = Math.Min(result, area);
                        }
                    }
                }
            }
            
            if (result == double.MaxValue) return 0;
            return result;
        }
    }
}