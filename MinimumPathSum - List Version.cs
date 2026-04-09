using System;
using System.Collections.Immutable;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;

int[][] grid = [[1,2,3],[4,5,6]];
Solution solutionAbtract = new Solution();
int number = solutionAbtract.MinPathSum(grid);
Console.WriteLine(number);

public class Solution {
    public int MinPathSum(int[][] grid) {

        List<int[]> markedCells = new List<int[]>();
        markedCells.Add([0,0]);
        
        int gridHeight = grid.Length;
        int gridWidth = grid[0].Length;
        int pathDepth = 0;
        
        Array.Resize(ref grid, grid.Length + 1);
        
        for(int i = 0; i < gridHeight; i++) {
            Array.Resize(ref grid[i], grid[i].Length + 1);
            grid[i][gridWidth] = -1;
        } 

        grid[gridHeight] = [-1,-1];
        Array.Resize(ref grid[gridHeight], gridWidth + 1);

        for(int i = 1; i < gridWidth - 1; i++) {
            grid[gridHeight][1 + i] = -1;
        } 

        if(grid[gridHeight-1][gridWidth-1] == 0)
        {
            pathDepth--;
            grid[gridHeight-1][gridWidth-1] = 1;
        }
        
        if(grid[0][0] == 0)
        {
            pathDepth--;
        }

        while (!(grid[gridHeight-1][gridWidth-1] <= 0))
        {
            pathDepth++;
            List<int[]> markedCellsCache = new List<int[]>();

            for(int i = 0; i < markedCells.Count; i++)
            {
                markedCellsCache.Add([markedCells[i][0], markedCells[i][1]]);
            }
        
            for(int i = 0; i < markedCellsCache.Count; i++)
            {   
                int positionY = markedCellsCache[i][0];
                int positionX = markedCellsCache[i][1];

                grid[positionY][positionX]--;

                if(grid[positionY][positionX] <= 0)
                {
                    grid[positionY][positionX]--;

                    if (!markedCells.Exists(x => x[0] == positionY + 1 && x[1] == positionX))
                    {
                        if (!(grid[positionY + 1][positionX] < 0)){
                            markedCells.Add([positionY + 1, positionX]);
                        }

                        if (grid[positionY + 1][positionX] == 0){
                            markedCellsCache.Add([positionY + 1, positionX]);
                        }
                    }

                    if (!markedCells.Exists(x => x[0] == positionY && x[1] == positionX + 1))
                    {
                        if (!(grid[positionY][positionX + 1] < 0)){
                            markedCells.Add([positionY, positionX + 1]);
                        }

                        if (grid[positionY][positionX + 1] == 0){
                            markedCellsCache.Add([positionY, positionX + 1]);
                        }
                    }


                    int indexHelper = markedCells.FindIndex(x => x[0] == positionY && x[1] == positionX);
                    markedCells.RemoveAt(indexHelper);
                    markedCells.TrimExcess();
                }
            }


        }

        return pathDepth;

    }
}