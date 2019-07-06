using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class DP
    {
        // https://www.geeksforgeeks.org/find-subarray-with-given-sum/
        public void FindSubArraySum()
        {
            int[] arr = { 1, 4, 20, 3, 10, 5 };
            FindSubArraySum(arr, 33);
        }

        private void FindSubArraySum(int[] arr, int Sum)
        {
            if (arr == null || arr.Count() == 0)
            {
                throw new ArgumentNullException("Argument is null");
            }

            int[,] dpArr = new int[arr.Length, arr.Length];

            for (int row = 0; row < arr.Length; row++)
            {
                for (int col = 0; col < arr.Length; col++)
                {
                    if (row == 0)
                    {
                        if (col == 0)
                        {
                            dpArr[row, col] = arr[col];
                        }
                        else
                        {
                            dpArr[row, col] = dpArr[row, col - 1] + arr[col];
                        }
                    }
                    else
                    {
                        dpArr[row, col] = dpArr[row - 1, col] - arr[row - 1];
                    }

                    if (dpArr[row, col] == Sum)
                    {
                        Console.WriteLine($"Sub array sum matches from index: {row} to {col}");
                    }
                }
            }
        }

        public void CoinChange()
        {
            int[] coins = new int[] { 1, 2, 3 };
            Console.WriteLine(CoinChange(coins, 5));
        }

        private int CoinChange(int[] coins, int sum)
        {
            int[,] dp = new int[coins.Length, sum + 1];

            for (int row = 0; row < coins.Length; row++)
            {
                for (int col = 0; col <= sum; col++)
                {
                    if (col == 0)
                    {
                        dp[row, col] = 1;
                        continue;
                    }

                    if (col > coins[row])
                    {
                        dp[row, col] = row > 0 ? dp[row - 1, col] + dp[row, col - coins[row]]
                            : dp[row, col - coins[row]];
                    }
                    else
                    {
                        if (row > 0)
                        {
                            dp[row, col] = dp[row - 1, col];
                        }
                        else if (col - coins[row] == 0)
                        {
                            dp[row, col] = 1;
                        }
                    }
                }
            }

            return dp[coins.Length, sum + 1];
        }

        //https://leetcode.com/problems/cherry-pickup/description/
        public void CheryPickup()
        {
            int[,] arr = new int[,]
            {
                {0, 1, -1},
                {1, 0, -1},
                {1, 1, 1 }
            };

            Console.WriteLine(CheryPickup(arr));
        }

        private int CheryPickup(int[,] arr)
        {
            int[,] dp = new int[arr.GetLength(0), arr.GetLength(1)];
            Queue<Pair> queue = new Queue<Pair>();
            dp[arr.GetLength(0) - 1, arr.GetLength(1) - 1] = arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1];

            queue.Enqueue(new Pair(arr.GetLength(0) - 1, arr.GetLength(1) - 1));
            bool assigned = false;

            while (queue.Count > 0)
            {
                assigned = false;

                var item = queue.Dequeue();
                {
                    if (arr[item.X, item.Y] > -1)
                    {
                        if (item.Y - 1 >= 0 && arr[item.X, item.Y - 1] != -1)
                        {
                            assigned = true;
                            queue.Enqueue(new Pair(item.X, item.Y - 1));
                            if (arr[item.X, item.Y - 1] == 1)
                            {
                                arr[item.X, item.Y - 1] += arr[item.X, item.Y];
                            }
                            else
                            {
                                arr[item.X, item.Y - 1] = arr[item.X, item.Y];
                            }
                        }

                        if (item.X - 1 >= 0 && arr[item.X - 1, item.Y] != -1 && !assigned)
                        {
                            assigned = true;

                            queue.Enqueue(new Pair(item.X - 1, item.Y));
                            if (arr[item.X - 1, item.Y] == 1)
                            {
                                arr[item.X - 1, item.Y] += arr[item.X, item.Y];
                            }
                            else
                            {
                                arr[item.X - 1, item.Y] = arr[item.X, item.Y];
                            }
                        }
                    }
                }
            }

            return arr[0, 0] = arr[0, 1] + arr[1, 0];
        }

        public void LongestPalindromicSubSequence()
        {
            Console.WriteLine(LongestPalindromicSubSequence("BBABCBCAB"));
        }

        private int LongestPalindromicSubSequence(string str)
        {
            int[,] dp = new int[str.Length, str.Length];

            string revStr = Reverse(str);

            for (int row = 0; row < str.Length; row++)
            {
                for (int col = 0; col < str.Length; col++)
                {
                    if (row == 0)
                    {
                        if (col == 0)
                        {
                            dp[row, col] = str[col] == revStr[row] ? 1 : 0;
                        }
                        else
                        {
                            dp[row, col] = str[col] == revStr[row] ? 1 : dp[row, col - 1];
                        }
                    }
                    else if (col == 0)
                    {
                        dp[row, col] = str[col] == revStr[row] ? 1 : dp[row - 1, col];
                    }
                    else
                    {
                        int value = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                        dp[row, col] = str[col] == revStr[row] ? 1 + dp[row - 1, col - 1] : value;
                    }
                }
            }

            return dp[str.Length - 1, str.Length - 1];
        }

        private string Reverse(string str)
        {
            StringBuilder rev = new StringBuilder();

            for (int idx = str.Length - 1; idx >= 0; idx--)
            {
                rev.Append(str[idx]);
            }

            return rev.ToString();
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/description/
        public void BuySellStocks()
        {
            int[] arr = new int[] { 3, 3, 5, 0, 0, 3, 1, 4 };

            Console.WriteLine(BuySellStocks_O_n(arr));
        }

        private int BuySellStocks(int[] arr)
        {
            int[,] dp = new int[arr.Length, arr.Length];
            int[] colProfit = new int[arr.Length];

            for (int row = 0; row < arr.Length; row++)
            {
                for (int col = row + 1; col < arr.Length; col++)
                {
                    if (col > 0)
                    {
                        dp[row, col] = Math.Max(dp[row, col - 1], arr[col] - arr[row]);

                        if (colProfit[col] < dp[row, col])
                        {
                            colProfit[col] = dp[row, col];
                        }
                    }
                    else
                    {
                        dp[row, col] = arr[row] - arr[col];
                    }
                }
            }

            int max = 0;
            int maxColProfit = 0;
            int colIdx = arr.Length - 1;

            for (int row = arr.Length - 1; row >= 0; row--)
            {
                int profit = dp[row, colIdx];
                colIdx = row - 1;

                max = Math.Max(profit, max);

                while (colIdx >= 0)
                {
                    maxColProfit = Math.Max(maxColProfit, colProfit[colIdx]);
                    colIdx--;

                    if (max < maxColProfit + profit)
                    {
                        max = maxColProfit + profit;
                    }
                }

                maxColProfit = 0;
                colIdx = arr.Length - 1;
            }

            return max;
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/discuss/39615/My-explanation-for-O(N)-solution
        public int BuySellStocks_O_n(int[] prices)
        {
            int sell1 = 0, sell2 = 0, buy1 = int.MinValue, buy2 = int.MinValue;
            for (int i = 0; i < prices.Length; i++)
            {
                buy1 = Math.Max(buy1, -prices[i]);
                sell1 = Math.Max(sell1, buy1 + prices[i]);
                buy2 = Math.Max(buy2, sell1 - prices[i]);
                sell2 = Math.Max(sell2, buy2 + prices[i]);
            }

            return sell2;
        }

        // https://leetcode.com/problems/smallest-rotation-with-highest-score/description/
        public void SmallestRotationWithHighestScore()
        {

        }

        public void SmallestRotationWithHighestScore(int[] arr)
        {

        }

        // https://leetcode.com/problems/decode-ways/description/
        public void DecodeWays()
        {
            Console.WriteLine(DecodeWays("21224"));
        }

        private int DecodeWays(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int[] dp = new int[str.Length];

            if (int.Parse(str[0].ToString()) > 0 && int.Parse(str[0].ToString()) < 9)
            {
                dp[0] = 1;
            }
            else
            {
                dp[0] = 0;
            }

            for (int idx = 1; idx < str.Length; idx++)
            {
                if (int.Parse(str[idx].ToString()) == 0)
                {
                    return 0;
                }

                if ((int.Parse(str.Substring(idx - 1, 2)) <= 26) && (int.Parse(str.Substring(idx - 1, 2)) > 10))
                {
                    if (idx > 1)
                    {
                        dp[idx] = dp[idx - 1] + dp[idx - 2];
                    }
                    else
                    {
                        dp[idx] = dp[idx - 1] + 1;
                    }
                }
                else
                {
                    dp[idx] = dp[idx - 1];
                }
            }

            return dp[str.Length - 1];
        }

        //https://leetcode.com/problems/course-schedule-iii/description/
        public void CourseSchedule()
        {
            Pair p1 = new Pair(100, 200);
            Pair p2 = new Pair(1000, 1250);
            Pair p3 = new Pair(200, 1300);
            Pair p4 = new Pair(2000, 3200);

            List<Pair> pairs = new List<Pair>() { p1, p2, p3, p4 };

            Console.WriteLine(CourseSchedule(pairs));
        }

        private int CourseSchedule(List<Pair> pairs)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            bool found = false;
            int maxCount = 0;

            for (int idx = pairs.Count - 1; idx >= 0; idx--)
            {
                int count = maxCount;

                while (!found && count > 0)
                {
                    found = FindMatchingCourses(idx, count, ref maxCount, dict, pairs);
                    count--;
                }

                if (!found)
                {
                    if (dict.ContainsKey(1))
                    {
                        dict[1].Add(idx);
                    }
                    else
                    {
                        var list = new List<int>();
                        list.Add(idx);
                        dict.Add(1, list);
                    }

                    if (maxCount < 1)
                    {
                        maxCount = 1;
                    }
                }

                found = false;
            }

            return maxCount;
        }

        private bool FindMatchingCourses(int idx, int count, ref int maxCount, Dictionary<int, List<int>> dict, List<Pair> pairs)
        {
            foreach (int dIdx in dict[count])
            {
                if (pairs[idx].Y < pairs[dIdx].X)
                {
                    if (dict.ContainsKey(count + 1))
                    {
                        dict[count + 1].Add(idx);
                    }
                    else
                    {
                        if (count + 1 > maxCount)
                        {
                            maxCount = count + 1;
                        }

                        dict.Add(count + 1, new List<int>() { idx });
                    }

                    return true;
                }
            }
            
            return false;
        }

        public void SubArraySum()
        {
            int[] arr = new int[] { 1, 4, 20, 3, 10, 5 };
            SubArraySumOrderN(arr, arr.Length, 33);
        }

        #region Self DP solution

        //private int SubArraySum(int[] arr)
        //{
        //    int maxCount = 0;

        //    int[,] dpArr = new int[arr.Length, arr.Length];

        //    for (int row = 0; row < arr.Length; row ++)
        //    {
        //        for (int col = row; col < arr.Length; col ++)
        //        {
        //            if (row == 0)
        //            {
        //                if (col +1 < arr.Length)
        //                {
        //                    if (col > 0)
        //                    {
        //                        dpArr[row, col] = dpArr[row, col - 1] + arr[col] < arr[col + 1] ? 1 : 0;
        //                    }
        //                    else
        //                    {
        //                        dpArr[row, col] += arr[col] < arr[col + 1] ? 1 : 0;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (col +1 < arr.Length)
        //                {
        //                    if (dpArr[row-1, col] < dpArr[row-1, col + 1])
        //                    {
        //                        dpArr[row, col] += 1;
        //                    }
        //                    else if(dpArr[row-1, col] == dpArr[row-1, col +1])
        //                    {
        //                        dpArr[row, col] = dpArr[row, col -1] + arr[col] < arr[col + 1] ? 1 : 0;
        //                    }
        //                    else
        //                    {
        //                        dpArr[row, col] = dpArr[row, col - 1];
        //                    }
        //                }
        //            }
        //            if (maxCount < dpArr[row, col])
        //            {
        //                maxCount = dpArr[row, col];
        //            }
        //        }
        //    }

        //    return maxCount;
        //}
        #endregion

        private int SubArraySum(int[] arr)
        {
            int[] T = new int[arr.Length];
            int max = 0;

            for (int idx = 0; idx < arr.Length; idx++)
            {
                T[idx] = 1;
            }

            for (int j = 1; j < arr.Length; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (arr[i] < arr[j])
                    {
                        T[j] = Math.Max(T[j], T[i] + 1);

                        if (max < T[j])
                        {
                            max = T[j];
                        }
                    }
                }
            }

            return max;
        }

        private void SubArraySumOrderN(int[] arr, int n, int sum)
        {
            // create an empty map
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Maintains sum of elements so far
            int curr_sum = 0;

            for (int i = 0; i < n; i++)
            {
                // add current element to curr_sum
                curr_sum = curr_sum + arr[i];

                // if curr_sum is equal to target sum
                // we found a subarray starting from index 0
                // and ending at index i
                if (curr_sum == sum)
                {
                    Console.WriteLine($"Sum found between indexes 0 to {i}");
                    return;
                }

                // If curr_sum - sum already exists in map
                // we have found a subarray with target sum
                if (map.ContainsKey(curr_sum - sum))
                {
                    Console.WriteLine($"Sum found between indexes {map[curr_sum - sum] + 1} to {i}");
                    return;
                }

                map[curr_sum] = i;
            }

            // If we reach here, then no subarray exists
            Console.WriteLine("No subarray with given sum exists");

        }


        public void SubsetSum()
        {
            int[] arr = new int[] { 10, 3, 2, 4 };
            Console.WriteLine(SubsetSum(arr, 16));
        }

        private bool SubsetSum(int[] arr, int sum)
        {
            bool[,] dp = new bool[arr.Length, sum];


            for (int row = 0; row < arr.Length; row++)
            {
                for (int col = 0; col < dp.GetLength(1); col++)
                {
                    if (arr[row] - col == 0)
                    {
                        dp[row, col] = true;
                        continue;
                    }
                    if (row > 0 && arr[row] < col)
                    {
                        var diff = col - arr[row];
                        dp[row, col] = dp[row - 1, col] || dp[row - 1, diff];
                    }
                }
            }

            return dp[arr.Length - 1, sum - 1];
        }

        // https://www.geeksforgeeks.org/dynamic-programming-set-37-boolean-parenthesization-problem/
        public void BooleanParanthesization()
        {
            char[] boolean = new char[] { 'T', 'T', 'F', 'T' };
            char[] oper = new char[] { '|', '&', '^' };

            Console.WriteLine(BooleanParanthesization(boolean, oper, 4));
        }

        private int BooleanParanthesization(char[] ch, char[] oper, int n)
        {
            int[,] T = new int[n, n];
            int[,] F = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                T[i, i] = ch[i] == 'T' ? 1 : 0;
                F[i, i] = ch[i] == 'F' ? 1 : 0;
            }

            for (int gap = 1; gap < n; ++gap)
            {
                for (int i = 0, j = gap; j < n; ++i, ++j)
                {
                    T[i, j] = F[i, j] = 0;
                    for (int g = 0; g < gap; g++)
                    {
                        // Find place of parenthesization using current value
                        // of gap
                        int k = i + g;

                        // Store Total[i][k] and Total[k+1][j]
                        int tik = T[i, k] + F[i, k];
                        int tkj = T[k + 1, j] + F[k + 1, j];

                        // Follow the recursive formulas according to the current
                        // operator
                        if (oper[k] == '&')
                        {
                            T[i, j] += T[i, k] * T[k + 1, j];
                            F[i, j] += (tik * tkj - T[i, k] * T[k + 1, j]);
                        }
                        if (oper[k] == '|')
                        {
                            F[i, j] += F[i, k] * F[k + 1, j];
                            T[i, j] += (tik * tkj - F[i, k] * F[k + 1, j]);
                        }
                        if (oper[k] == '^')
                        {
                            T[i, j] += F[i, k] * T[k + 1, j] + T[i, k] * F[k + 1, j];
                            F[i, j] += T[i, k] * T[k + 1, j] + F[i, k] * F[k + 1, j];
                        }
                    }
                }
            }


            return T[0, n - 1];
        }

        // https://www.geeksforgeeks.org/longest-common-subsequence/
        public void LCS()
        {
            string str1 = "AGGTAB";
            string str2 = "GXTXAYB";

            Console.WriteLine(LCS(str2, str1));
        }

        private int LCS(string str1, string str2)
        {
            int maxLength = str1.Length > str2.Length ? str1.Length : str2.Length;
            int minLength = str1.Length < str2.Length ? str1.Length : str2.Length;

            int[,] lcs = new int[maxLength + 1, minLength + 1];

            for (int row = 1; row <= maxLength; row++)
            {
                for (int col = 1; col <= minLength; col++)
                {
                    if (str1.Length > str2.Length)
                    {
                        if (str1[row - 1] == str2[col - 1])
                        {
                            lcs[row, col] = 1 + lcs[row - 1, col - 1];
                        }
                        else
                        {
                            lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                        }
                    }
                    else
                    {
                        if (str2[row - 1] == str1[col - 1])
                        {
                            lcs[row, col] = 1 + lcs[row - 1, col - 1];
                        }
                        else
                        {
                            lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                        }
                    }
                }
            }

            return lcs[maxLength, minLength];
        }

        //https://www.geeksforgeeks.org/find-if-string-is-k-palindrome-or-not/
        public void KPalindrome()
        {
            Console.WriteLine(KPalindrome("abcdba", 1));
        }

        private int KPalindrome(string str1, int k)
        {
            string str2 = str1.Reverse().ToString();
            int l = str1.Length;
            // Create a table to store results of subproblems 
            int[,] dp = new int[l + 1, l + 1];

            // Fill dp[][] in bottom up manner 
            for (int i = 0; i <= l; i++)
            {
                for (int j = 0; j <= l; j++)
                {
                    // If first string is empty, only option is to 
                    // remove all characters of second string 
                    if (i == 0)
                        dp[i, j] = j; // Min. operations = j 

                    // If second string is empty, only option is to 
                    // remove all characters of first string 
                    else if (j == 0)
                        dp[i, j] = i; // Min. operations = i 

                    // If last characters are same, ignore last character 
                    // and recur for remaining string 
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    // If last character are different, remove it 
                    // and find minimum 
                    else
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], // Remove from str1 
                                        dp[i, j - 1]); // Remove from str2 
                }
            }

            return dp[l, l];
        }

        // https://leetcode.com/problems/word-break/description/
        public void WordBreak()
        {
            HashSet<string> dict = new HashSet<string>() { "this","is","a","an","book","apple", "pen" };

            Console.WriteLine(WordBreak("thisisanbook", dict));
        }

        private bool WordBreak(string s, HashSet<string> dict)
        {
            if (s == null || s.Length == 0) return false;

            int n = s.Length;
            int previous = 0;
            bool[] dp = new bool[n + 1];
            dp[0] = true;

            for (int i = 1; i <= n; i++)
            {
                for (int j = i - 1; j >= previous; j--)
                {
                    String sub = s.Substring(j, i - j);

                    if (dict.Contains(sub) && (dp[j]))
                    {
                        dp[i] = true;
                        previous = i;
                        break;
                    }
                }
            }

            return dp[n];
        }

        //https://www.geeksforgeeks.org/given-two-strings-find-first-string-subsequence-second/
        public void SubSequence()
        {
            Console.WriteLine(IsSubSequence("ADXCPY", "AXY"));
        }

        private bool IsSubSequence(string s1, string s2)
        {
            if (s2.Length > s1.Length)
            {
                return IsSubSequence(s2, s1);
            }

            bool[,] dp = new bool[s2.Length, s1.Length];

            for (int row = 0; row < s2.Length; row++)
            {
                for (int col = 0; col < s1.Length; col++)
                {
                    if (s1[col] == s2[row])
                    {
                        dp[row, col] = true && (row > 0 && col > 0 ? dp[row - 1, col - 1] : true);
                    }
                    else
                    {
                        dp[row, col] = col > 0 ? dp[row, col - 1] : false;
                    }
                }
            }

            return dp[s2.Length - 1, s1.Length - 1];
        }

        //https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
        public void LongestIncreasingPathInArray()
        {
            int[,] arr = new int[,]
            {
                {3, 4, 5 },
                {3, 2, 6 },
                { 2, 2, 1}
            };

            Pair left = new Pair(0, -1);
            Pair right = new Pair(0, 1);
            Pair top = new Pair(-1, 0);
            Pair bottom = new Pair(1, 0);

            List<Pair> pairs = new List<Pair>();
            pairs.Add(left);
            pairs.Add(right);
            pairs.Add(top);
            pairs.Add(bottom);

            int max = 0;
            int res = 0;

            int[,] dp = new int[arr.GetLength(0), arr.GetLength(1)];

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    dp[row, col] = -1;
                }
            }

            bool[,] visited = new bool[arr.GetLength(0), arr.GetLength(1)];

            for (int row = 0; row < arr.GetLength(0); row ++)
            {
                for(int col = 0; col < arr.GetLength(1); col ++)
                {
                    res = LongestIncreasingPathInArray(arr, pairs, row, col, dp);

                    if (max < res)
                    {
                        max = res;
                    }
                }
            }


            Console.WriteLine("Max is " + max);
        }

        private int LongestIncreasingPathInArray(int[,] arr, List<Pair> pairs, int row, int col, int[,] dp)
        {
            int res = 1;
            int len = 0;

            if (dp[row, col] > -1)
            {
                return dp[row, col];
            }

            foreach (Pair pair in pairs)
            {
                int r = row + pair.X;
                int c = col + pair.Y;

                if (!ValidBounds(arr, r, c) || arr[r, c] < arr[row, col])
                {
                    continue;
                }

                len = 1 + LongestIncreasingPathInArray(arr, pairs, r, c, dp);
                res = Math.Max(len, res);
            }

            dp[row, col] = res;

            return res;
        }

        private bool ValidBounds(int[,] arr, int row, int col)
        {
            if (row >= arr.GetLength(0) || col >= arr.GetLength(1) || row < 0 || col < 0)
            {
                return false;
            }

            return true;
        }

        // https://leetcode.com/problems/unique-paths-ii/description/
        public void TotalUniqueWays()
        {
            int[,] arr = new int[,]
            {
                { 0, 0, 0},
                { 0, 0, 0},
                { 0, 0, 0 }
            };

            Console.WriteLine(TotalUniqueWays(arr));
        }

        private int TotalUniqueWays(int[,] arr)
        {
            int[,] dp = new int[arr.GetLength(0), arr.GetLength(1)];

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        if (row == 0 || col == 0)
                        {
                            dp[row, col] = 1;
                        }
                        else
                        {
                            dp[row, col] = dp[row - 1, col] + dp[row, col - 1];
                        }
                    }
                }
            }

            return dp[arr.GetLength(0) - 1, arr.GetLength(1) - 1];
        }

        // Excellent
        // https://leetcode.com/problems/distinct-subsequences/description/
        public void DistinctSubsequences()
        {
            Console.WriteLine(DistinctSubsequences("bag", "babgbag"));
        }

        private int DistinctSubsequences(string t, string s)
        {
            int m = t.Length, n = s.Length;
            int[] cur = new int[s.Length + 1];
            // cur[0] = 1;
            for (int j = 1; j <= n; j++)
            {
                int pre = 1;
                for (int i = 1; i <= m; i++)
                {
                    int temp = cur[i];
                    cur[i] = cur[i] + (t[i - 1] == s[j - 1] ? pre : 0);
                    pre = temp;
                }
            }
            return cur[m];
        }

        private int DistinctSubsequences2(string t, string s)
        {
            int[] dp = new int[4];
            dp[0] = 1;
            int m = t.Length;

            dp[0] = 1;
            for (int j = 1; j <= s.Length; j++)
            {
                for (int i = m; i >= 1; i--)
                {
                    dp[i] += s[j - 1] == t[i - 1] ? dp[i - 1] : 0;
                }
            }

            return dp[m];
        }
    }
}
