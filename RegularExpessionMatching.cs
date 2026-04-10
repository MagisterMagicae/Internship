// Approx. Worktime 5 hours (concept abandoned)
// Suggested Improvements: None
// Leetcode Runtime ??? ms

using System.Text.RegularExpressions;

Solution solution = new Solution();
Console.WriteLine(solution.IsMatch("aaa", "ab*a*c*a"));

public class Solution
{
    public bool IsMatch(string s, string p)
    {

        char asteriskmemory = ' ';
        bool successflag = true;
        int patternIndex = 0;
        int patternIndexHelper;

        for (int j = 0; j < s.Length; j++)
        {
            if (patternIndex > p.Length - 1)
            {
                successflag = false;
                break;
            }

            if (!(p[patternIndex] == '*'))
            {
                if (patternIndex == p.Length - 1)
                {
                    patternIndexHelper = patternIndex;
                }
                else
                {
                    patternIndexHelper = patternIndex + 1;
                }

                if (!(s[j] == p[patternIndex] || p[patternIndex] == '.' || p[patternIndexHelper] == '*'))
                {
                    successflag = false;
                }

                if(!(s[j] == p[patternIndex] || p[patternIndex] == '.') && p[patternIndexHelper] == '*')
                {
                    patternIndex++;
                    j--;
                }

                asteriskmemory = p[patternIndex];
                patternIndex++;
            }
            else
            {
                if (!(s[j] == asteriskmemory || asteriskmemory == '.'))
                {
                    patternIndex++;
                    j--;
                }
                
                int endhelper = 0;
                int endhelper2 = 0;

                if (!(j > s.Length-3))
                {
                    endhelper = j+2;
                } 

                if (!(j > s.Length - 4)){
                    endhelper2 = j+3;
                }


                if (!(patternIndex == p.Length - 1))
                {
                    if(p[endhelper] == asteriskmemory && (endhelper == 0 || !(s[endhelper] == asteriskmemory) || (!(s[endhelper] == asteriskmemory) && s[endhelper2] == '*' )))
                    {
                       patternIndex++;
                    }
                }

            }
        }

        if (!(patternIndex == p.Length || (patternIndex == p.Length - 1 && p[p.Length-1] == '*')))
        {
            successflag = false;
        }

        return successflag;
    }
}