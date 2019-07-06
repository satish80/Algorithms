using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class Stacks
    {

        //TBD
        //https://leetcode.com/problems/maximum-frequency-stack/
        public void MaxFrequencyStack()
        {
            MaxFrequencyStack("5,7,5,7,4,5, , , , ");
        }

        private void MaxFrequencyStack(string input)
        {
            Dictionary<int, Stack<int>> map = new Dictionary<int, Stack<int>>();
            Dictionary<string, int> frequency = new Dictionary<string, int>();
            int highFrequency = 0;

            foreach(string ch in input.Split(','))
            {
                if (ch != string.Empty)
                {
                    if (!frequency.ContainsKey(ch))
                    {
                        frequency.Add(ch, 1);
                    }
                    else
                    {
                        frequency[ch] += 1;
                        if (!map.ContainsKey(frequency[ch]))
                        {
                            var stk = new Stack<int>();
                            map.Add(frequency[ch], stk);
                            //stk.Push((int)ch);
                            highFrequency += 1;
                        }
                    }
                }
                else
                {
                    Stack<int> stk = null;

                    if (map.ContainsKey(highFrequency))
                    {
                        stk = map[highFrequency];
                        
                    }
                    else
                    {
                        highFrequency--;
                        stk = map[highFrequency];
                    }

                    int val = stk.Pop();
                    //frequency[(char)val]--;
                    Console.WriteLine(val);
                }
            }
        }

        // https://leetcode.com/problems/longest-valid-parentheses/description/
        public void LongestValidParanthesis()
        {
            Console.WriteLine(LongestValidParanthesis("(()(((())"));
        }

        private int LongestValidParanthesis(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            Stack<int> stack = new Stack<int>();
            int max = 0;
            int left = -1;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == '(')
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

        // https://leetcode.com/problems/remove-invalid-parentheses/description/
        public void RemoveInvalidParanthesis()
        {
            List<string> str = new List<string>();
            str.AddRange(new string[] { "(", ")", "(", ")", ")", "(", ")"});

            Console.WriteLine(RemoveInvalidParanthesis(str, 0));
        }

        private int RemoveInvalidParanthesis(List<string> str, int idx)
        {
            if (ValidParenthesis(str))
            {
                return 1;
            }

            if (idx >= str.Count)
            {
                return 0;
            }

            int ret = 0;

            string ch = str[idx];
            str.RemoveAt(idx);

            ret += RemoveInvalidParanthesis(str, idx +1);

            str.Insert(idx, ch);
            ret += RemoveInvalidParanthesis(str, idx + 1);

            return ret;
        }

        private bool ValidParenthesis(List<string> str)
        {
            Stack<string> stk = new Stack<string>();

            foreach(string s in str.AsEnumerable())
            {
                if (s == "(")
                {
                    stk.Push(s);
                }
                else
                {
                    if (stk.Count > 0 && stk.Peek() == "(")
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

        public void MaxStack()
        {

        }

        public void ReverseStackUsingRecursion()
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(3);
            stk.Push(4);
            stk.Push(5);
            stk.Push(9);

            ReverseStackusingRecursion(stk);
        }

        private Stack<int> ReverseStackusingRecursion(Stack<int> stk)
        {
            if (stk.Count == 0)
            {
                return stk;
            }

            int temp = stk.Pop();
            ReverseStackusingRecursion(stk);
            InsertAtBottom(stk, temp);
            return stk;
        }

        private void InsertAtBottom(Stack<int> stk, int val)
        {
            if (stk.Count == 0)
            {
                stk.Push(val);
            }
            else
            {
                int item = stk.Pop();
                InsertAtBottom(stk, val);
                stk.Push(item);
            }
        }

        public void NextGreaterNumber()
        {
            int[] arr = new int[] { 12, 4, 3, 6, 11, 15};
            var res = NextGreaterNumber(arr);
        }

        private int[] NextGreaterNumber(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("param is null");
            }

            Stack<int> stk = new Stack<int>();
            stk.Push(arr[arr.Length - 1]);
            int prev = arr[arr.Length-1];
            int[] res = new int[arr.Length];

            res[arr.Length - 1] = -1;

            for(int idx = arr.Length -2; idx >=0; idx --)
            {
                if (arr[idx] < prev)
                {
                    res[idx] = prev;
                    stk.Push(arr[idx]);
                }
                else
                {
                    while (stk.Count >0 && arr[idx] > stk.Peek())
                    {
                        stk.Pop();
                    }

                    if (stk.Count ==0)
                    {
                        res[idx] = -1;
                    }
                    else
                    {
                        res[idx] = stk.Peek();
                        stk.Push(arr[idx]);
                    }
                }

                prev = arr[idx];
            }

            return res;
        }

        //https://leetcode.com/problems/online-stock-span/
        public void StockSpan()
        {

        }

        //private int[] StockSpan(int[] arr)
        //{
        //    Stack<int> ascending = new Stack<int>();
        //    Stack<int> descending = new Stack<int>();
        //    int[] res = new int[arr.Length];

        //    for(int idx = 0; idx < arr.Length; idx ++)
        //    {
        //        if (arr[idx] >= descending.Peek())
        //        {
        //            if (arr[idx] <= ascending.Peek())
        //            {
        //                ascending.Push(arr[idx]);
        //            }
        //            else
        //            {
        //                descending.Push(arr[idx]);
        //            }
        //        }
        //        else
        //        {
        //            if (arr[idx] < ascending.Peek())
        //            {
        //                ascending.Push(arr[idx]);
        //            }
        //            else
        //            {
        //                while (arr[idx] > ascending.Peek())
        //                {

        //                }
        //            }
        //        }
        //    }
        //}


        /*
          Given a stack of N elements, interleave the first half of the stack with the second half reversed using only one other queue. This should be done in-place.

Recall that you can only push or pop from a stack, and enqueue or dequeue from a queue.

For example, if the stack is [1, 2, 3, 4, 5], it should become [1, 5, 2, 4, 3]. If the stack is [1, 2, 3, 4], it should become [1, 4, 2, 3].

         */
        public void InterleaveStacks()
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);
            stk.Push(4);
            stk.Push(5);
            var res = InterleaveStacks(stk);
        }

        private Stack<int> InterleaveStacks(Stack<int> stk)
        {
            Queue<int> queue = new Queue<int>(stk.Count);

            int count = 1;
            int idx = 1;

            while (count <= stk.Count)
            {
                idx = stk.Count-1;

                while (idx >= count)
                {
                    queue.Enqueue(stk.Pop());
                    idx--;
                }

                while(queue.Count > 0)
                {
                    stk.Push(queue.Dequeue());
                }

                count++;
            }

            return stk;
        }

        public void QueueUsingStack()
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);

            Console.WriteLine(QueueUsingStack(stk));
        }

        private int QueueUsingStack(Stack<int> stk)
        {
            int val = stk.Pop();
            int ret = 0;

            if (stk.Count == 0)
            {
                return val;
            }

            ret = QueueUsingStack(stk);
            stk.Push(val);

            return ret;
        }
    }
}
