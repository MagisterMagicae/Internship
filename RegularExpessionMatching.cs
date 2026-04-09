// Approx. Worktime 0.5 Hours
// Suggested Improvements: None
// Leetcode Runtime 10 ms

using System.Text.RegularExpressions;

public class Solution {
    public bool IsMatch(string s, string p) {
        string pattern = $@"^{p}$";
        Match match = Regex.Match(s, pattern);
        return match.Success;
    }
}