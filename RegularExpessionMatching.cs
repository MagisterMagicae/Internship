// Approx. Worktime 
// Suggested Improvements: 
// Leetcode Runtime 

using System.Text.RegularExpressions;

public class Solution {
    public bool IsMatch(string s, string p) {
        string pattern = $@"^{p}$";
        Match match = Regex.Match(s, pattern);
        return match.Success;
    }
}