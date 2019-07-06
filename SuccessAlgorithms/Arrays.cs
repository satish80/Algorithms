using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class Arrays
    {
        // https://www.geeksforgeeks.org/find-triplets-array-whose-sum-equal-zero/
        public void HasTripletSumZero()
        {
            int[] arr = { -3, -1, 0, 1, 2 };

            Console.WriteLine(HasTripletSumZero(arr));
        }

        private bool HasTripletSumZero(int[] arr)
        {
            int x, l, r = 0;

            int idx = -1;
            bool found = false;

            while (++idx < arr.Length)
            {
                x = arr[idx];
                l = idx + 1;
                r = arr.Length - 1;

                while (l < r)
                {
                    if (x + arr[l] + arr[r] == 0)
                    {
                        Console.WriteLine($"{x} {arr[l]} {arr[r]}");
                        found = true;
                        l++;
                        r--;
                    }
                    else if (x + arr[l] + arr[r] > 0)
                    {
                        r--;
                    }
                    else if (x + arr[l] + arr[r] < 0)
                    {
                        l++;
                    }
                }
            }

            return found;
        }

        public void MaxSubArraySum()
        {
            int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };
            Console.WriteLine(MaxSubArraySum(arr));
        }

        private int MaxSubArraySum(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array is null");
            }

            int max = arr[0];
            int curSum = arr[0];

            int count = 0;

            while (++count < arr.Length)
            {
                curSum += arr[count];

                if (curSum < arr[count])
                {
                    curSum = 0;
                }

                if (curSum > max)
                {
                    max = curSum;
                }
            }

            return max;
        }

        public void ReOrder()
        {
            int[] arr = new int[] { 5, 2, 3, 1, 8, 4, 6 };
            ReOrder(arr, 2);

            foreach (int val in arr)
            {
                Console.WriteLine(val);
            }
        }

        private void ReOrder(int[] arr, int idx)
        {
            int num = arr[idx];
            int numIdx = idx;
            int bIdx = -1;

            for (idx = 0; idx < arr.Length; idx++)
            {
                if (idx == numIdx)
                {
                    continue;
                }

                if (arr[idx] > num && idx < numIdx)
                {
                    if (bIdx == -1)
                    {
                        bIdx = numIdx;
                    }

                    numIdx = swap(arr, idx, numIdx);
                }
                else if (arr[idx] < num && idx > numIdx)
                {
                    if (numIdx < arr.Length - 1)
                    {
                        if (idx < bIdx)
                        {
                            numIdx = swap(arr, idx, numIdx);
                        }
                        else
                        {
                            swap(arr, idx, bIdx);
                            numIdx = swap(arr, bIdx, numIdx);
                            bIdx = numIdx + 1;
                        }
                    }
                }
            }
        }

        private int swap(int[] arr, int sIdx, int tIdx)
        {
            int temp = arr[tIdx];
            arr[tIdx] = arr[sIdx];
            arr[sIdx] = temp;

            return sIdx;
        }

        // https://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/
        public void StrategyGame()
        {
            int[] arr = { 8, 15, 3, 7 };
            Console.WriteLine(StrategyGame(arr));
        }

        private int StrategyGame(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("array is null");
            }

            int start = 0, end = arr.Length - 1;
            int sum = 0;


            while (end - start >= 1)
            {
                sum += arr[start] > arr[end] ? arr[start] : arr[end];
                start++;
                end--;
            }

            return sum;
        }

        public void MergeSortedArrays()
        {
            int[] arr1 = new int[] { 2,4,5, 7};
            int[] arr2 = new int[] { 1, 3, 6, 8 };
            int[] res = MergeSortedArrays(arr1, arr2);

            foreach (int i in res)
            {
                Console.WriteLine(i);
            }
        }

        private int[] MergeSortedArrays(int[] arr1, int[] arr2)
        {
            int idx1 = 0, idx2 = 0, idx = 0;

            int[] res = new int[arr1.Length + arr2.Length];

            while(idx1 < arr2.Length && idx2 < arr2.Length)
            {
                while(idx1 < arr1.Length && idx2 < arr2.Length && arr1[idx1] < arr2[idx2])
                {
                    res[idx++] = arr1[idx1++];
                }

                while(idx1 < arr1.Length && idx2 < arr2.Length && arr2[idx2] < arr1[idx1] )
                {
                    res[idx++] = arr2[idx2++];
                }
               
            }

            if (idx1 < arr1.Length)
            {
                FillRemaining(idx1, idx, arr1, res);
            }
            else if (idx2 < arr2.Length)
            {
                FillRemaining(idx2, idx, arr2, res);
            }

            return res;
        }

        private int[] FillRemaining(int idx, int rIdx, int[] arr, int[] res)
        {
            while (idx < arr.Length)
            {
                res[rIdx++] = arr[idx++];
            }

            return res;
        }

        // https://leetcode.com/problems/longest-increasing-subsequence/discuss/74824/JavaPython-Binary-search-O(nlogn)-time-with-explanation
        public void LongestIncreasingSubsequence()
        {
            int[] arr = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };

            Console.WriteLine(lengthOfLIS(arr));
        }

        public int lengthOfLIS(int[] nums)
        {
            int[] tails = new int[nums.Length];
            int size = 0;
            foreach(int x in nums)
            {
                int i = 0, j = size;
                while (i != j)
                {
                    int m = (i + j) / 2;
                    if (tails[m] < x)
                        i = m + 1;
                    else
                        j = m;
                }

                tails[i] = x;

                if (i == size)
                {
                    ++size;
                }
            }

            return size;
        }

        public void MergeIntervals()
        {
            Pair p = new Pair(1, 3);
            Pair p2 = new Pair(5, 8);
            Pair p3 = new Pair(4, 10);
            Pair p4 = new Pair(20, 25);
            var pairs = new List<Pair>();
            pairs.Add(p);
            pairs.Add(p2);
            pairs.Add(p3);
            pairs.Add(p4);

            var res = MergeIntervals(pairs);
        }

        private List<Pair> MergeIntervals(List<Pair> list)
        {
            List<Pair> result = new List<Pair>();
            int idx = 0;

            while (idx < list.Count)
            {
                var item = list[idx];

                int x = item.X;
                int y = item.Y;

                while (idx < list.Count)
                {
                    idx++;
                    if (idx < list.Count && list[idx].X < y)
                    {
                        y = list[idx].Y > y ? list[idx].Y : y;
                        x = list[idx].X < x ? list[idx].X : x;
                    }
                    else
                    {
                        break;
                    }
                }

                result.Add(new Pair(x, y));
            }

            return result;
        }

        public int FindKthLargest()
        {
            int[] a = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            int n = a.Length;
            int p = QuickSelect(a, 0, n - 1, n - k + 1);
            return a[p];
        }

        // return the index of the kth smallest number
        int QuickSelect(int[] a, int lo, int hi, int k)
        {
            // use quick sort's idea
            // put nums that are <= pivot to the left
            // put nums that are  > pivot to the right
            int i = lo, j = hi, pivot = a[hi];
            while (i < j)
            {
                if (a[i++] > pivot)
                {
                    swap(a, --i, --j);
                }
            }
            swap(a, i, hi);

            // count the nums that are <= pivot from lo
            int m = i - lo + 1;

            // pivot is the one!
            if (m == k) return i;
            // pivot is too big, so it must be on the left
            else if (m > k) return QuickSelect(a, lo, i - 1, k);
            // pivot is too small, so it must be on the right
            else return QuickSelect(a, i + 1, hi, k - m);
        }

        public void MergeKsortedArrays()
        {
            int[][] arr =  {
                   new int[] {5, 7, 15, 18},
                   new int[] {1, 8, 9, 17},
                   new int[] {1, 4, 7, 7}
            };

            var sortedArray = Partition(arr, 0, 2);
        }

        private int[] Partition(int[][] arrays, int s, int e)
        {
            int q = s + e / 2;

            if (s == e)
            {
                return arrays[s];
            }

            int[] left = Partition(arrays, s, q);
            int[] right = Partition(arrays, q + 1, e);

            return Merge(left, right);
        }

        private int[] Merge(int[] left, int[] right)
        {
            int lIdx = 0; int rIdx = 0;
            int[] arr = new int[left.Length + right.Length];
            int idx = 0;

            while (lIdx < left.Length && rIdx < right.Length)
            {
                if (left[lIdx] < right[rIdx])
                {
                    arr[idx++] = left[lIdx++];
                }
                else
                {
                    arr[idx++] = right[rIdx++];
                }
            }

            while (lIdx < left.Length)
            {
                arr[idx++] = left[lIdx++];
            }

            while (rIdx < right.Length)
            {
                arr[idx++] = right[rIdx++];
            }

            return arr;
        }

        public void Combinations()
        {
            int?[] arr = new int?[] { 1, 2, 3};

            var res = Combinations(arr, new List<IList<int>>(), 0);
        }

        private IList<IList<int>> Combinations(int?[] nums, IList<IList<int>> res, int idx)
        {
            if (idx > nums.Length)
            {
                return res;
            }

            if (idx == nums.Length)
            {
                IList<int> list = new List<int>();

                for(int i = 0; i < nums.Length; i ++)
                {
                    if (nums[i] != null)
                    {
                        list.Add((int)nums[i]);
                    }
                }

                res.Add(list);
                return res;
            }

            int temp = (int)nums[idx];

            Combinations(nums, res, idx + 1);

            nums[idx] = null;
            Combinations(nums, res, idx + 1);

            nums[idx] = temp;
            return res;
        }

        // https://leetcode.com/problems/maximal-rectangle/discuss/29054/Share-my-DP-solution
        public void MaxRectangle()
        {
            int[,] rect = new int[4, 5]
            {
                { 1, 0, 1, 0, 0},
                { 1, 0, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 0, 0, 1, 0}
            };

            //char[,] rect = new char[2, 2]
            //{
            //    {'0', '1'},
            //    {'1', '0'}
            //};

            Console.WriteLine(MaxRectangleUsingHistogram(rect));
        }

        private int MaxRectangleUsingHistogram(int[,] rect)
        {
            Stack<int> stk = new Stack<int>();

            int rowLength = rect.GetLength(0);
            int colLength = rect.GetLength(1);
            int maxLength = rowLength > colLength ? rowLength : colLength;
            int[,] hist = new int[1, maxLength];

            int row = 0;
            int top = 0;
            int area = 0;
            int maxArea = 0;
            int idx = 0;

            while (row < rowLength)
            {
                if (row < rowLength)
                {
                    for (int col = 0; col < colLength; col++)
                    {
                        if (row > 0)
                        {
                            hist[0, col] = rect[row - 1, col] + rect[row, col];
                        }
                        else
                        {
                            hist[0, col] = rect[row, col];
                        }
                    }
                }

                for (idx = 0; idx < maxLength;)
                {
                    if (stk.Count() == 0 || hist[0, stk.Peek()] <= hist[0, idx])
                    {
                        stk.Push(idx++);
                    }
                    else
                    {
                        top = stk.Pop();

                        if (stk.Count() == 0)
                        {
                            area = hist[0, top] * idx;
                        }
                        else
                        {
                            area = hist[0, top] * (idx - stk.Peek() - 1);
                        }

                        if (maxArea < area)
                        {
                            maxArea = area;
                        }
                    }
                }

                while (stk.Count() > 0)
                {
                    top = stk.Pop();

                    if (stk.Count() == 0)
                    {
                        area = hist[0, top] * idx;
                    }
                    else
                    {
                        area = hist[0, top] * (idx - stk.Peek() - 1);
                    }

                    if (maxArea < area)
                    {
                        maxArea = area;
                    }
                }

                row++;
            }

            return maxArea;
        }

        // * Tricky *
        // https://leetcode.com/problems/longest-valid-parentheses/description/
        public void LongestValidParentheses()
        {
            Console.WriteLine(LongestValidParentheses("()()()"));
        }

        private int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            Stack<int> stack = new Stack<int>();
            int max = 0;
            int left = -1;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '(')
                {
                    stack.Push(j);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        left = j;
                    }
                    else
                    {
                        stack.Pop();
                        if (stack.Count == 0)
                        {
                            max = Math.Max(max, j - left);
                        }
                        else
                        {
                            max = Math.Max(max, j - stack.Peek());
                        }
                    }
                }
            }

            return max;
        }

        // ** Tricky **
        // https://www.geeksforgeeks.org/minimum-swaps-required-group-1s-together/
        public void MinimumSwapToGroup1()
        {
            // int[] arr = new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1};
            //int[] arr = new int[] { 1, 1, 0, 0, 1, 0, 1, 0 };
            int[] arr = new int[] { 0, 1, 0, 1, 0, 1 };
            Console.WriteLine(MinSwapsToGroup1(arr, arr.Length));
        }

        private int CreMinimumSwapToGroup1(int[] arr)
        {
            int length = 0;

            if (arr.Length == 0)
            {
                return length;
            }


            int OneCount = 0;

            for (int idx = 0; idx < arr.Length; idx++)
            {
                if (arr[idx] == 1)
                {
                    OneCount++;
                }
            }

            int max = 0, count = 0;

            for (int idx = 0; idx < arr.Length; idx++)
            {
                if (arr[idx] == 1)
                {
                    count++;

                    if (max < count)
                    {
                        max = count;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            return OneCount - max; ;
        }

        private int MinSwapsToGroup1(int[] arr, int n)
        {

            int noOfOnes = 0;

            // find total number of all in the array
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 1)
                    noOfOnes++;
            }

            // length of subarray to check for
            int x = noOfOnes;

            int maxOnes = Int32.MinValue;

            // array to store number of 1's upto
            // ith index
            int[] preCompute = new int[n];

            // calculate number of 1's upto ith
            // index and store in the array preCompute[]
            if (arr[0] == 1)
                preCompute[0] = 1;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == 1)
                {
                    preCompute[i] = preCompute[i - 1] + 1;
                }
                else
                    preCompute[i] = preCompute[i - 1];
            }

            // using sliding window technique to find
            // max number of ones in subarray of length x
            for (int i = x - 1; i < n; i++)
            {
                if (i == (x - 1))
                    noOfOnes = preCompute[i];
                else
                    noOfOnes = preCompute[i] - preCompute[i - x];

                if (maxOnes < noOfOnes)
                    maxOnes = noOfOnes;
            }

            // calculate number of zeros in subarray
            // of length x with maximum number of 1's
            int noOfZeroes = x - maxOnes;

            return noOfZeroes;
        }

        public void MaxHeapify()

        {
            int[] arr = { 5, 15, 1, 3 };
            MaxHeapify(arr);
        }

        private void MaxHeapify(int[] arr)
        {
            PriorityQueue queue = new PriorityQueue(PriorityQueue.PriorityQueueType.Max);
            queue.Heapify(arr);
        }

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public void BuySellStockOnce()
        {
            int[] arr = new int[] { 310, 315, 235, 265, 260, 270, 290, 230, 255, 250 };
            Console.WriteLine(BuySellStockOnce(arr));
        }

        public int BuySellStockOnce(int[] prices)
        {
            int maxCur = 0, maxSoFar = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxCur = Math.Max(0, maxCur += prices[i] - prices[i - 1]);
                maxSoFar = Math.Max(maxCur, maxSoFar);
            }
            return maxSoFar;
        }

        public void DiffWaysToCompute()
        {
            var res = diffWaysToCompute("2*3-4+5");
        }

        public List<int> diffWaysToCompute(String input)
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
                    List<int> part1Ret = diffWaysToCompute(part1);
                    List<int> part2Ret = diffWaysToCompute(part2);
                    foreach (int p1  in  part1Ret)
                    {
                        foreach (int p2 in   part2Ret)
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
            if (ret.Count() == 0)
            {
                ret.Add(int.Parse(input));
            }
            return ret;
        }
        public void CountPebbles()
        {

        }

        private int CountPebbles(int[,] arr)
        {
            if (arr == null)
            {
                return 0;
            }

            int[] rowCount = new int[3] { 1, 1, 0};
            int[] colCount = new int[3] { 1, 1, 0};

            int count = 0;
            int maxCount = 0;

            for (int row = 0; row < arr.GetLength(0); row ++)
            {
                for (int col = 0; col < arr.GetLength(1); col ++)
                {
                    if (arr[row, col] == 1)
                    {
                        if (maxCount < count)
                        {
                            maxCount = count;
                        }

                    }
                }
            }

            return maxCount;
        }

        private int ReturnCount(int[,] arr, int[] rowCount, int[] colCount, int row, int col)
        {
            int count = 0;

            count += rowCount[row];
            rowCount[row] = 0;

            count += colCount[col];
            colCount[col] = 0;

            count = ReturnCount(arr, rowCount, colCount, row++, col++);

            return count;
        }

        // https://www.geeksforgeeks.org/count-of-unique-pairs-arri-arrj-such-that-i-j/
        public void GetUniquePairs()
        {
            int[] a = { 1, 2, 2, 4, 2, 5, 3, 5 };
            int n = a.Length;

            // Print the count of unique pairs 
            Console.WriteLine(GetUniquePairs(a, n));
        }

        private int GetUniquePairs(int[] a, int n)
        {
            HashSet<int> visited1 = new HashSet<int>();

            // un[i] stores number of unique elements 
            // from un[i + 1] to un[n - 1] 
            int[] un = new int[n];

            // Last element will have no unique elements 
            // after it 
            un[n - 1] = 0;

            // To count unique elements after every a[i] 
            int count = 0;
            for (int i = n - 1; i > 0; i--)
            {

                // If current element has already been used 
                // i.e. not unique 
                if (visited1.Contains(a[i]))
                    un[i - 1] = count;
                else
                    un[i - 1] = ++count;

                // Set to true if a[i] is visited 
                visited1.Add(a[i]);
            }

            HashSet<int> visited2 = new HashSet<int>();

            // To know which a[i] is already visited 
            int answer = 0;
            for (int i = 0; i < n - 1; i++)
            {

                // If visited, then the pair would 
                // not be unique 
                if (visited2.Contains(a[i]))
                    continue;

                // Calculating total unqiue pairs 
                answer += un[i];

                // Set to true if a[i] is visited 
                visited2.Add(a[i]);
            }
            return answer;
        }

        
        //https://leetcode.com/problems/contiguous-array/description/
        public void LargestSubArrayWithEqual1And0()
        {
            int[] arr = new int[] { 1, 0, 1, 0, 0, 0, 0, 1, 1 };
            LargestSubArrayWithEqual1And0(arr);
        }

        //private void LargestSubArrayWithEqual1And0(int[] arr)
        //{
        //    int start = 0;
        //    int end = arr.Length - 1;
        //    int idx = 0;

        //    Pair[] pairs = new Pair[arr.Length];
        //    int x = arr[0] == 1 ? 1 : 0;
        //    int y = x == 1 ? 0 : 1;

        //    pairs[0] = new Pair(x, y);

        //    for(idx = 1; idx < arr.Length; idx ++)
        //    {
        //        var item = pairs[idx-1];

        //        if (arr[idx] == 1)
        //        {
        //            x = item.X + 1;
        //        }
        //        else
        //        {
        //            y = item.Y + 1;
        //        }

        //        Pair pair = new Pair(x, y);
        //        pairs[idx] = pair;
        //    }

        //    idx = 0;
        //    Pair current = pairs[end];

        //    while(start <= end)
        //    {
        //        if (current.X == current.Y)
        //        {
        //            Console.WriteLine($"{start} - {end}");
        //            return;
        //        }
        //        else if (current.X > current.Y)
        //        {
        //            if (pairs[start].X > 0 && pairs[start].Y ==0)
        //            {
        //                current.X -= pairs[start].X;
        //                start++;
        //            }
        //            else if (pairs[end].X > 0 && pairs[end].Y == 0)
        //            {
        //                current.X -= pairs[end].X;
        //                end--;
        //            }
        //            else
        //            {
        //                current.X -= pairs[start].X;
        //                start++;
        //            }
        //        }
        //        else
        //        {
        //            if (pairs[start].Y > 0 && pairs[start].X == 0)
        //            {
        //                current.Y -= pairs[start].Y;
        //                start++;
        //            }
        //            else if (pairs[end].Y > 0 && pairs[end].X == 0)
        //            {
        //                current.Y -= pairs[end].Y;
        //                end--;
        //            }
        //            else
        //            {
        //                current.Y -= pairs[start].Y;
        //                start++;
        //            }
        //        }
        //    }
        //}

        private int LargestSubArrayWithEqual1And0(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            int zCount = 0;
            int lCount = 0;

            foreach(int i in arr)
            {
                if (i == 0)
                {
                    zCount++;
                }
                else
                {
                    lCount++;
                }
            }

            while (zCount != lCount && left < right)
            {
                if (zCount < lCount)
                {
                    MovePointerAt(arr, 1, ref left, ref right, ref zCount, ref lCount);
                }
                else
                {
                    MovePointerAt(arr, 0, ref left, ref right, ref zCount, ref lCount);
                }
            }

            return right - left;
        }

        private void MovePointerAt(int[] arr, int value, ref int left, ref int right, ref int zCount, ref int lCount)
        {
            if (value == 0)
            {
                if (arr[left] == 0)
                {
                    left++;
                    zCount--;
                    return;
                }
                if (arr[right] == 0)
                {
                    zCount--;
                }
                else
                {
                    lCount--;
                }
                right--;
            }
            else
            {
                if (arr[left] == 1)
                {
                    left++;
                    lCount--;
                    return;
                }
                if (arr[right] == 1)
                {
                    lCount--;
                }
                else
                {
                    zCount--;
                }

                right--;
            }
        }

        /*
         This problem was asked by Facebook.
         Given a circular array, compute its maximum subarray sum in O(n) time.
         For example, given [8, -1, 3, 4], return 15 as we choose the numbers 3, 4, and 8 where the 8 is obtained from wrapping around.
         Given [-4, 5, 1, 0], return 6 as we choose the numbers 5 and 1.
         */

        public void MaxSubCycleArraySum()
        {
            int[] arr = new int[] { 8, -1, 3, 4, -2};
            Console.WriteLine(MaxSubCycleArraySum(arr));
        }

        private int MaxSubCycleArraySum(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            int fullSum = 0;
            int sum = 0;
            int max = 0;


            for(int idx = 0; idx < arr.Length; idx ++)
            {
                fullSum += arr[idx];

                if (arr[idx] + sum < sum)
                {
                    sum = arr[idx];
                }
                else
                {
                    sum += arr[idx];
                }

                if (max < sum)
                {
                    max = sum;
                }
            }

            for (int idx = 0; idx < arr.Length; idx ++)
            {
                if (arr[idx] < 0 && max < fullSum - arr[idx])
                {
                    max = fullSum - arr[idx];
                }
            }

            return max;
        }

        /*
         Given a list of points, a central point, and an integer k, find the nearest k points from the central point.
         For example, given the list of points [(0, 0), (5, 4), (3, 1)], the central point (1, 2), and k = 2, return [(0, 0), (3, 1)].
         */
        public void KClosestPoints()
        {

        }

        private void KClosestPoints(List<Pair> pairs)
        {

            List<Pair> res = new List<Pair>();

        }

        public void NextGreaterElement()
        {
            int[] arr = new int[] { 7, 4, 6, 3, 5, 8, 2, 1};

            NextGreaterElement(arr);
        }

        private void NextGreaterElement(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            Stack<int> stk = new Stack<int>();

            stk.Push(0);

            for(int idx = 1; idx < arr.Length; idx++)
            {
                while (stk.Count > 0 && arr[idx] > arr[stk.Peek()])
                {
                    Console.WriteLine($"Next Greater element of {arr[stk.Peek()]} is {arr[idx]}");
                    stk.Pop();
                }

                stk.Push(idx);
            }

            while (stk.Count > 0)
            {
                Console.WriteLine($"Next greater element of {arr[stk.Pop()]} is 0");
            }
        }

        // https://leetcode.com/problems/repeated-string-match/
        public void RepeatedStringMatch()
        {
            Console.WriteLine(RepeatedStringMatch("abcd", "cdabcdab"));
        }

        private int RepeatedStringMatch(string A, string B)
        {
            Dictionary<char, int> badMatchTable = new Dictionary<char, int>();
            badMatchTable.Add('?', A.Length);

            int idx = 0;

            int count = 1;

            for(idx = 0; idx < A.Length; idx ++)
            {
                badMatchTable.Add(A[idx], A.Length - idx - 1);
            }

            idx = 0;

            while(idx < B.Length)
            {
                if (badMatchTable.ContainsKey(B[idx]))
                {
                    var steps = badMatchTable[B[idx]];
                    idx += steps;

                    if (steps == 0)
                    {
                        count++;
                        idx++;
                    }
                    continue;
                }
                else
                {
                    return -1;
                }
            }

            return count;
        }

        public void BuySell()
        {
            int[] arr = new int[] {2, 1, 4, 3};
            Console.WriteLine(BuySell(arr));
        }

        private int BuySell(int[] arr)
        {
            int buy = 0;
            int profit = 0;

            for(int idx = 1; idx < arr.Length; idx++)
            {
                if (arr[buy] > arr[idx] && idx-buy == 1)
                {
                    buy = idx;
                }
                else
                {
                    if (arr[idx] < arr[idx-1])
                    {
                        profit += arr[idx-1] - buy;
                        buy = idx;
                    }
                }
            }

            if (arr[buy] < arr[arr.Length-1] && buy < arr.Length-1)
            {
                profit += arr[arr.Length - 1] - arr[buy];
            }

            return profit;
        }

        public void WaysToReachDestInArray()
        {
            int[,] arr = new int[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };

            /*
            12369
            12569
            12589
            */

        Console.WriteLine(WaysToReachDestInArray(arr, 0, 0));
        }

        private int WaysToReachDestInArray(int[,] arr, int row, int col)
        {
            int count = 0;

            if (row == arr.GetLength(0)-1 && col == arr.GetLength(1)-1)
            {
                return 1;
            }

            if (row >= arr.GetLength(0) || col >= arr.GetLength(0))
            {
                return 0;
            }

            count += WaysToReachDestInArray(arr, row, col +1);
            count += WaysToReachDestInArray(arr, row + 1, col);

            return count;
        }

        // https://www.geeksforgeeks.org/minimum-number-jumps-reach-endset-2on-solution/
        public void MinStepsToReachEndofArray()
        {
            int[] arr = { 2, 3, 1, 2, 0, 5 };
            Console.WriteLine(MinStepsToReachEndOfArray(arr, 6));
        }

        private int MinStepsToReachEndOfArray(int[] A, int n)
        {
            if (n < 2)
            {
                return 0;
            }

            int level = 0, currentMax = 0, i = 0, nextMax = 0;

            while (currentMax - i + 1 > 0)
            {       //nodes count of current level>0
                level++;
                for (; i <= currentMax; i++)
                {   //traverse current level , and update the max reach of next level
                    nextMax = Math.Max(nextMax, A[i] + i);
                    if (nextMax >= n - 1)
                    {
                        return level;   // if last element is in level+1,  then the min jump=level 
                    }
                }
                currentMax = nextMax;
            }
            return 0;
        }

        private int CreStepsToReachEndOfArray(int[] arr, int n)
        {
            if (arr == null)
            {
                return -1;
            }

            int maxIdx = 0;
            int idx = 0;
            int cur = arr[idx];
            int count = 0;
            int limit = 0;

            while (idx < arr.Length)
            {
                limit = idx + arr[idx];
                cur = idx;
                for (; cur <= limit; cur++)
                {
                    if (maxIdx < arr[cur])
                    {
                        maxIdx = arr[cur];
                    }
                }

                idx = idx + maxIdx;
                maxIdx = 0;
                count++;
            }

            return count;
        }

        public void IteratorCheck()
        {
            List<int> l1 = new List<int>();
            l1.Add(1);
            l1.Add(2);
            l1.Add(3);

            List<int> l2 = new List<int>();
            l2.Add(2);
            l2.Add(1);
            l2.Add(3);
            l2.Add(4);

            List<List<int>> coll = new List<List<int>>();
            coll.Add(l1);
            coll.Add(l2);

            Iterator iterator = new Iterator(coll);

            Console.WriteLine(iterator.Has_Next());
            Console.WriteLine(iterator.Next());// do next here
            iterator.Remove();// do remove here
            Console.WriteLine(iterator.Next());// do next here
            iterator.Remove();// do remove here
            Console.WriteLine(iterator.Next());// do next here
            Console.WriteLine(iterator.Next());// do next here
            iterator.Remove();// do remove here
            iterator.Remove();// do remove here
        }


        public void FirstMissingPositive()
        {
            Console.WriteLine(FirstMissingPositive(new int[] { 1, 2, 0 }));
        }

        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 1;
            }

            int max = nums[0];
            int min = nums[0];

            int originalTotal = nums[0];

            for (int idx = 1; idx < nums.Length; idx++)
            {
                originalTotal += nums[idx];

                if (max < nums[idx])
                {
                    max = nums[idx];
                }

                if (min > nums[0])
                {
                    min = nums[idx];
                }
            }

            if (max < nums.Length)
            {
                return max + 1;
            }

            max = max * (max + 1) / 2;

            if (max == originalTotal)
            {
                return 1;
            }

            return max - originalTotal;

        }

        // https://leetcode.com/problems/bus-routes/description/
        public void BusRoutes()
        {
            int[,] routes = { { 0, 1, 2 }, { 0, 3, 4 }, { 2, 5, 6 }, { 6, 7, 8 } };
            Console.WriteLine(BusRoutes(routes, 0, 7));
        }

        private int BusRoutes(int[,] routes, int start, int dest)
        {
            int destStop = -1;

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            for (int row = 0; row < routes.GetLength(0); row++)
            {
                List<int> busRoutes = null;

                for (int col = 0; col < routes.GetLength(1); col++)
                {
                    var stop = routes[row, col];
                    if (stop == dest)
                    {
                        destStop = row;
                    }

                    if (!map.ContainsKey(stop))
                    {
                        busRoutes = new List<int>();
                        busRoutes.Add(row);

                        map.Add(stop, busRoutes);
                    }
                    else
                    {
                        map[stop].Add(row);
                    }
                }
            }

            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            queue.Enqueue(new KeyValuePair<int, int>(start, 0));
            Dictionary<int, bool> visited = new Dictionary<int, bool>();

            while (queue.Count > 0)
            {
                var stop = queue.Dequeue();
                var busRoute = stop.Value;

                if (stop.Key == dest)
                {
                    return busRoute + 1;
                }

                foreach (int route in map[stop.Key])
                {
                    for (int idx = 0; idx < routes.GetLength(1); idx++)
                    {
                        if (!visited.ContainsKey(routes[route, idx]) || !visited[routes[route, idx]])
                        {
                            visited[routes[route, idx]] = true;

                            queue.Enqueue(new KeyValuePair<int, int>(routes[route, idx], busRoute + 1));
                        }
                    }
                }
            }

            return -1;
        }

        public void Anagram()
        {
            Console.WriteLine("Is Anagram: " + IsAnagram("god", "ogd"));
        }

        private bool IsAnagram(string str1, string str2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (char ch in str1)
            {
                if (!dict.ContainsKey(ch))
                {
                    dict.Add(ch, 1);
                }
                else
                {
                    dict[ch]++;
                }
            }

            foreach (char ch in str2)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch]--;

                    if (dict[ch] == 0)
                    {
                        dict.Remove(ch);
                    }
                }
            }

            return dict.Count == 0;
        }

        public void SubArraySum()
        {
            int[] arr = new int[] { 10, 2, -2, -20, 10 };
            Console.WriteLine(SubarraySum(arr, -10));
        }

        private int SubarraySum(int[] nums, int k)
        {
            int sum = 0, result = 0;
            Dictionary<int, int> preSum = new Dictionary<int, int>();
            preSum.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (preSum.ContainsKey(sum - k))
                {
                    result += 1;
                }
                else
                {
                    preSum[sum] = i;
                }
            }

            return result;
        }


        // https://leetcode.com/problems/sliding-window-maximum/discuss/65884/Java-O(n)-solution-using-deque-with-explanation
        public void SlidingWindow()
        {
            int[] arr = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            SlidingWindow(arr, 3);
        }

        private void SlidingWindow(int[] arr, int k)
        {
            int idx = 0;
            Queue<int> queue = new Queue<int>();
            int[] r = new int[arr.Length - k + 1];
            int ri = 0;

            while (idx < arr.Length)
            {
                while (queue.Count > 0 && queue.Peek() < idx - k + 1)
                {
                    queue.Dequeue();
                }

                while (queue.Count > 0 && arr[queue.Peek()] < arr[idx])
                {
                    queue.Dequeue();
                }

                queue.Enqueue(idx);

                if (idx > k - 1)
                {
                    r[ri++] = arr[queue.Peek()];
                }

                idx++;
            }
        }

        //https://leetcode.com/problems/house-robber-ii/description/
        public void HouseRobber()
        {
            int[] nums = new int[] { 1, 2, 1, 1};
            Console.WriteLine(Rob(nums));
        }

        private int Rob(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int odd = 0;
            int even = 0;

            for (int idx = 0; idx < nums.Length; idx++)
            {
                if (idx % 2 == 0)
                {
                    if (idx != nums.Length - 1)
                    {
                        even += nums[idx];
                    }
                }
                else
                {
                    odd += nums[idx];
                }
            }

            return Math.Max(even, odd);
        }

        public void CanReachEndOfArray()
        {
            int[] arr = new int[] { 2, 0, 1, 0};

            Console.WriteLine(CanReachEndOfArray(arr));
        }

        public bool CanReachEndOfArray(int[] arr)
        {
            int max = arr[0];
            int curMax = 0;
            int idx = 0;
            int curMaxIdx = 0;

            while(idx < arr.Length-1)
            {
                curMax = 0;
                curMaxIdx = 0;

                if (max == 0)
                {
                    return false;
                }

                for(int steps = 1; steps <= max; steps++)
                {
                    if (curMax < arr[steps])
                    {
                        curMax = arr[idx+steps];
                        curMaxIdx = steps;
                    }

                    if (steps + idx >= arr.Length -1)
                    {
                        return true;
                    }
                }

                idx += curMaxIdx;
                max = curMax;
            }

            return idx < arr.Length-1;
        }

        public void NextPermutation()
        {
            int[] arr = new int[] {2, 6, 3, 7, 5, 4 };
            NextPermutation(arr);
        }

        public void NextPermutation(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return;
            }

            int i = nums.Length - 1;

            for (; i >= 1; i--)
            {

                if (nums[i] > nums[i - 1])
                { //find first number which is smaller than it's after number
                    break;
                }
            }

            if (i != 0)
            {
                swap(nums, i - 1); //if the number exist,which means that the nums not like{5,4,3,2,1}
            }

            reverse(nums, i);
        }

        private void swap(int[] a, int i)
        {
            for (int j = a.Length - 1; j > i; j--)
            {
                if (a[j] > a[i])
                {
                    int t = a[j];
                    a[j] = a[i];
                    a[i] = t;
                    break;
                }
            }
        }

        private void reverse(int[] a, int i)
        {//reverse the number after the number we have found
            int first = i;
            int last = a.Length - 1;
            while (first < last)
            {
                int t = a[first];
                a[first] = a[last];
                a[last] = t;
                first++;
                last--;
            }
        }


        //https://leetcode.com/problems/remove-duplicate-letters/description/
        public void RemoveDuplicateLetters()
        {
            string str = "cbacdcbc";
            Console.WriteLine(RemoveDuplicateLetters(str));
        }

        private string RemoveDuplicateLetters(string str)
        {
            List<char> list = new List<char>();

            for(int idx = 0; idx < str.Length; idx++)
            {
                if (list.Contains(str[idx]))
                {
                    int listIdx = list.IndexOf(str[idx]);

                    if ((idx -1 > 0 && list.ElementAtOrDefault(idx-1) < str[idx])  && !(listIdx - 1 > 0 && list.ElementAt(listIdx) > list.ElementAt(listIdx - 1)) || (listIdx -1 > 0 && list.ElementAt(listIdx) > list.ElementAt(listIdx-1)))
                    {
                        list.Remove(str[idx]);
                        list.Add(str[idx]);
                    }
                }
                else
                {
                    list.Add(str[idx]);
                }
            }

            StringBuilder res = new StringBuilder();
            foreach(char ch in list)
            {
                res.Append(ch);
            }

            return res.ToString();
        }

        public class RandomizedSet
        {
            List<int> list = null;
            Dictionary<int, int> dict = null;


            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                list = new List<int>();
                dict = new Dictionary<int, int>();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (list.Contains(val))
                {
                    return false;
                }

                list.Add(val);
                int idx = list.Count - 1;
                dict.Add(val, idx);
                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!list.Contains(val))
                {
                    return false;
                }

                if (list.Count > 1)
                {
                    int idx = dict[val];
                    int lastItem = dict.Last().Key;
                    int lastValue = dict.Last().Value;
                    dict.Remove(val);
                    dict.Remove(lastItem);

                    list[idx] = lastItem;
                    list.RemoveAt(list.Count-1);
                    dict.Add(lastItem, idx);
                }
                else
                {
                    list.Remove(0);
                    dict.Remove(val);
                }

                return true;
            }
            
            /** Get a random element from the set. */
            public int GetRandom()
            {
                Random r = new Random();
                int random = r.Next(list.Count - 1);
                return list[random];
            }
        }

        public void MaxKNumbers()
        {
            int[] arr = new int[] {10, 5, 2, 7, 8, 7};
            MaxKNumbers(arr, 3);
        }

        private void MaxKNumbers(int[] arr, int k)
        {
            int pMax = -1, sMax = -1;
            int idx = 0;

            while(idx < k)
            {
                if (pMax == -1 && pMax < arr[idx])
                {
                    pMax = arr[idx];
                }
                else if (pMax < arr[idx])
                {
                    sMax = pMax;
                    pMax = arr[idx];
                }
                else
                {
                    if (sMax < arr[idx])
                    {
                        sMax = arr[idx];
                    }
                }

                idx++;
            }

            while (idx < arr.Length)
            {
                Console.WriteLine(pMax.ToString());
                
                if (pMax == arr[idx-k])
                {
                    pMax = sMax;
                }

                if (pMax < arr[idx])
                {
                    sMax = pMax;
                    pMax = arr[idx];
                }

                idx++;
            }
        }

        public void BackspaceCompare()
        {
            Console.WriteLine(BackspaceCompare("ab##", "c#d#"));
        }

        private bool BackspaceCompare(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2))
            {
                return true;
            }
            else if (string.IsNullOrEmpty(str1))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(str2))
            {
                return false;
            }

            int skip1 = 0;
            int skip2 = 0;
            int idx1 = str1.Length - 1, idx2 = str2.Length - 1;

            while (idx1 >= 0 || idx2 >= 0)
            {
                while (idx1 >=0 && str1[idx1] == '#')
                {
                    skip1++;
                    idx1--;
                }

                while (idx2>=0 && str2[idx2] == '#')
                {
                    idx2--;
                    skip2++;
                }

                if (skip1 > 0)
                {
                    idx1 -= skip1;
                    skip1 = 0;
                }
                if (skip2 > 0)
                {
                    idx2 -= skip2;
                    skip2 = 0;
                }

                if (idx1 >= 0 && idx2 >= 0 && str1[idx1] != '#' && str2[idx2] != '#')
                {
                    if (str1[idx1] != str2[idx2])
                    {
                        return false;
                    }
                    else
                    {
                        idx1--;
                        idx2--;
                    }
                }
            }

            return (idx1 == -1 && idx2 == -1);

        }

        public void TripletSum()
        {
            int[] arr = new int[] { -1, 2, 3, 5, 8 };
            TripletSum(arr, 5);
        }

        private void TripletSum(int[] arr, int desiredSum)
        {
            int fix = 0;
            int start = fix + 1;
            int end = arr.Length-1;
            int diff = int.MaxValue;

            int first = 0, second = 0, third = 0;
            while (fix < start)
            {
                start = fix + 1;
                end = arr.Length - 1;

                while (start < end)
                {
                    var total = arr[fix] + arr[start] + arr[end];

                    if (Math.Abs(total - desiredSum) < diff)
                    {
                        diff = Math.Abs(total - desiredSum);
                        first = arr[fix];
                        second = arr[start];
                        third = arr[end];
                    }

                    if (total > desiredSum)
                    {
                        end--;
                    }
                    else
                    {
                        start++;
                    }
                }

                fix++;
            }

            Console.WriteLine($"{first}, {second}, {third}");

        }

        public void ValidateParanthesis()
        {
            Console.WriteLine(ValidateParanthesis("([])[]({})"));
        }

        private bool ValidateParanthesis(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            Stack<char> stk = new Stack<char>();

            foreach(char ch in str)
            {
                if (IsOpenBrace(ch))
                {
                    stk.Push(ch);
                }
                else
                {
                    var brace = stk.Peek();

                    if (IsClosingBrace(brace, ch))
                    {
                        stk.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stk.Count == 0;
        }

        private bool IsOpenBrace(char ch)
        {
            switch(ch)
            {
                case '(':
                    return true;
                case '{':
                    return true;
                case '[':
                    return true;
                default:
                    return false;
            }
        }

        private bool IsClosingBrace(char open, char close)
        {
            if (open == '(' && close == ')')
            {
                return true;
            }
            else if (open == '{' && close == '}')
            {
                return true;
            }
            else if (open == '[' && close == ']')
            {
                return true;
            }
            return false;
        }

        public void MountainArray()
        {
            int[] arr = new int[] {3, 2, 1};

            Console.WriteLine(MountainArray(arr));
        }

        private bool MountainArray(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }

            int mIdx = 1;
            int idx = 0;
            bool res = false;

            if (arr[mIdx] < arr[idx])
            {
                return false;
            }

            while(mIdx < arr.Length && arr[mIdx] > arr[idx])
            {
                res = true;
                mIdx++;
                idx++;
            }

            if (mIdx == arr.Length || !res)
            {
                return false;
            }

            mIdx--;
            idx++;

            while(idx < arr.Length && arr[mIdx] > arr[idx])
            {
                idx++;
            }

            return idx == arr.Length;
        }

        //TBD: Fails a testcase in leetcode, as HashSet doesn't gurantee sequence of items
        // https://leetcode.com/problems/fruit-into-baskets/
        public void TotalFruit()
        {
            Console.WriteLine(TotalFruit(new int[] {1, 0, 3, 4, 3}));
        }

        private int TotalFruit(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            HashSet<int> set = new HashSet<int>();

            int idx = 0;
            int collect = 0;
            int max = 0;
            int k = 2;

            while (idx < arr.Length)
            {
                if (set.Count == k && !set.Contains(arr[idx]))
                {
                    collect = 0;
                    set.Remove(set.FirstOrDefault());
                    idx--;
                }
                else
                {
                    if (idx == 0 || arr[idx] != arr[idx - 1])
                    {
                        set.Add(arr[idx]);
                    }
                }

                collect++;

                if (max < collect)
                {
                    max = collect;
                }

                idx++;
            }

            return max;
        }

        //https://leetcode.com/problems/first-unique-character-in-a-string/
        public void FirstUniqChar()
        {
            Console.WriteLine(FirstUniqChar("leetcode"));
        }

        private int FirstUniqChar(string s)
        {
            int[] arr = new int[26];

            foreach (char ch in s)
            {
                int idx = ch - 'a';
                arr[idx] += 1;
            }

            int i = -1;

            foreach (char ch in s)
            {
                i++;
                int idx = ch - 'a';

                if (arr[idx] == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        public void ReachDestinationInMatrix()
        {
            int[,] arr = new int[,]
            {
                {0, 0, 0, 0 },
                {1, 1, 0, 1 },
                {0, 0, 0, 0 },
                {0, 0, 0, 0 }
            };

            Console.WriteLine(ReachDestinationInMatrix(arr, 3 , 0, new Pair(0, 0), 0));
        }

        private int ReachDestinationInMatrix(int[,] arr, int x, int y, Pair destination, int count)
        {
            if (x == destination.X && y == destination.Y || x ==0 && y ==0)
            {
                return count;
            }

            if (arr[x, y] == 0)
            {
                count++;
            }

            if (x+1 < arr.GetLength(0))
            {
                count = ReachDestinationInMatrix(arr, x + 1, y, destination, count);
            }

            if (y+1 < arr.GetLength(1))
            {
                count = ReachDestinationInMatrix(arr, x, y + 1, destination, count);
            }

            if (x - 1 >= 0)
            {
                count = ReachDestinationInMatrix(arr, x - 1, y, destination, count);
            }

            return count;
        }

        public void NextGreater()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(6);

            var g = nextGreater(list);
        }
        private List<int> nextGreater(List<int> arr)
        {
            int[] res = new int[arr.Count];
            if (arr == null)
            {
                return res.ToList<int>();
            }
            int max = arr[arr.Count - 1];
            int idx = arr.Count - 1;
            res[idx] = -1;
            idx--;
            while (idx >= 0)
            {
                if (arr[idx] < arr[idx + 1])
                {
                    res[idx] = arr[idx + 1];
                    max = arr[idx + 1];
                }
                else
                {
                    if (arr[idx] <= max)
                    {
                        res[idx] = max;
                    }
                    else
                    {
                        res[idx] = -1;
                        max = arr[idx];
                    }
                }
                idx--;
            }

            return res.ToList<int>();
        }

        //https://www.interviewbit.com/problems/n-max-pair-combinations/
        public void MaxPairCombinations()
        {
            List<int> A = new List<int>();
            //A.Add(1);
            //A.Add(4);
            //A.Add(2);
            //A.Add(3);
            A.Add(3);
            A.Add(4);

            List<int> B = new List<int>();
            //B.Add(1);
            //B.Add(2);
            //B.Add(5);
            //B.Add(6);
            B.Add(3);
            B.Add(4);

            var pair = MaxPairCombinations(A, B);
        }

        private List<int> MaxPairCombinations(List<int> A, List<int> B)
        {
            List<int> res = new List<int>();

            if (A == null && B == null)
            {
                return res;
            }
            else if (A == null)
            {
                return B;
            }
            else if (B == null)
            {
                return A;
            }

            A.Sort();
            B.Sort();

            int aIdx = A.Count - 1;
            int bIdx = B.Count - 1;
            int idx = 1;

            while (res.Count <= B.Count /2)
            {
                while ( aIdx >= A.Count /2)
                {
                    int count = A[aIdx] + B[bIdx];
                    res.Add(count);
                    aIdx--;
                    idx++;
                }

                aIdx = A.Count - 1;
                bIdx--;
            }

            return res;
        }

    // https://leetcode.com/problems/jump-game-ii/description/
    public void JumpGame()
        {
            int[] arr = new int[] { 2, 3, 1, 1, 4 };
            Console.WriteLine(JumpGame(arr));
        }

        private int JumpGame(int[] arr)
        {
            if (arr == null)
            {
                return -1;
            }

            int max = arr[0];
            int count = 1;
            int step = 0;
            int curMax = arr[0];
            int idx = 0;

            while(idx < arr.Length)
            {
                if (count >= arr.Length-1)
                {
                    return step;
                }

                step++;
                curMax = max;
                max = -1;

                while (count <= arr[curMax])
                {
                    if (count >= arr.Length-1)
                    {
                        return step;
                    }

                    max = max == -1 || arr[max] < arr[count] ? count : max;
                    count++;
                }

                idx = max;
            }

            return -1;
        }

        // https://www.geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value/
        public void MinSubArrayWithGreaterVal()
        {
            int[] arr = new int[] { 2, -1, 2 };
            Console.WriteLine(MinSubArrayWithGreaterVal(arr, 3));
        }

        private int MinSubArrayWithGreaterVal(int[] arr, int val)
        {
            if (arr == null)
            {
                return -1;
            }

            int idx = 0, minLength = int.MaxValue, sum = 0;
            Queue<int> queue = new Queue<int>();

            while (idx < arr.Length)
            {
                if (idx > 1 && arr[idx] > sum && sum < 0)
                {
                    queue.Clear();
                    sum = 0;
                }

                sum += arr[idx];
                queue.Enqueue(idx);

                while (sum >= val || (queue.Count > 0 && sum < val && arr[queue.Peek()] < 0 && sum - arr[queue.Peek()] >= val))
                {
                    if (minLength > queue.Count)
                    {
                        minLength = queue.Count;
                    }

                    var first = queue.Dequeue();
                    sum -= arr[first];
                }

                idx++;
            }

            return minLength;
        }

        public void HotelBookRoom()
        {

        }

        private int HotelBookRoom(List<Pair> pairs)
        {
            int count = 0;
            int idx = 0;

            while (pairs.Count > 0)
            {
                var item = pairs[idx];

                while (pairs.Count > 0 && ++idx < pairs.Count)
                {
                    if (pairs[idx].X >= item.Y)
                    {
                        idx++;
                        break;
                    }
                }
            }

            return count = pairs.Count - idx;
        }

        public void TrapWater()
        {
            int[] arr = { 1,0,3,2,1,0, 2, 4 };
            Console.WriteLine(TrapWater(arr));
        }

        private int TrapWater(int[] arr)
        {
            int[] left = new int[arr.Length];
            int[] right = new int[arr.Length];
            int trap = 0;
            int idx = 1;
            left[0] = arr[0];

            while (idx < arr.Length)
            {
                left[idx] = Math.Max(left[idx - 1], arr[idx]);
                idx++;
            }

            idx = arr.Length - 2;
            right[arr.Length - 1] = arr[arr.Length - 1];

            while (idx >= 0)
            {
                right[idx] = Math.Max(right[idx + 1], arr[idx]);
                idx--;
            }

            for (idx = 1; idx < arr.Length; idx++)
            {
                trap += Math.Min(left[idx], right[idx]) - arr[idx];
            }

            return trap;
        }

        public void FindMaxContinousSequence()
        {
            List<int> list = new List<int>();
            list.Add(23);
            list.Add(7);
            list.Add(10);
            list.Add(24);
            list.Add(6);
            list.Add(22);
            list.Add(21);

            var res = FindMaxContinousSequence(list);
        }

        private List<int> FindMaxContinousSequence(List<int> list)
        {
            List<int> res = new List<int>();
            if (list == null || list.Count == 0)
            {
                return res;
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int val in list)
            {
                if (dict.ContainsKey(val))
                {
                    dict[val]++;
                }
                else
                {
                    dict.Add(val, 1);
                }
            }

            for(int idx = 0; idx < list.Count; idx ++)
            {
                if (dict.ContainsKey(list[idx]))
                {
                    var cur = FindList(list, dict, idx);
                    if (cur.Count > res.Count)
                    {
                        res = cur;
                    }
                }
            }

            return res;
        }

        private List<int> FindList(List<int> list, Dictionary<int, int> dict, int idx)
        {
            var item = list[idx];
            int preIdx = 1;
            int postIdx = 1;

            List<int> res = new List<int>();

            while(dict.ContainsKey(item-preIdx))
            {
                var val = dict[item - preIdx];

                for(int i = 1; i <=val; i++)
                {
                    res.Add(item - preIdx);
                }

                dict.Remove(item-preIdx);

                preIdx++;
            }

            res.Add(item);
            dict.Remove(item);
            while (dict.ContainsKey(item + postIdx))
            {
                var val = dict[item + postIdx];

                for (int i = 1; i <= val; i++)
                {
                    res.Add(item + postIdx);
                }

                dict.Remove(item + postIdx);

                postIdx++;
            }

            return res;
        }

        // https://leetcode.com/problems/median-of-two-sorted-arrays/discuss/
        public void MedianOfSortedArrays()
        {
            int[] arr1 = new int[] { 2, 4, 6, 7, 8 };
            int[] arr2 = new int[] { 1, 3, 9, 10 };

            Console.WriteLine(MedianOfSortedArrays(arr1, arr2, 3));
        }

        private double MedianOfSortedArrays(int[] arr1, int[] arr2, int k)
        {
            if (arr1.Length > arr2.Length)
            {
                return MedianOfSortedArrays(arr2, arr1, k);
            }

            int x = arr1.Length;
            int y = arr2.Length;

            int low = 0;
            int high = x;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                int maxLeftX = partitionX == 0 ? int.MinValue : arr1[partitionX - 1];
                int minRightX = partitionX == x ? int.MaxValue : arr1[partitionX];

                int maxLeftY = partitionY == 0 ? int.MinValue : arr2[partitionY - 1];
                int minRightY = partitionY == y ? int.MaxValue : arr2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {

                    if ((x + y) % 2 == 0)
                    {
                        return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    else
                    {
                        return Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                {
                    high = partitionX - 1;
                }
                else
                {
                    low = partitionX + 1;
                }
            }

            throw new Exception("error");
        }

        // TODO
        /*
         Given a string, split it into as few strings as possible such that each string is a palindrome.
         For example, given the input string racecarannakayak, return ["racecar", "anna", "kayak"].
         */

        /*
         Given an array of positive integers, divide the array into two subsets such that the difference between the sum of the subsets is as small as possible.
        For example, given [5, 10, 15, 20, 25], return the sets {10, 25} and {5, 15, 20}, which has a difference of 5, which is the smallest possible difference.
         */
        public void SubsetDiff()
        {
            int[] arr = { 5, 10, 15, 20, 25 };
            Console.WriteLine(SubsetDiff(arr, 0, 75, 75, 0));
        }

        private int SubsetDiff(int[] arr, int sum, int total, int diff, int idx)
        {
            if (idx >= arr.Length)
            {
                return diff;
            }

            if (diff > (Math.Abs((total - sum)- sum)))
            {
                diff = Math.Abs((total - sum) - sum);
            }

            if (idx + 1 < arr.Length)
            {
                diff = SubsetDiff(arr, sum + arr[idx + 1], total, diff, idx + 1);
                diff = SubsetDiff(arr, sum, total, diff, idx + 1);
            }

            return diff;
        }

        public void QuickSortIteratively()
        {
            int[] arr = new int[] { 8, 3, 4, 2, 10, 7, 9 };
            QuickSortIteratively(arr, 0, arr.Length - 1);
        }

        private void QuickSortIteratively(int[] arr, int start, int end)
        {
            if (arr == null)
            {
                return;
            }

            if (start < end)
            {
                int p = Partition(arr, start, end);
                QuickSortIteratively(arr, start, p);
                QuickSortIteratively(arr, p + 1, end);
            }
        }

        private int Partition(int[] arr, int l, int h)
        {
            int x = arr[h];
            int i = (l - 1);

            int bound = 0;
            for (int j = l; j < h; j++)
            {
                if (arr[j] < x && j > bound)
                {
                    bound++;
                    Swap(arr, j, bound);
                }
            }

            Swap(arr, bound + 1, h);
            return bound + 1;
        }

        // TBD
        //https://leetcode.com/interview/1/
        public void DuplicateZeros()
        {
            int[] arr = new int[] {1, 2, 3 };
            int count = 0;

            for (int idx = 0; idx < arr.Length; idx++)
            {
                if (arr[idx] == 0)
                {
                    count++;
                }
            }

            int rIdx = arr.Length - count;
            int i = arr.Length - 1;

            while(i > -1 && rIdx >-1 && rIdx < arr.Length)
            {
                if (arr[rIdx] == 0)
                {
                    arr[i--] = 0;
                    arr[i] = 0;
                }
                else
                {
                    arr[i] = arr[rIdx];
                }

                i--;
                rIdx--;
            }
        }

        public void CopyMatrixSpirallyToArray()
        {
            int[,] arr = new int[,]
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };

            var res = SpiralCopy(arr);
        }

        public static int[] SpiralCopy(int[,] inputMatrix)
        {
            int bound = (inputMatrix.GetLength(0) * inputMatrix.GetLength(1));
            int[] res = new int[bound];
            int row = 0, col = 0;
            int idx = 0;
            int rowUBound = inputMatrix.GetLength(0);
            int colUBound = inputMatrix.GetLength(1);
            int rowLBound = 0;
            int colLBound = 0;

            Console.WriteLine($"bound:{bound}");
            rowLBound = 1;
            while (idx < bound)
            {
                while (col < colUBound && idx < bound)
                {
                    Console.WriteLine($"col++ :{col}");
                    res[idx++] = inputMatrix[row, col];
                    col++;
                }
                col--;
                colUBound--;
                row += 1;

                while (row < rowUBound && idx < bound)
                {
                    Console.WriteLine($"row++ :{row}");
                    res[idx++] = inputMatrix[row, col];
                    row++;
                }

                row--;
                rowUBound--;
                col -= 1;

                Console.WriteLine($"col-- :{col}");
                while (col >= colLBound && idx < bound)
                {
                    res[idx++] = inputMatrix[row, col];
                    col--;
                }

                col++;
                colLBound++;
                row -= 1;

                while (row >= rowLBound && idx < bound)
                {
                    Console.WriteLine($"row++ :{row}");
                    res[idx] = inputMatrix[row, col];
                    idx++;
                    row--;
                }

                row++;
                rowLBound++;
                col += 1;
            }

            return res;
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }

        public void FindArrayBounds()
        {
            int[] arr = new int[10];
            FindArrayBounds(arr, 4);
        }

        private void FindArrayBounds(int[] arr, int gIdx)
        {
            int start = gIdx;
            int end = gIdx;
            int lastFailedIndex = 0;

            GetBoundsRecursively(arr, ref start, ref end, ref lastFailedIndex);
        }

        private bool GetBoundsRecursively(int[] arr, ref int start, ref int end, ref int lastFailedIndex)
        {
            bool ret = false;
            try
            {

                var item = arr[end];

                if (lastFailedIndex - end == 1)
                {
                    return true;
                }

                if (lastFailedIndex == 0)
                {
                    start = end;
                    end = end * 2;
                }
                else
                {
                    end = (start + lastFailedIndex - 1) / 2;
                }

                ret = GetBoundsRecursively(arr, ref start, ref end, ref lastFailedIndex);

                while (!ret)
                {
                    end = (start + lastFailedIndex) / 2;
                    ret = GetBoundsRecursively(arr, ref start, ref end, ref lastFailedIndex);
                }
            }

            catch (IndexOutOfRangeException)
            {
                lastFailedIndex = end;
            }

            return ret;
        }

        // https://leetcode.com/problems/valid-sudoku/discuss/15472/Short+Simple-Java-using-Strings
        // https://leetcode.com/problems/valid-sudoku/discuss/15450/Shared-my-concise-Java-code
        public void IsValidSudoKu()
        {
            string[,] arr = new string[,]
            {
             {"8", "3", ".", ".", "7", ".", ".", ".", "."},

             { "6", ".", ".", "1", "9", "5", ".", ".", "."},

             { ".", "9", "8", ".", ".", ".", ".", "6", "."},
             { "8", ".", ".", ".", "6", ".", ".", ".", "3"},

             { "4", ".", ".", "8", ".", "3", ".", ".", "1"},

             { "7", ".", ".", ".", "2", ".", ".", ".", "6"},

             { ".", "6", ".", ".", ".", ".", "2", "8", "."},

             { ".", ".", ".", "4", "1", "9", ".", ".", "5"},

             { ".", ".", ".", ".", "8", ".", ".", "7", "9"}

            };

            Console.WriteLine(IsValidSudoKu(arr));
    }

        public bool IsValidSudoKu(string[,] board)
        {
            var seen = new HashSet<string>();
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    if (board[i,j] != ".")
                    {
                        String b = "(" + board[i,j] + ")";
                        if (!seen.Add(b + i) || !seen.Add(j + b) || !seen.Add(i / 3 + b + j / 3))
                            return false;
                    }
                }
            }
            return true;
        }

        public void FindMissingnumber()
        {
            int[] arr = new int[] { 3};
            Console.WriteLine(FindMissingPositiveNumber(arr));
        }

        private int FindMissingPositiveNumber(int[] arr)
        {
            int big = 0;
            int actual = 0;

            foreach(int num in arr)
            {
                if (num < 0)
                {
                    continue;
                }

                actual += num;

                if (num > big)
                {
                    big = num;
                }
            }

            var sum = (big * (big + 1)) / 2;
            return sum - actual == 0 ? big + 1 : sum - actual;
        }

        //https://leetcode.com/explore/interview/card/apple/347/dynamic-programming/3137/
        public void WordBreak()
        {
            string str = "catsandog";
            HashSet<string> set = new HashSet<string>();
            set.Add("cats");
            set.Add("dog");
            set.Add("sand");
            set.Add("and");
            set.Add("cat");

            Console.WriteLine(WordBreak(str, set));
        }

        private bool WordBreak(string input, HashSet<string> words)
        {
            Stack<Pair> stk = new Stack<Pair>();

            for(int i = 0; i < input.Length; i ++)
            {
                for(int j = 1; i + j + 1< input.Length; j ++)
                {
                    if (words.Contains(input.Substring(i, j)))
                    {
                        if (i + j == input.Length)
                        {
                            return true;
                        }

                        stk.Push(new Pair(i, j));
                        i = i + j - 1;
                        break;
                    }
                    if (i + j +1 == input.Length && stk.Count > 0)
                    {
                        var cur = stk.Pop();
                        i = cur.X;
                        j = cur.Y;
                    }
                    else if (i == input.Length && j == input.Length)
                    {
                        return false;
                    }
                }
            }

            return stk.Count > 0;
        }

        public void MinWindowSubString()
        {

        }

        public void MinWindowSubString(string s, string t)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            for(int idx = 0; idx < s.Length; idx ++)
            {

            }
        }

        //private Indices FillMap(Dictionary<char, int> map, string s, int idx, ref int length)
        //{
        //    if (map[s[idx]] == 0)
        //    {
        //        length -= 1;
        //    }

        //    map[s[idx]] = idx;

        //    if (length == 0)
        //    {
        //        length = map.Count;

        //    }
        //}

        private class MapIndices
        {
            public int Start;
            public int End;

            private Dictionary<char, int> map = new Dictionary<char, int>();
            //public MapIndices(Dictionary<char, int> map)
            //{
            //    Start = map.ElementAt(0).Value;
            //    End = map.ElementAt(0).Value;

            //    foreach(KeyValuePair<char, int> pair in map)
            //    {
            //        if (Start > pair.Value)
            //        {
            //            Start = pair.Value;
            //        }

            //        if (End < pair.Value)
            //        {
            //            End = pair.Value;
            //        }
            //    }
            //}

            public void Add(string s, int idx)
            {
                if (map[s[idx]] != 0)
                {
                    if (Start > idx)
                    {
                        Start = idx;
                    }

                    if (End < idx)
                    {
                        End = idx;
                    }
                }
            }
        }

        // https://www.geeksforgeeks.org/previous-greater-element/
        public void PreviousGreaterElement()
        {
            int[] arr = new int[] {10, 4, 2, 20, 40, 12, 30 };

            var res = PreviousGreaterElement(arr);
        }

        private int[] PreviousGreaterElement(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }

            int[] res = new int[arr.Length];
            Stack<int> stk = new Stack<int>();

            for (int idx = 0; idx < arr.Length; idx++)
            {
                while (stk.Count > 0)
                {
                    if (stk.Peek() < arr[idx])
                    {
                        stk.Pop();
                    }
                    else
                    {
                        break;
                    }
                }

                if (stk.Count > 0)
                {
                    res[idx] = stk.Peek();
                }
                else
                {
                    res[idx] = -1;
                }

                stk.Push(arr[idx]);
            }

            return res;
        }

        public void PancakeSort()
        {
            int[] arr = new int[] { 1, 5, 4, 2};
            PancakeSort(arr);
        }

        public int[] PancakeSort(int[] arr)
        {
            int start = 0, end = arr.Length - 1;

            int pos = 0;

            while (start < end)
            {
                pos = FindPosOfMax(arr, end);

                if (pos == end)
                {
                    end--;
                }
                else
                {
                    Flip(arr, pos);
                    if (pos != end)
                    {
                        Flip(arr, end);
                    }
                    end--;
                }
            }

         return arr;
        }

        private void Flip(int[] arr, int k)
        {
            int count = k;
            int idx = 0;
            while (idx < count)
            {
                int temp = arr[idx];
                arr[idx] = arr[count];
                arr[count] = temp;
                count--;
                idx++;
            }
        }

        private int FindPosOfMax(int[] arr, int end)
        {
            int idx = 1;
            int max = arr[0];
            int pos = 0;

            while (idx <= end)
            {
                if (max < arr[idx])
                {
                    max = arr[idx];
                    pos = idx;
                }

                idx++;
            }

            return pos;
        }

        // https://leetcode.com/problems/course-schedule-iii/discuss/104845/Short-Java-code-using-PriorityQueue
        public void CourseScheduling()
        {
            int[,] courses = new int[4, 2]
            {
                { 100, 200},
                { 200, 1300},
                { 1000, 1250},
                { 2000, 3200}
            };

            CourseScheduling(courses);
        }

        private void CourseScheduling(int[,] courses)
        {
            // courses.OrderBy()
            Array.Sort(courses, new SortedComparer());
        }

        // https://leetcode.com/problems/redundant-connection-ii/description/
        public void RedundantConnection()
        {
            int[,] arr = new int[,]
            {
                { 4, 2},
                { 1, 5},
                { 5, 2},
                // { 5, 3},
                { 2, 4}
            };

            RedundantConnection(arr);
        }

        private void RedundantConnection(int[,] arr)
        {
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            int col = 0;
            for(int row = 0; row < arr.GetLength(0); row ++)
            {
                if (map.ContainsKey(arr[row, col]))
                {
                    map[arr[row, col]] = true;
                }
                else
                {
                    map.Add(arr[row, col], false);
                }
            }

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                if (map[arr[row, col]] == false)
                {
                    var link = arr[row, 1];
                    if (map[link] == true)
                    {
                        Console.WriteLine($" arr[{arr[row,col]}, {arr[row,1]}]");
                    }
                }
            }
        }

        public void MaximumSubArraySum()
        {
            int[] arr = new int[] { 1, -3, 2, 1, -1 };

            Console.WriteLine(MaximumSubArraySum(arr));
        }

        private int MaximumSubArraySum(int[] arr)
        {
            int max = int.MinValue;
            int sum = 0;

            for(int idx = 0; idx < arr.Length; idx ++)
            {
                if (sum + arr[idx] < arr[idx])
                {
                    sum = arr[idx];
                }
                else
                {
                    sum += arr[idx];
                }

                if (max < sum)
                {
                    max = sum;
                }
            }
            return max;
        }

        public void SearchInRotatedSortedArray()
        {
            int[] arr = new int[] { 9, 12, 13, 16, 1, 2, 3, 4};
            Console.WriteLine(SearchInRotatedSortdArray(arr, 0, arr.Length - 1, 12));
        }

        private int SearchInRotatedSortdArray(int[] arr, int start, int end, int num)
        {
            int res = -1;

            if (end - start == 1)
            {
                res = arr[end] == num ? end : start;
                return start;
            }

            int mid = (start + end) / 2;

            if (num < arr[mid] && num >= arr[start])
            {
                res = SearchInRotatedSortdArray(arr, start, mid, num);
            }
            else
            {
                res = SearchInRotatedSortdArray(arr, mid, end, num);
            }

            return res;
        }

        //https://leetcode.com/explore/featured/card/google/59/array-and-strings/3053/
        public void CanJump()
        {
            int[] arr = new int[] {3, 2, 1, 0, 4 };
            Console.WriteLine(CanJump(arr));
        }

        public bool CanJump(int[] nums)
        {
            if (nums == null || nums.Length == 1)
            {
                return true;
            }

            int curMax = nums[0];
            int idx = 1;
            int nextMax = 0;

            while(curMax - idx + 1 > 0)
            {
                for(;idx <= curMax; idx++)
                {
                    nextMax = Math.Max(nextMax, nums[idx] + idx);
                    if (nextMax >= nums.Length-1)
                    {
                        return true;
                    }
                }

                curMax = nextMax;
            }

            return false;
        }

        //https://leetcode.com/discuss/interview-question/306859/google-phone-screen-split-strings-to-form-a-palindrome
        public void SplitStringToFormPalindrome()
        {
            Console.WriteLine(SplitStringToFormPalindrome("fbcbbbb", "xxxbcba"));
        }

        private bool SplitStringToFormPalindrome(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                throw new ArgumentNullException("Input cannot be null");
            }

            bool result = CanSplitStringToFormPalindrome(s1, s2);
            if (!result)
            {
                result = CanSplitStringToFormPalindrome(s2, s1);
            }

            return result;
        }

        private bool CanSplitStringToFormPalindrome(string s1, string s2)
        {
            int idx1 = 0; int idx2 = s2.Length - 1;
            bool result = false;

            while (idx1 < s1.Length && idx2 >= 0)
            {
                if (s1[idx1++] == s2[idx2--])
                {
                    result = true;
                }
                else if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return result;
        }

        public void CompressString()
        {
            Console.WriteLine(CompressString("aaabbcd"));
        }

        private char[] CompressString(string str)
        {
            int cIdx = 0;
            int rIdx = -1;
            int idx = 1;
            int count = 1;

            char[] arr = str.ToArray();

            while (idx < arr.Length)
            {
                while (arr[cIdx] == arr[idx])
                {
                    count ++;

                    if (rIdx == -1)
                    {
                        rIdx = cIdx + 1;
                    }
                    idx++;
                }

                if (rIdx > -1)
                {
                    arr[rIdx] = (char)count;
                    cIdx = rIdx + 1;
                    rIdx = -1;
                    arr[cIdx] = arr[idx++];
                    count = 1;
                }
                else
                {
                    arr[++cIdx] = arr[idx++];
                }
            }

            return arr;
        }

        public void MaxProfit2Transactions()
        {
            int[] arr = new int[] { 3, 3, 5, 0, 0, 3, 1, 4 };
            Console.WriteLine(MaxProfit2Transactions(arr));
        }

        private int MaxProfit2Transactions(int[] arr)
        {
            int buy1 = -int.MaxValue;
            int buy2 = -int.MaxValue;
            int sell1 = int.MinValue;
            int sell2 = int.MinValue;

            int idx = 0;

            while(idx < arr.Length)
            {
                buy1 = Math.Max(buy1, -arr[idx]);
                sell1 = Math.Max(sell1, buy1 + arr[idx]);
                buy2 = Math.Max(buy2, sell1-arr[idx]);
                sell2 = Math.Max(sell2, buy2 + arr[idx]);

                idx++;
            }

            return sell2;
        }

        public void FindRectangleWithzeros()
        {
            var image1 = new int[,]
        {
          {1, 1, 1, 1, 1, 1, 1},
          {1, 1, 1, 1, 1, 1, 1},
          {1, 1, 1, 0, 0, 0, 1},
          {1, 1, 1, 0, 0, 0, 1},
          {1, 1, 1, 1, 1, 1, 1}
        };

            var res = FindRectangleWithzeros(image1);

            foreach(Pair pair in res)
            {
                Console.WriteLine($"{pair.X} {pair.Y}");
            }
        }

        private List<Pair> FindRectangleWithzeros(int[,] arr)
        {
            for(int row = 0; row < arr.GetLength(0); row++)
            {
                for(int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        Pair pair = new Pair(row, col);

                        while(arr[row, col] == 0)
                        {
                            if (arr.GetLength(0) > row + 1 && arr[row+1, col] == 0)
                            {
                                row++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        return FindRect(pair, row, arr);
                    }
                }
            }

            return null;
        }

        private List<Pair> FindRect(Pair pair, int r, int[,] arr)
        {
            int col = pair.Y;

            for(int pairCol = pair.Y; pairCol < arr.GetLength(1); pairCol++)
            {
                if (arr[r, col] == 1)
                {
                    col = pairCol -1;
                    break;
                }
                col = pairCol;
            }

            Pair end = new Pair(r, col);

            List<Pair> res = new List<Pair>();
            res.Add(pair);
            res.Add(end);

            return res;
        }

        // ** brilliant **
        // https://leetcode.com/problems/flip-string-to-monotone-increasing/discuss/183896/Prefix-Suffix-Java-O(N)-One-Pass-Solution-Space-O(1)
        public void MinflipsToMonotonicallyIncreasingSeq()
        {
            Console.WriteLine(MinflipsToMonotonicallyIncreasingSeq("001001011"));
        }

        public int MinflipsToMonotonicallyIncreasingSeq(String S)
        {
            if (S == null || S.Length <= 0)
                return 0;

            char[] sChars = S.ToCharArray();
            int flipCount = 0;
            int onesCount = 0;

            for (int i = 0; i < sChars.Length; i++)
            {
                if (sChars[i] == '0')
                {
                    if (onesCount == 0) continue;
                    else flipCount++;
                }
                else
                {
                    onesCount++;
                }
                if (flipCount > onesCount)
                {
                    flipCount = onesCount;
                }
            }
            return flipCount;
        }


        private class SortedComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var first = (int[])x;
                var second = (int[])y;

                return first[1] - second[1];
            }
        }

        public class Iterator
        {
            List<List<int>> coll = new List<List<int>>();
            List<int> cur;
            int idx = 0;
            int cIdx = -1;
            bool hasNext = false; 

            public Iterator(List<List<int>> list)
            {
                coll = list;
                cur = coll[0];
            }

            public bool Has_Next()
            {
                if (cur.Count == cIdx)
                {
                    if (idx+1 == coll.Count && coll.Count == 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            public int Next()
            {
                cIdx++;

                if (cIdx == cur.Count)
                {
                    idx++;
                    cur = coll[idx];
                    cIdx = 0;
                }

                hasNext = true;
                return cur[cIdx];
            }

            public void Remove()
            {
                if (!hasNext)
                {
                    throw new Exception("Remove called before moving to next element");
                }

                coll[idx].RemoveAt(cIdx);
                
                cIdx--;

                if (coll[idx].Count == 0)
                {
                    coll.RemoveAt(idx);
                }

                hasNext = false;
            }
        }
    }
}
