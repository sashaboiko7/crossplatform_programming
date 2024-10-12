using System;

namespace Lab2
{
    public static class LongestCommonSubstringFinder
    {
        public static (string alpha, string beta) FindLongestCommonSubstring(string xi, string eta)
        {
            int m = xi.Length;
            int n = eta.Length;

            int[,] dp = new int[m + 1, n + 1];
            int maxLen = 0;
            int endXi = 0;
            int endEta = 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (xi[i - 1] == eta[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;

                        if (dp[i, j] > maxLen)
                        {
                            maxLen = dp[i, j];
                            endXi = i;
                            endEta = j;
                        }

                        Console.WriteLine($"Match: {xi[i - 1]} at position {i - 1} in xi and {j - 1} in eta");
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            string alpha = xi.Substring(endXi - maxLen, maxLen);
            string beta = eta.Substring(endEta - maxLen, maxLen);

            Console.WriteLine($"Final alpha: {alpha}, beta: {beta}");

            return (alpha, beta);
        }
    }
}