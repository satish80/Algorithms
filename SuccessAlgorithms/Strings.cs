using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class Strings
    {

        // https://www.geeksforgeeks.org/meta-strings-check-two-strings-can-become-swap-one-string/
        public void IsMetaString()
        {
            Console.WriteLine(IsMetaString("geeks", "keegs"));
        }

        private bool IsMetaString(string str1, string str2)
        {
            int first = -1, second = -1;

            if (str1.Length != str2.Length)
            {
                return false;
            }

            int ctr = -1; int unMatch = 0;

            while (++ctr < str1.Length)
            {
                if (str1[ctr] != str2[ctr])
                {
                    if (first != -1 && second != -1)
                    {
                        if (str1[ctr] != str2[second] ||
                            str2[ctr] != str1[first])
                        {
                            return false;
                        }
                        else
                        {
                            unMatch++;
                        }
                    }
                    else
                    {
                        first = ctr;
                        second = ctr;
                    }
                }
            }

            return unMatch == 1;
        }

        public void LargestWordInDictionary()
        {
            List<string> dict = new List<string>();
            dict.Add("ale");
            dict.Add("apple");
            dict.Add("monkey");
            dict.Add("plea");

            Console.WriteLine(LargestWordinDictionary(dict, "abpcplea"));
        }

        private int LargestWordinDictionary(List<string> dict, string word)
        {
            List<char> map = new List<char>();

            int max = 0;
            int matchCount = 0;

            foreach(string str in dict)
            {
                matchCount = IsInDictionary(str, word);

                max = matchCount > max ? matchCount : max;
            }

            return max;
        }

        private int IsInDictionary(string dictionaryWord, string word)
        {
            int wordIdx = 0;
            int dictIdx = 0;
            int count = 0;

            while (wordIdx < word.Length)
            {
                if (dictIdx == dictionaryWord.Length)
                {
                    break;
                }

                if (dictionaryWord[dictIdx] == word[wordIdx])
                {
                    dictIdx++;
                    count++;
                }
                

                wordIdx++;
            }

            return count;
        }

        private int IsInDictionary(string str, List<char> map)
        {
            int count = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (map.Contains(ch))
                {
                    count++;
                }
            }

            return count;
        }

        // https://practice.geeksforgeeks.org/problems/word-boggle/0
        public void WordBoggle()
        {
            HashSet<string> map = new HashSet<string>();
            map.Add("GEEKS");
            map.Add("FOR");
            map.Add("QUIZ");
            map.Add("GO");
            char[,] ch = new char[,]
            {
                { 'G', 'I', 'Z' },
                { 'U', 'E', 'K'},
                { 'Q', 'S', 'E'}
            };

            WordBoggle(map, ch);
        }

        private void WordBoggle(HashSet<string> map, char[,] givenList)
        {
            if (map.Count == 0)
            {
                return;
            }

            foreach(string str in map)
            {
                if (ListContainsMap(str, givenList))
                {
                    Console.WriteLine($"{str} is present");
                }
            }
        }

        private bool ListContainsMap(string str, char[,] givenList)
        {
            bool[,] visited = new bool[givenList.GetLength(0), givenList.GetLength(1)];

            for (int row = 0; row < givenList.GetLength(0); row++)
            {
                for (int col = 0; col < givenList.GetLength(1); col++)
                {
                    if(givenList[row, col] == str[0])
                    {
                        return CheckListContainsString(str, 0, givenList, row, col, visited);
                    }
                }
            }

            return false;
        }

        private bool CheckListContainsString(string str, int strIdx, char[,] givenList, int row, int col, bool[,] visited)
        {
            if (row > givenList.GetLength(0) - 1 || row < 0 || col > givenList.GetLength(1) - 1 || col < 0 || visited[row, col])
            {
                return false;
            }

            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell() { Row = row, Col = col});

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                if (visited[cell.Row, cell.Col] == true)
                {
                    continue;
                }

                if (str[strIdx] == givenList[cell.Row, cell.Col])
                {
                    visited[cell.Row, cell.Col] = true;

                    strIdx++;

                    if (strIdx == str.Length)
                    {
                        return true;
                    }
                }

                var cur = new Cell() { Row = cell.Row, Col = cell.Col };

                if (cell.Row > 0)
                {
                    cur.Row--;
                    
                    queue.Enqueue(cur);
                }

                if (cell.Col > 0)
                {
                    cur = new Cell() { Row = cell.Row, Col = cell.Col };
                    cur.Col--;
                    queue.Enqueue(cur);
                }

                if (cell.Row  > 0 && cell.Col >0)
                {
                    cur = new Cell() { Row = cell.Row, Col = cell.Col };
                    cur.Row--;
                    cur.Col--;
                    queue.Enqueue(cur);
                }

                if (cell.Row > 0 && cell.Col < givenList.GetLength(1) - 1)
                {
                    cur = new Cell() { Row = cell.Row, Col = cell.Col };
                    cur.Row--;
                    cur.Col++;
                    queue.Enqueue(cur);
                }

                if (cell.Col < givenList.GetLength(1) - 1)
                {
                    cur = new Cell() { Row = cell.Row, Col = cell.Col };
                    cur.Col++;
                    queue.Enqueue(cur);
                }

                if (cell.Row < givenList.GetLength(0) - 1)
                {
                    cur = new Cell() { Row = cell.Row, Col = cell.Col };
                    cur.Row++;
                    queue.Enqueue(cur);
                }

                if (cell.Row < givenList.GetLength(0) -1 && cell.Col < givenList.GetLength(1) -1)
                {
                    cur = new Cell() { Row = cell.Row, Col = cell.Col };
                    cur.Row++;
                    cur.Col++;
                    queue.Enqueue(cur);
                }

                if (cell.Row < givenList.GetLength(0) - 1 && cell.Col > 0 )
                {
                    cur = new Cell() { Row = cell.Row, Col = cell.Col };
                    cur.Row++;
                    cur.Col--;
                    queue.Enqueue(cur);
                }

                if (!Found(str[strIdx], queue, givenList))
                {
                    return false;
                }
            }

            return false;
        }

        private bool Found(char str, Queue<Cell> queue, char[,] givenList)
        {
            while(queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (givenList[element.Row, element.Col] == str)
                {
                    queue.Clear();
                    queue.Enqueue(new Cell() { Row = element.Row, Col = element.Col });
                    return true;
                }
            }

            return false;
        }

        public void LongestUniqueSubstring()
        {
            string str = "dvdf";

            Console.WriteLine(LongestUniqueSubstring(str));
        }

        private int LongestUniqueSubstring(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();
            int count = 0, max = 0;

            for (int idx = 0; idx < str.Length; idx++)
            {
                if (! map.ContainsKey(str[idx]))
                {
                    count++;
                    max = max < count ? count : max;
                }
                else
                {
                    count = 1;
                    idx = map[str[idx]] + 1;

                    if (idx > str.Length -1)
                    {
                        break;
                    }

                    map.Clear();
                }

                map.Add(str[idx], idx);
            }

            return max;
        }

        public struct Cell
        {
            public int Row;
            public int Col;
        }

        //https://www.geeksforgeeks.org/remove-invalid-parentheses/
        public void RemoveInvalidParentheses()
        {
            string s = "(()((())";

            RemoveInvalidParenthesis(s);
        }

        bool isParenthesis(char c)
        {
            return ((c == '(') || (c == ')'));
        }

        //  method returns true if string contains valid
        // parenthesis
        bool isValidString(string str)
        {
            int cnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    cnt++;
                else if (str[i] == ')')
                    cnt--;
                if (cnt < 0)
                    return false;
            }
            return (cnt == 0);
        }

        private void RemoveInvalidParenthesis(string str)
        {
            if (string.IsNullOrEmpty(str))
                return;

            //  visit set to ignore already visited string
            List<string> visit = new List<string>();

            //  queue to maintain BFS
            Queue<string> q = new Queue<string>();
            string temp;
            bool level = false;

            //  pushing given string as starting node into queue
            q.Enqueue(str);
            visit.Add(str);
            while (q.Count > 0)
            {
                str = q.Dequeue();

                if (isValidString(str))
                {
                    Console.WriteLine(str);

                    // If answer is found, make level true
                    // so that valid string of only that level
                    // are processed.
                    level = true;
                }

                if (level)
                    continue;

                for (int i = 0; i < str.Length; i++)
                {
                    if (!isParenthesis(str[i]))
                        continue;

                    // Removing parenthesis from str and
                    // pushing into queue,if not visited already
                    temp = str.Substring(0, i) + str.Substring(i + 1);
                    if (! visit.Contains(temp))
                    {
                        q.Enqueue(temp);
                        visit.Add(temp);
                    }
                }
            }
        }

        public void AToI()
        {
            Console.WriteLine(AToI("42"));
        }

        private int AToI(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int res = 0;
            int product = 1;

            for(int idx = str.Length - 1; idx >= 0; idx --)
            {
                res = product * (str[idx] - '0') + res;
                product *= 10;
            }

            return res;
        }

        public void ClosestPalindrome()
        {
            Console.WriteLine(ClosestPalindrome("1234321"));
        }

        private string ClosestPalindrome(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return "0";
            }

            if (num.Length == 1 )
            {
                return (int.Parse(num) - 1).ToString();
            }
            else if (num == "10" || num == "11")
            {
                return "9";
            }

            char[] ch = num.ToCharArray();

            int start = 0;
            int end = ch.Length - 1;
            bool alteredPalindrome = false;
            while (end-start >= 1)
            {
                if (ch[start] != ch[end])
                {
                    ch[end] = ch[start];
                    alteredPalindrome = true;
                }
                start++;
                end--;
            }

            if (!alteredPalindrome)
            {
                int len = num.Length;
                int palinNum = int.Parse(num);

                if (len == 2)
                {
                    return (palinNum - 11).ToString();
                }

                int ctr = 10;

                for (int idx = len; len > 2; len--)
                {
                    palinNum = palinNum - ctr;
                    ctr = ctr * 10;
                }

                return palinNum.ToString();
            }

            string s = new string(ch);
            return s;
        }

        public void Indent()
        {
            Console.WriteLine(Indent("The quick brown fox jumps over the lazy dog", 39));
        }
        public string Indent(string message, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            StringBuilder sb = new StringBuilder();

            string[] arr = message.Split(' ');

            if (arr[0].Length > K)
            {
                return string.Empty;
            }

            sb.Append(arr[0]);
            int count = arr[0].Length;

            for (int idx = 1; idx < arr.Length; idx++)
            {
                if (count + arr[idx].Length + 1 < K)
                {
                    sb.Append(" ");
                    sb.Append(arr[idx]);
                    count += arr[idx].Length + 1;
                }
                else
                {
                    break;
                }
            }
            return sb.ToString();
        }

        //https://leetcode.com/contest/weekly-contest-131/problems/remove-outermost-parentheses/
        public void RemoveOuterParentheses()
        {
            Console.WriteLine(RemoveOuterParentheses("(()())(())"));
        }

        private string RemoveOuterParentheses(string input)
        {
            int idx = 1;
            StringBuilder sb = new StringBuilder();
            Stack<char> stk = new Stack<char>();
            bool start = true;

            while (idx < input.Length)
            {
                if (input[idx] == ')')
                {
                    if (stk.Count > 0 && stk.Peek() == '(')
                    {
                        sb.Append(input[idx]);
                    }

                    if (stk.Count == 0)
                    {
                        start = false;
                    }
                    else
                    {
                        stk.Pop();
                    }
                }
                else
                {
                    if (start)
                    {
                        stk.Push('(');
                        sb.Append(input[idx]);
                    }
                    else
                    {
                        start = true;
                    }
                }

                idx++;
            }

            return sb.ToString();
        }


        //https://leetcode.com/problems/minimum-window-substring/
        public void MinWindow()
        {
            Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));
        }

        public string MinWindow(string s, string t)
        {
            if (s == null && t == null)
            {
                return null;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char ch in t)
            {
                map.Add(ch, -1);
            }

            int small = Int32.MaxValue;
            int big = Int32.MinValue;
            int count = 0;
            int min = Int32.MaxValue;
            int start = -1;
            int end = -1;

            for (int idx = 0; idx < s.Length; idx++)
            {
                if (map.ContainsKey(s[idx]))
                {
                    if (map[s[idx]] == -1)
                    {
                        count++;
                    }

                    if (idx < small)
                    {
                        small = idx;
                    }

                    if (idx > big)
                    {
                        big = idx;
                    }

                    if (count == t.Length)
                    {
                        if (min > big - small + 1)
                        {
                            min = big - small + 1;
                            start = small;
                            end = big;
                            min = Int32.MaxValue;
                            small = Int32.MaxValue;
                            big = Int32.MinValue;
                            count = 0;
                        }

                        InitializeMap(map, t);
                    }
                }
            }

            return s.Substring(start, end - start+1);
        }

        private void InitializeMap(Dictionary<char, int> map, string t)
        {
            foreach (char ch in t)
            {
                map[ch] = -1;
            }
        }
        public void IsRotatedString()
        {
            Console.WriteLine(IsRotatedString("abcde", "eabcd"));
        }

        private bool IsRotatedString(string str, string rotated)
        {
            if(string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(rotated) ||
                !string.IsNullOrEmpty(str) && string.IsNullOrEmpty(rotated) ||
                str.Length != rotated.Length)
            {
                return false;
            }

            int i = -1;

            for(int idx = 0; idx < rotated.Length; idx ++)
            {
                if (str[idx] == rotated[0])
                {
                    i = idx;
                    break;
                }
            }

            int rIdx = 0;

            for(int idx = i; idx < str.Length; idx ++)
            {
                if (str[idx] != rotated[rIdx++])
                {
                    return false;
                }
            }

            for(int idx = 0; idx < i; idx ++)
            {
                if (str[idx] != rotated[rIdx++])
                {
                    return false;
                }
            }

            return true;
        }

        public void ValidStringParanthesis()
        {
            Console.WriteLine(ValidStringParanthesis("((*)*))"));
        }

        public bool ValidStringParanthesis(string s)
        {
            Stack<char> stk = new Stack<char>();

            int idx = 0;
            stk.Push(s[idx]);
            idx++;

            while (idx < s.Length)
            {
                if (s[idx] == ')')
                {
                    if (stk.Count == 0 || stk.Peek() == ')')
                    {
                        return false;
                    }
                    else if (stk.Peek() == '(')
                    {
                        stk.Pop();
                    }
                }
                else if (s[idx] == '(')
                {
                    stk.Push('(');
                }
                else if (s[idx] == '*')
                {
                    if (stk.Count == 0 || stk.Peek() == ')')
                    {
                        stk.Push('(');
                    }
                    else if (stk.Peek() == '(')
                    {
                        stk.Pop();
                    }
                }
                idx++;
            }

            return stk.Count == 0;
        }

        public void IsScramble()
        {
            Console.WriteLine(IsScrambleInternal("great", "rgeat"));
        }

        private bool IsScrambleInternal(string s1, string s2)
        {
            bool res = false;

            for (int idx = 0; idx < s2.Length; idx++)
            {
                if (s2[idx] == s1[0])
                {
                    int length = idx;
                    res = AreAnagrams(s1.Substring(0, idx + 1), s2.Substring(0, idx + 1)) &&
                     AreAnagrams(s1.Substring(idx + 1, s1.Length - idx - 1), s2.Substring(idx + 1, s2.Length - idx - 1)) ||

                     AreAnagrams(s1.Substring(0, s1.Length - idx -1), s2.Substring(idx + 1, s2.Length - idx)) &&
                     AreAnagrams(s1.Substring(idx + 1, s1.Length - idx), s2.Substring(idx + 1, s2.Length - idx - 1));

                    if (res)
                    {
                        return true;
                    }
                    else
                    {

                    }
                }
            }

            return res;
        }

        private bool AreAnagrams(string s1, string s2)
        {
            Dictionary<char, int> list = new Dictionary<char, int>();

            for (int idx = 0; idx < s1.Length; idx++)
            {
                if (list.ContainsKey(s1[idx]))
                {
                    list[s1[idx]] += 1;
                }
                else
                {
                    list.Add(s1[idx], 1);
                }
            }

            for (int idx = 0; idx < s2.Length; idx++)
            {
                if (!list.ContainsKey(s2[idx]))
                {
                    return false;
                }

                if (list[s2[idx]] == 1)
                {
                    list.Remove(s2[idx]);
                }
                else
                {
                    list[s2[idx]] -= 1;
                }
            }

            return list.Count == 0;
        }

        // https://practice.geeksforgeeks.org/problems/anagram-of-string/1
        public void AnagramOfString()
        {
            Console.WriteLine(AnagramOfString("cddgk", "gcd"));
        }

        public int AnagramOfString(string str1, string str2)
        {
            int min = str1.Length > str2.Length ? 2 : 1;
            Dictionary<char, int> map = new Dictionary<char, int>();

            if (min == 1)
            {
                SetMap(map, str1);
                return VerifyAnagram(map, str2);
            }
            else
            {
                SetMap(map, str2);
                return VerifyAnagram(map, str1);
            }
        }

        private int VerifyAnagram(Dictionary<char, int> map, string str)
        {
            char[] strArr = str.ToCharArray();
            int idx = 0;
            int count = 0;

            while (idx < strArr.Length)
            {
                if (map.Count > 0)
                {
                    int value = 0;
                    bool contains = map.ContainsKey(strArr[idx]);

                    if (contains)
                    {
                        value = map[strArr[idx]];

                        map[strArr[idx]]--;

                        if (map[strArr[idx]] == 0)
                        {
                            map.Remove(strArr[idx]);
                        }
                    }
                    else
                    {
                        count++;
                    }

                    idx++;
                }
                else
                {
                   return count += strArr.Length - idx;
                }
            }

            return count;
        }

        private void SetMap(Dictionary<char, int> map, string str)
        {
            for (int idx = 0; idx < str.Length; idx++)
            {
                if (map.ContainsKey(str[idx]))
                {
                    map[str[idx]]++;
                }
                else
                {
                    map.Add(str[idx], 1);
                }
            }
        }

        // https://leetcode.com/problems/k-similar-strings/discuss/140099/JAVA-BFS-32-ms-cleanconciseexplanationwhatever
        public void Ksimilarity()
        {
            var res = kSimilarity("abac", "baca");
        }

        public int kSimilarity(String A, String B)
        {
            if (A == B) return 0;
            HashSet<string> vis = new HashSet<string>();
            Queue<String> q = new Queue<string>();
            q.Enqueue(A);
            vis.Add(A);
            int res = 0;

            while (q.Count > 0)
            {
                res++;
                for (int sz = q.Count; sz > 0; sz--)
                {
                    String s = q.Dequeue();
                    int i = 0;
                    while (s[i] == B[i]) i++;
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[j] == B[j] || s[i] != B[j]) continue;
                        String temp = Swap(s, i, j);
                        if (temp == B) return res;
                        if (vis.Add(temp)) q.Enqueue(temp);
                    }
                }
            }

            return res;
        }

        public String Swap(String s, int i, int j)
        {
            char[] ca = s.ToCharArray();
            char temp = ca[i];
            ca[i] = ca[j];
            ca[j] = temp;
            return new String(ca);
        }

        // https://leetcode.com/problems/word-search-ii/discuss/59780/Java-15ms-Easiest-Solution-(100.00)?page=1
        public void FindWords()
        {
            char[,] arr = new char[,]
            {
                { 'o', 'a', 'a','n' },
                { 'e', 't', 'a', 'e'},
                { 'i', 'h', 'k', 'r'},
                { 'i', 'f', 'l', 'v'}
            };

            var result = FindWords(arr, new string[] { "oath"});
        }

        public List<String> FindWords(char[,] board, String[] words)
        {
            List<String> res = new List<String>();
            TrieNode root = BuildTrie(words);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Dfs(board, i, j, root, res);
                }
            }
            return res;
        }

        public void Dfs(char[,] board, int i, int j, TrieNode p, List<String> res)
        {
            char c = board[i,j];
            if (c == '#' || p.Next[c - 'a'] == null)
            {
                return;
            }

            p = p.Next[c - 'a'];
            if (p.Word != null)
            {   // found one
                res.Add(p.Word);
                p.Word = null;     // de-duplicate
            }

            board[i,j] = '#';
            if (i > 0)
            {
                Dfs(board, i - 1, j, p, res);
            }

            if (j > 0)
            {
                Dfs(board, i, j - 1, p, res);
            }

            if (i < board.Length - 1)
            {
                Dfs(board, i + 1, j, p, res);
            }

            if (j < board.GetLength(0) - 1)
            {
                Dfs(board, i, j + 1, p, res);
            }

            // board[i,j] = c;
        }

        public TrieNode BuildTrie(String[] words)
        {
            TrieNode root = new TrieNode();
            foreach (String w in words)
            {
                TrieNode p = root;
                foreach (char c in w.ToCharArray())
                {
                    int i = c - 'a';
                    if (p.Next[i] == null)
                    {
                        p.Next[i] = new TrieNode();
                    }

                    p = p.Next[i];
                }
                p.Word = w;
            }
            return root;
        }

        public class TrieNode
        {
            public TrieNode[] Next = new TrieNode[26];
            public String Word;
        }

        // https://leetcode.com/problems/minimum-window-substring/description/
        public void MinWindowSubstring()
        {
            Console.WriteLine(MinWindowSubString("ADOBECODEBANC", "ABC"));
        }

        private string MinWindowSubString(string original, string desired)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();


            int start = -1, end = -1, count = 0, minLength = int.MaxValue, length = desired.Length;
            int minStart = -1; int minEnd = -1;

            ResetDict(dict, desired);

            for (int idx = 0; idx < original.Length; idx ++)
            {
                var ch = original[idx];

                if (dict.ContainsKey(ch))
                {
                    if (dict[ch] == -1)
                    {
                        count++;
                        dict[ch] = idx;
                    }

                    if (count == length)
                    {
                        FindIndices(dict, ref start, ref end);

                        if (end - start < minLength)
                        {
                            minLength = end - start;
                            minStart = start;
                            minEnd = end;

                            count = 0;
                            start = -1;
                            end = -1;

                            ResetDict(dict, desired);
                        }
                    }
                    else
                    {
                        dict[ch] = idx;
                    }
                }
            }

            return original.Substring(minStart, minEnd - minStart +1);
        }

        private void ResetDict(Dictionary<char,int> dict, string desired)
        {
            if (dict.Count == desired.Length)
            {
                for(int idx = 0; idx < dict.Count; idx++)
                {
                    dict[desired[idx]] = -1;
                }

                return;
            }

            foreach (char ch in desired)
            {
                dict.Add(ch, -1);
            }
        }

        private void FindIndices(Dictionary<char,int> dict, ref int start, ref int end)
        {
            start = int.MaxValue;
            end = int.MinValue;

           foreach(KeyValuePair<char,int> pair in dict)
           {
                if (pair.Value < start)
                {
                    start = pair.Value;
                }

                if (pair.Value > end)
                {
                    end = pair.Value;
                }
           }
        }

        // https://leetcode.com/problems/wildcard-matching/description/
        public void WildCardMatching()
        {
            Console.WriteLine(WildCardMatching("abefcdgiescdfimde", "ab*cd?i*de"));
        }

        private bool WildCardMatching(string str, string wildCardString)
        {
            bool result =true;

            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(wildCardString))
            {
                return false;
            }

            int strIdx = 0, wildIdx = 0;

            while (strIdx < str.Length && wildIdx < wildCardString.Length)
            {
                if (wildCardString[wildIdx] == '?' || wildCardString[wildIdx] == str[strIdx])
                {
                    strIdx ++;
                    wildIdx++;
                }
                else if(wildCardString[wildIdx] == '*')
                {
                    wildIdx++;

                    while(strIdx < str.Length)
                    {
                        if (wildIdx < wildCardString.Length)
                        {
                            if (str[strIdx] != wildCardString[wildIdx])
                            {
                                strIdx++;
                            }
                            else
                            {
                                wildIdx++;
                                strIdx++;
                                break;
                            }
                        }
                        else
                        {
                            result = true;
                            return result;
                        }
                    }

                    if (strIdx == str.Length -1 && wildIdx < wildCardString.Length)
                    {
                        result = false;
                        return result;
                    }
                }
                else
                {
                    result = false;
                    return result;
                }
            }

            if (strIdx < str.Length || wildIdx < wildCardString.Length)
            {
                result = false;
            }

            return result;
        }

        public void MappedString()
        {
            string str = "TANUAA";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("T", "x");
            map.Add("H", "l");
            map.Add("NU", "g");
            map.Add("AA", "u");
            map.Add("A", "z");
            map.Add("TH", "y");

            Console.WriteLine(ReturnMappedString(str, map));

        }
        private string ReturnMappedString(string str, Dictionary<string, string> map)
        {
            int idx = 0, start = 0;
            string mapStr = string.Empty;

            while (idx < str.Length)
            {
                start = idx;

                while(idx + 1 < str.Length)
                {
                    if (idx > start)
                    {
                        if (map.ContainsKey(str.Substring(start, idx + 1 - start)))
                        {
                            idx++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (map.ContainsKey(str.Substring(start, 1)))
                        {
                            idx++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (Math.Abs(start- idx) > 1)
                {
                    mapStr = string.Concat(mapStr, map[str.Substring(start, idx + 1 - start)]);
                }
                else
                {
                    mapStr = string.Concat(mapStr, map[str.Substring(start, 1)]);
                }

                if (!map.ContainsKey(str[idx].ToString()) && start == idx)
                {
                    return mapStr;
                }
            }

            return mapStr;
        }

        public void MinWindowSubstring2()
        {
            Console.WriteLine(MinWindowSubstring2("ADOBECODEBANC", "ABC"));
        }

        private int MinWindowSubstring2(string originalString, string subString)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            FillandClearState(map, subString);

            int curIdx = 0;
            char isStartChar = ' ';
            int start = -1;
            int end = -1;
            int result = int.MaxValue;
            while (curIdx < originalString.Length)
            {
                var curChar = originalString[curIdx];

                if (map.ContainsKey(curChar) && isStartChar ==  ' ' || isStartChar == curChar)
                {
                    start = curIdx;
                    map[curChar] = curIdx;
                    isStartChar = curChar;
                }
                else if (map.ContainsKey(curChar))
                {
                    map[curChar] = curIdx;
                }

                end = AllCharFound(map);
                if (end != -1)
                {
                    result = result > end - start && end != -1 ? end - start: result;

                    start = -1;
                    end = -1;
                    isStartChar = ' ';
                    FillandClearState(map, subString);
                }

                curIdx++;
            }

            return result;
        }

        private int AllCharFound(Dictionary<char, int> map)
        {
            int start = int.MaxValue; int end = -1;
            bool value = true;

            foreach(KeyValuePair<char,int> ch in map)
            {
                if (start > ch.Value && (start != -1 && ch.Value != -1))
                {
                    start = ch.Value;
                }
                if (end < ch.Value)
                {
                    end = ch.Value;
                }
                if (ch.Value == -1)
                {
                    value = false;
                }
            }

            return value ? end : -1;
        }

        private void FillandClearState(Dictionary<char, int> map, string subString)
        {
            if (map.Count == 0)
            {
                foreach (char ch in subString)
                {
                    map.Add(ch, -1);
                }
            }
            else
            {
                foreach (char ch in subString)
                {
                    map[ch]=-1;
                }
            }
        }
    }
}
