using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class Recursion
    {
        // https://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/
        public void StrategyGame()
        {
            int[] arr = { 2, 3, 7, 5, 10, 9 };
            Console.WriteLine(Math.Max(2 + StrategyGame(arr, 1, arr.Length - 1), 9 + StrategyGame(arr, 0, arr.Length - 2)));
        }

        private int StrategyGame(int[] arr, int start, int end)
        {
            int sum = 0;

            if (end - start <= 1)
            {
                return 0;
            }

            GetUpdatedIndices(arr, ref start, ref end);

            sum = StrategyGame(arr, start, end);

            return sum += arr[start] > arr[end] ? arr[start] : arr[end];
        }

        private void GetUpdatedIndices(int[] arr, ref int start, ref int end)
        {
            if (arr[start] > arr[end])
            {
                if (arr[++start] > arr[end])
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            else
            {
                if (arr[start] > arr[--end])
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
        }

        public void CanBreakStrings()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("this");
            set.Add("is");
            set.Add("a");
            set.Add("an");
            set.Add("book");

            string input = "thisisanbooks";

            Console.WriteLine(TryBreakStrings(input, set, 0, 0, input.Length-1));
        }

        private bool TryBreakStrings(string input, HashSet<string> set, int start, int cur, int end)
        {
            bool res = false;

            if (set.Contains(input.Substring(start, cur)))
            {
                res = true;
                start += cur;

                if (start >= input.Length)
                {
                    return true;
                }

                cur = 0;
            }

            for(int idx = cur; cur <= end; idx ++)
            {
                if (start + idx +1 > input.Length)
                {
                    break;
                }

                res = TryBreakStrings(input, set, start, idx+1, end);

                if (res)
                {
                    break;
                }
            }

            return res;
        }

        // https://www.geeksforgeeks.org/count-strings-can-formed-using-b-c-given-constraints/
        public void PermutationUnderConstraints()
        {
            Console.WriteLine(PermutationUnderConstraints(3, 1, 2));
        }

        private int PermutationUnderConstraints(int n, int bCount, int cCount)
        {
            if (bCount < 0 || cCount < 0) return 0;
            if (n == 0) return 1;
            if (bCount == 0 && cCount == 0) return 1;

            int res = PermutationUnderConstraints(n - 1, bCount, cCount);
            res += PermutationUnderConstraints(n - 1, bCount - 1, cCount);
            res += PermutationUnderConstraints(n - 1, bCount, cCount - 1);

            return res;
        }

        public void Combinations()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var res = Combinations(list, 0, new List<int>(), new List<List<int>>(), new bool[3]);
        }

        private List<List<int>> Combinations(List<int> list, int idx, List<int> res, List<List<int>> resList, bool[] visited)
        {
            if (idx == list.Count)
            {
                var newList = new List<int>();
                newList = res;
                resList.Add(newList);
                res.Clear();
                return resList;
            }

            if (visited[idx])
            {
                return resList;
            }

            visited[idx] = true;

            res.Add(list[idx]);

            resList = Combinations(list, idx + 1, res, resList, visited);
            resList = Combinations(list, idx, res, resList, visited);

            return resList;
        }

        public void Combination()
        {
            char[] rep = new char[3] { 'a', 'b', 'c' };
            RecurseCombination(rep, 0, 3);
        }

        private void RecurseCombination(char[] rep, int k, int n)
        {
            if (k == n)
            {
                PrintCombination(rep);
                return;
            }
            char temp = ' ';
            temp = rep[k];
            rep[k] = ' ';
            RecurseCombination(rep, k + 1, n);
            rep[k] = temp;
            RecurseCombination(rep, k + 1, n);
        }

        private void PrintCombination(char[] rep)
        {
            for (int idx = 0; idx < rep.Length; idx++)
            {
                if (rep[idx] != ' ')
                {
                    Console.WriteLine(rep[idx]);
                }
            }
            Console.WriteLine("-----------------------------");
        }

        /*
          This problem was asked by Facebook.
          Given a multiset of integers, return whether it can be partitioned into two subsets whose sums are the same.
          For example, given the multiset {15, 5, 20, 10, 35, 15, 10}, it would return true, since we can split it up into {15, 5, 10, 15, 10} and {20, 35}, which both add up to 55.
          Given the multiset {15, 5, 20, 10, 35}, it would return false, since we can't split it up into two subsets that add up to the same sum.
         */
        public void PartitionArrayWithSameSum()
        {
            int[] arr = new int[] { 15, 5, 20, 10, 35, 15, 10 };
            Console.WriteLine(PartitionArrayWithSameSum(arr, 0, 15, 110));
        }

        private bool PartitionArrayWithSameSum(int[] arr, int idx, int sum, int totalSum)
        {
            bool result = false;

            if (idx >= arr.Length)
            {
                return result;
            }

            if (totalSum - sum == sum)
            {
                return true;
            }

            if (!result && idx +1 < arr.Length)
            {
                result = PartitionArrayWithSameSum(arr, idx + 1, sum + arr[idx + 1], totalSum);
            }

            if (!result)
            {
                result = PartitionArrayWithSameSum(arr, idx + 1, sum, totalSum);
            }

            return result;
        }

        // https://leetcode.com/problems/surrounded-regions/description/
        public void SurroundRegions()
        {
            int[,] arr = new int[4, 4]
            {
                { 1, 1, 1, 1},
                { 1, 0, 0, 1},
                { 1, 1, 0, 1},
                { 1, 0, 1, 1}
            };

            for(int row = 0; row < arr.GetLength(0); row ++)
            {
                for(int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        SurroundRegions(arr, row, col, -1, -1);
                    }
                }
            }
        }

        private bool SurroundRegions(int[,] arr, int x, int y, int PreX, int PreY)
        {
            bool result = false;

            if (x > arr.GetLength(0) || y > arr.GetLength(1) || x < 0 || y < 0)
            {
                return false;
            }

            // Top
            if (x-1 >=0 && x-1 != PreX && y != PreY && arr[x - 1, y] == 0)
            {
                    if ((x - 1 == arr.GetLength(0) - 1 || x-1 ==0) && (y == arr.GetLength(1) || y == 0))
                    {
                        return false;
                    }

                    result = SurroundRegions(arr, x-1, y, x, y);

                    if (result)
                    {
                        arr[x, y] = 1;
                    }
            }

            // Right
            if (y+1 <arr.GetLength(1) && x != PreX && y +1 != PreY && arr[x, y + 1] == 0)
            {
                if ((x == arr.GetLength(0) - 1 || x==0) && (y + 1 == arr.GetLength(1) || y == 0))
                {
                    return false;
                }

                result = SurroundRegions(arr, x, y +1, x, y);

                if (result)
                {
                    arr[x, y] = 1;
                }
            }

            //Bottom
            if (x+1 < arr.GetLength(0) && x + 1 != PreX && y != PreY && arr[x + 1, y] == 0)
            {
                if ((x +1 == arr.GetLength(0) - 1 || x ==0) && (y == arr.GetLength(1) || y==0))
                {
                    return false;
                }

                result = SurroundRegions(arr, x + 1, y, x, y);

                if (result)
                {
                    arr[x, y] = 1;
                }
            }

            //Left
            if (y-1 >= 0 && x != PreX && y -1 != PreY && arr[x, y - 1] == 0)
            {
                if ((x == arr.GetLength(0) - 1 || x == 0)  && (y - 1 < arr.GetLength(1) || y == 0))
                {
                    return false;
                }

                result = SurroundRegions(arr, x, y-1, x, y);

                if (result)
                {
                    arr[x, y] = 1;
                }
            }

            return true;
        }

        public void TowerOfHanoi()
        {
            TowerOfHanoi(3, 'A', 'C', 'B');
        }

        private void TowerOfHanoi(int n, char from, char Spare, char To)
        {
            if (n == 1)
            {
                Console.WriteLine($"from: {from} To: {To}");
                return;
            }
            else
            {
                TowerOfHanoi(n - 1, from, To, Spare);
                TowerOfHanoi(1, from, Spare, To);
                TowerOfHanoi(n - 1, Spare, from, To);
            }
        }

        public void PhoneDialpad()
        {
            Dictionary<char, List<char>> map = new Dictionary<char, List<char>>();
            List<char> list1 = new List<char>()
            {
                'A',
                'B',
                'C'
            };

            List<char> list2 = new List<char>()
            {
                'D',
                'E',
                'F'
            };

            List<char> list3 = new List<char>()
            {
                'G',
                'H',
                'i'
            };

            List<char> list4 = new List<char>()
            {
                'J',
                'K',
                'L'
            };

            List<char> list5 = new List<char>()
            {
                'M',
                'N',
                'O'
            };

            List<char> list6 = new List<char>()
            {
                'A',
                'B',
                'C'
            };

            List<char> list7 = new List<char>()
            {
                'A',
                'B',
                'C'
            };

            List<char> list8 = new List<char>()
            {
                'A',
                'B',
                'C'
            };

            List<char> list9 = new List<char>()
            {
                'A',
                'B',
                'C'
            };

            map.Add('1', list1);
            map.Add('2', list2);
            map.Add('3', list3);
            map.Add('4', list4);
            map.Add('5', list5);

            PhoneDialPad("23", -1, map, 0);
        }

        private void PhoneDialPad(string digits, int dIdx, Dictionary<char, List<char>> map, int mIdx)
        {
            if (dIdx >= digits.Length)
            {
                Console.WriteLine("-------------------------------------------------");
                return;
            }

            if (dIdx >= 0)
            {
                var ch = digits[dIdx];

                Console.WriteLine(map[ch][mIdx]);
            }

            for(mIdx=0; mIdx < 3; mIdx++)
            {
                PhoneDialPad(digits, dIdx +1, map, mIdx);
            }
        }

        public void DiffWaysToCompute()
        {
            Console.WriteLine(DiffWaysToCompute("1*2-3+4/5"));
        }

        //https://leetcode.com/problems/different-ways-to-add-parentheses/
        public List<int> DiffWaysToCompute(String input)
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' ||
                    input[i] == '*' ||
                    input[i] == '+')
                {
                    String part1 = input.Substring(0, i);
                    String part2 = input.Substring(i + 1);
                    List<int> part1Ret = DiffWaysToCompute(part1);
                    List<int> part2Ret = DiffWaysToCompute(part2);
                    foreach (int p1  in  part1Ret)
                    {
                        foreach (int p2 in  part2Ret)
                        {
                            int c = 0;
                            switch (input[i])
                            {
                                case '+':
                                    c = p1 + p2;
                                    break;
                                case '-':
                                    c = p1 - p2;
                                    break;
                                case '*':
                                    c = p1 * p2;
                                    break;
                            }
                            ret.Add(c);
                        }
                    }
                }
            }
            if (ret.Count == 0)
            {
                ret.Add(Int32.Parse(input));
            }
            return ret;
        }

        public void SortStack()
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(3);
            stk.Push(5);
            stk.Push(2);
            stk.Push(7);

            RecStack(stk);

            while (stk.Count > 0)
            {
                Console.WriteLine(stk.Pop());
            }
        }

        private void RecStack(Stack<int> stk)
        {
            if (stk.Count == 0)
            {
                return;
            }

            int value = stk.Pop();
            RecStack(stk);

            SortStack(stk, value);
        }

        private void SortStack(Stack<int> stk, int value)
        {
            if (stk.Count == 0 || stk.Count > 0 && value < stk.Peek())
            {
                stk.Push(value);
            }
            else
            {
                int temp = stk.Pop();
                SortStack(stk, value);

                stk.Push(temp);
            }
        }

        //https://leetcode.com/problems/reach-a-number/description/
        public void ReachNumber()
        {
            Console.WriteLine(ReachNumber(4, 0, 0));
        }

        private bool ReachNumber(int num, int idx, int step)
        {
            if (num == idx)
            {
                return true;
            }

            if (step > num)
            {
                return false;
            }

            bool res = false;

            step++;

            res = ReachNumber(num, idx + step, step);

            if (! res)
            {
                res = ReachNumber(num, idx - step, step);
            }

            return res;
        }

        public void CoinChange()
        {
            int[] arr = { 25, 10, 5 };
            Console.WriteLine(CoinChange(arr, 30, 0, 0));
        }

        private int CoinChange(int[] arr, int sum, int val, int idx)
        {
            if (sum == val)
            {
                return 1;
            }

            if (arr.Length == 0 || idx >= arr.Length)
            {
                return 0;
            }

            int count = CoinChange(arr, sum, val + arr[idx], idx + 1);
            count += CoinChange(arr, sum, val, idx +1);

            return count;
        }

        // Given 2(A2XY) output: AXXYAXXY
        public void ParseString()
        {
            StringBuilder sb = new StringBuilder();
            int idx = 0;
            Console.WriteLine(ParseString("2(A2(YZ))", ref idx, sb).ToString());
        }

        private StringBuilder ParseString(string str, ref int idx, StringBuilder sb)
        {
            while(idx < str.Length)
            {
                if (Int32.TryParse(str[idx].ToString(), out int num))
                {
                    idx++;
                    if (str[idx] != 40)
                    {
                        sb.Append(RepeatString(str[idx].ToString(), num));
                    }
                    else
                    {
                        sb = new StringBuilder(RepeatString(ParseString(str, ref idx, sb).ToString(), num));
                    }
                }
                else if (str[idx] > 64 && str[idx] < 91 || str[idx] > 96 && str[idx] < 123)
                {
                    sb.Append(str[idx].ToString());
                }
                else if (str[idx] == 40) // open bracket
                {
                    idx++;
                    sb = ParseString(str, ref idx, sb); // Add repeat
                }
                else if (str[idx] == 41)
                {
                    return sb;
                }

                idx++;
            }

            return sb;
        }

        private string RepeatString(string str, int num)
        {
            StringBuilder sb = new StringBuilder(str);
            for(int idx=1; idx < num; idx++)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }

        public void Encode()
        {
            Console.WriteLine(Encode(0, "111", new Dictionary<int, int>()));
        }

        private int Encode(int p, string str, Dictionary<int, int> map)
        {
            int res = 0;
            if (p == str.Length)
            {
                return 1;
            }

            if (p > str.Length)
            {
                return 0;
            }

            if (map.ContainsKey(p + 1))
            {
                res = map[p + 1];
            }
            else
            {
                res = Encode(p + 1, str, map);
            }

            map.Add(p + 1, res);

            if (str[p] == '1' || p+1 < str.Length && str[p] < '3' && str[p+1] < '7')
            {
                if (map.ContainsKey(p + 2))
                {
                    res += map[p + 2];
                }
                else
                {
                    res += Encode(p + 2, str, map);
                    map.Add(p + 2, res);
                }
            }

            return res;
        }

        // https://www.geeksforgeeks.org/minimum-steps-to-reach-a-destination/
        public void MinStepsToReachDest()
        {
            Console.WriteLine(MinStepsToReachDest(0, 0, 11));
        }

        private int MinStepsToReachDest(int step, int source, int dest)
        {

            if (Math.Abs(source) > dest)
            {
                return int.MaxValue;
            }

            if (source == dest)
            {
                return step;
            }

            int pos = MinStepsToReachDest(step + 1, source + step + 1, dest);

            int neg = MinStepsToReachDest(step + 1, source - step - 1, dest);

            return Math.Min(pos, neg);

        }

        // https://www.geeksforgeeks.org/minimum-number-jumps-reach-endset-2on-solution/
        public void MinStepsToReachEnd()
        {
            int[] a = { 2, 1, 1, 1, 4 };
            Console.WriteLine(MinStepsToReachEnd(a, 0, 0));
        }

        private int MinStepsToReachEnd(int[] arr, int idx, int steps)
        {
            if (arr[idx] + idx >= arr.Length - 1)
            {
                return steps;
            }

            for (idx++; idx <= arr[idx] + idx;)
            {
                return MinStepsToReachEnd(arr, idx, steps + 1);
            }

            return steps;
        }

        public void MinCoinsNeeded()
        {
            int[] arr = new int[] { 1, 2, 3 };

            Console.WriteLine(MinCoinsNeeded(arr, 0, 0, 5, new Dictionary<string, int>(), string.Empty));
        }

        private int MinCoinsNeeded(int[] arr, int idx, int sum, int desiredSum, Dictionary<string, int> dp, string key)
        {
            int count = 0;

            if (idx >= arr.Length)
            {
                return 0;
            }

            if (sum == desiredSum)
            {
                return 1;
            }
            //if (dp.ContainsKey(key))
            //{
            //    return dp[key];
            //}
            //else
            {

                if (sum + arr[idx] <= desiredSum)
                {
                    count += MinCoinsNeeded(arr, idx, sum + arr[idx], desiredSum, dp, key);
                }

                if (sum + arr[idx + 1] <= desiredSum && (idx + 1 < arr.Length))
                {
                    count += MinCoinsNeeded(arr, idx + 1, sum + arr[idx + 1], desiredSum, dp, key);
                }
            }
            
            return count;
        }

        //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
        public void FindPositionInSortedArr()
        {
            int[] arr = new int[] {};
            var res = FindPositionInSortedArr(arr, 0, arr.Length - 1, 0, new List<int>());
            if (res.Count == 0)
            {
                res.Add(-1);
                res.Add(-1);
            }
            res.ToArray();
        }

        private List<int> FindPositionInSortedArr(int[] arr, int start, int end, int num, List<int> list)
        {
            List<int> res = null;

            if (start > end)
            {
                return list;
            }

            if (arr[start] == num)
            {
                list.Add(start);
                start += 1;
            }
            else if (start == end)
            {
                return list;
            }

            int mid = (start + end) / 2;

            if (num <= arr[mid])
            {
                res = FindPositionInSortedArr(arr, start, mid, num, list);
            }
            else
            {
                res = FindPositionInSortedArr(arr, mid + 1, end, num, list);
            }

            return res;
        }

        public void NQueens()
        {
            int[,] arr = new int[4, 4];

            Console.WriteLine(NQueens(arr, 0, 1, new List<Pair>()));
        }

        private bool NQueens(int[,] arr, int row, int col, List<Pair> pairList)
        {
            bool result = false;

            if (row > arr.GetLength(0) || col > arr.GetLength(1))
            {
                return true;
            }

            for (int i = row; i < arr.GetLength(0); i++)
            {
                for (int j = col; j < arr.GetLength(1); j ++)
                {
                    if (IsSafePlacement(arr, row, col, pairList))
                    {
                        Pair p = new Pair(row, col);
                        pairList.Add(p);
                        result = true;
                        continue;
                    }
                    result = NQueens(arr, row, col + 1, pairList);

                    if (! result)
                    {
                        result = NQueens(arr, row + 1, col, pairList);
                    }
                }
            }

            return result;
        }

        private bool IsSafePlacement(int[,] arr, int row, int col, List<Pair> pairList)
        {
            foreach(Pair p in pairList)
            {
                if ((Math.Abs(p.X - row)) == Math.Abs(p.Y - col))
                {
                    return false;
                }
                else if (p.X == row || p.Y == col)
                {
                    return false;
                }
            }

            return true;
        }

        public void PhoneDialPad()
        {
            Dictionary<int, char[]> map = new Dictionary<int, char[]>();
            char[] coll1 = new char[] { 'a', 'b', 'c'};
            char[] coll2 = new char[] { 'd', 'e', 'f' };

            map.Add(1, coll1);
            map.Add(2, coll2);
            int[] dialledNumbers = new int[] { 1, 2};
            PhoneDialPad(map, dialledNumbers, 1, 0);
        }

        private void PhoneDialPad(Dictionary<int, char[]> map, int[] dialledNumbers, int idx, int mapIdx)
        {
            if (dialledNumbers.Length == 0 || idx > dialledNumbers.Length)
            {
                Console.WriteLine("-----------------------------------");
                return;
            }


            for (; mapIdx < 3; mapIdx ++)
            {
                var charArray = map[idx];
                Console.WriteLine(charArray[mapIdx]);

                PhoneDialPad(map, dialledNumbers, idx + 1, 0);
            }
        }

        // https://www.geeksforgeeks.org/egg-dropping-puzzle-dp-11/
        public void EggDrop()
        {
            int attempt = 0;
            Console.WriteLine(EggDrop(2, 10, ref attempt));
        }

        private int EggDrop(int noOfEggs, int floors, ref int attempt)
        {
            if (floors == 1 || floors == 0)
            {
                return floors;
            }

            if (noOfEggs == 1)
            {
                return floors;
            }

            int res = 0;

            for(int x = 1; x < floors; x++)
            {
                res += Math.Max(EggDrop(noOfEggs - 1, floors - 1, ref attempt), 
                    EggDrop(noOfEggs, floors - x, ref attempt));

                if (attempt < res)
                {
                    attempt = res;
                }
            }

            return attempt;
        }
    }
}
