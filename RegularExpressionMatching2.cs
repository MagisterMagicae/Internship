// Approx. Worktime 5 hours (concept abandoned)
// Suggested Improvements: None
// Leetcode Runtime ??? ms

using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

Solution solution = new Solution();
Console.WriteLine(solution.IsMatch("aabcbcbcaccbcaabc"
, ".*a*aa*.*b*.c*.*a*"));

public class Solution {
    public bool IsMatch(string StringToMatch, string RegEx) {

        char[] Solution = [' '];
        Array.Resize(ref Solution, StringToMatch.Length);
        int RegExProgress = RegEx.Length-1;
        int ProgressDepth = StringToMatch.Length-1;

        while(!(ProgressDepth == -1))
        {
            if(RegExProgress < 0)
            {
                return false;
            }

            if (RegEx[RegExProgress] == '*')
            {
                int sameNumber = 0;

                bool differentFlag = false;
                for (int i = 0; i < ProgressDepth + 1; i++)
                {
                    if (!differentFlag && (RegEx[RegExProgress - 1] == StringToMatch[ProgressDepth - i] || RegEx[RegExProgress - 1] == '.'))
                    {
                        sameNumber++;
                    } else
                    {
                        differentFlag = true;
                    }
                }
                
                differentFlag = false;

                for (int i = 2; i < RegExProgress + 1; i++)
                {
                    if (!differentFlag && (RegEx[RegExProgress - 1] == RegEx[RegExProgress - i] || RegEx[RegExProgress - 1] == '.'))
                    {
                        if(RegEx[RegExProgress - i] == '*')
                        {
                            i++;
                        }
                        sameNumber--;

                    } else
                    {
                        if(RegEx[RegExProgress - i] == '*')
                        {
                            i++;
                            continue;
                        }
                        differentFlag = true;
                    }
                }

                for (int i = 0; i < sameNumber; i++)
                {
                    Solution[ProgressDepth] = StringToMatch[ProgressDepth];
                    ProgressDepth--;

                }

                RegExProgress--;
                RegExProgress--;
                continue;
            }

            if (RegEx[RegExProgress] == StringToMatch[ProgressDepth] || RegEx[RegExProgress] == '.')
            {
                Solution[ProgressDepth] = StringToMatch[ProgressDepth];
                ProgressDepth--;
                RegExProgress--;
                continue;
            } else
            {
                return false;
            }

            
        }

        while(RegExProgress > 0)
        {
            if(RegEx[RegExProgress] == '*')
            {
                RegExProgress--;
                RegExProgress--;
            }
            else
            {
                break;
            }
        }

        if(!(RegExProgress < 0))
        {   
            return false;
        }

        string SolutionString = new string(Solution);

        if (StringToMatch == SolutionString)
        {
            return true;
        }

        return false; 
    } 
}