// Approx. Worktime 0.5 Hours
// Suggested Improvements: None
// Leetcode Runtime 0 ms

public class Solution {
    public void Rotate(int[][] matrix) {

        int matrixSize = matrix.Length;
        decimal mirrorHelper = matrixSize/2;
        mirrorHelper = Math.Ceiling(mirrorHelper);

        for(int i = 0; i < matrixSize; i++)
        {
            for(int j = i; j < matrixSize; j++)
            {
                //transposing matrix
                int save = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = save;
            }
        }

        for(int i = 0; i < matrixSize; i++)
        {
            for(int j = 0; j < mirrorHelper; j++)
            {
                //mirroring matrix
                int save = matrix[i][j];
                matrix[i][j] = matrix[i][matrixSize-j-1];
                matrix[i][matrixSize-j-1] = save;
            }
        }
        
    }
}

