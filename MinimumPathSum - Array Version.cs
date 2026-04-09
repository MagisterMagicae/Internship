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
        
        int gridHeight = grid.Length;
        int gridWidth = grid[0].Length;
        int pathDepth = 0;
        int[][] markedCells = [[0,0]];
        
        Array.Resize(ref grid, grid.Length + 1);
        
        for(int i = 0; i < gridHeight; i++) {
            Array.Resize(ref grid[i], grid[i].Length + 1);
            grid[i][gridWidth] = -1;
        } 

        grid[gridHeight] = [-1,-1];

        for(int i = 0; i < gridWidth + 1; i++) {
            Array.Resize(ref grid[gridHeight], grid[gridHeight].Length + 1);
            grid[gridHeight][grid[gridHeight].Length - 1] = -1;
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
            
            int[][] markedCellCache = [[0]];
            Array.Resize(ref markedCellCache, markedCells.Length);
            for(int i = 0; i < markedCells.Length; i++)
            {

                Array.Resize(ref markedCellCache[i], 2);
                markedCellCache[i][0] = markedCells [i][0];
                markedCellCache[i][1] = markedCells [i][1];
            }
        
            for(int i = 0; i < markedCellCache.Length; i++)
            {   
                int positionY = markedCellCache[i][0];
                int positionX = markedCellCache[i][1];

                grid[positionY][positionX]--;

                if(grid[positionY][positionX] <= 0)
                {
                    grid[positionY][positionX]--;

                    if (!Array.Exists(markedCells, x => x[0] == positionY + 1 && x[1] == positionX))
                    {
                        if (!(grid[positionY + 1][positionX] < 0)){
                            Array.Resize(ref markedCells, markedCells.Length + 1);
                            markedCells[markedCells.Length-1] = [positionY + 1, positionX];
                        }

                        if (grid[positionY + 1][positionX] == 0){
                            Array.Resize(ref markedCellCache, markedCellCache.Length + 1);
                            markedCellCache[markedCellCache.Length-1] = [positionY + 1, positionX];
                        }
                    }

                    if (!Array.Exists(markedCells, x => x[0] == positionY && x[1] == positionX + 1))
                    {
                        if (!(grid[positionY][positionX + 1] < 0)){
                            Array.Resize(ref markedCells, markedCells.Length + 1);
                            markedCells[markedCells.Length-1] = [positionY, positionX + 1];
                        }

                        if (grid[positionY][positionX + 1] == 0){
                            Array.Resize(ref markedCellCache, markedCellCache.Length + 1);
                            markedCellCache[markedCellCache.Length-1] = [positionY, positionX + 1];
                        }
                    }

                    int markIndex = Array.FindIndex(markedCells, x => x[0] == positionY && x[1] == positionX);

                    for (int j = 0; j < markedCells.Length - markIndex - 1; j++)
                    {
                        markedCells[j + markIndex] = markedCells[j + markIndex + 1];
                    }
                    
                    Array.Resize(ref markedCells, markedCells.Length - 1);

                }
            }


        }

        return pathDepth;

    }
}