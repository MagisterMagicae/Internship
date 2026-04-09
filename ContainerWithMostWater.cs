using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

// Approx. Worktime 1.5 hours
// Suggested Improvements: None

public class Solution {
    public int MaxArea(int[] height) {
        
        int foundAbsoluteMax = 0;
        int earlyIndex = 0;
        int lateIndex = height.Length-1;


        while (earlyIndex < lateIndex)
        { 
            int shorterHeight =  Math.Min(height[earlyIndex], height[lateIndex]);
            int maxWaterAtCurrentPosition = shorterHeight*(lateIndex-earlyIndex);
            
            foundAbsoluteMax = Math.Max(foundAbsoluteMax, maxWaterAtCurrentPosition);

            if(height[earlyIndex] < height[lateIndex])
            {
                earlyIndex++;
            } 
            else 
            {
                lateIndex--;
            }
        }
        
        return foundAbsoluteMax;

    }  
}