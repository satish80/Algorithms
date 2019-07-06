using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class BFS
    {
        //https://leetcode.com/problems/meeting-rooms/
        public void MeetingRooms()
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            Tuple<int, int> tuple1 = new Tuple<int, int>(10, 20);
            list.Add(tuple1);
            tuple1 = new Tuple<int, int>(12, 15);
            list.Add(tuple1);
            tuple1 = new Tuple<int, int>(17, 20);
            list.Add(tuple1);
            tuple1 = new Tuple<int, int>(30, 40);
            list.Add(tuple1);

            MeetingRooms(list);
        }

        private int MeetingRooms(List<Tuple<int, int>> courseTimings)
        {
            if (courseTimings == null)
            {
                return -1;
            }

            courseTimings.Sort(new TimeComparer());
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(courseTimings[0]);
            courseTimings.RemoveAt(0);
            int classes = 0;
            int idx = 0;
            bool removed = false;

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                while (courseTimings.Count > 0)
                {
                    if (idx < courseTimings.Count)
                    {
                        if (item.Item2 < courseTimings[idx].Item1)
                        {
                            queue.Enqueue(courseTimings[idx]);
                            courseTimings.RemoveAt(idx);
                            removed = true;
                        }
                        else
                        {
                            idx++;
                            classes++;
                        }
                    }
                    else
                    {
                        idx = 0;

                        if (removed)
                        {
                            if (courseTimings.Contains(item))
                            {
                                courseTimings.Remove(item);
                            }
                            removed = false;
                        }

                        break;
                    }
                }
            }

            return classes;
        }

        private class TimeComparer : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                if (x.Item2 > y.Item2)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }


        // https://leetcode.com/problems/word-search-ii/description/
        public void CreWordSearch()
        {
            char[,] arr = new char[,]
            {
                { 'o', 'a', 'a','n' },
                { 'e', 't', 'a', 'e'},
                { 'i', 'h', 'k', 'r'},
                { 'i', 'f', 'l', 'v'}
            };

            Dictionary<Pair, DirectionString> dict = new Dictionary<Pair, DirectionString>(new PairComparer());
            bool found = false;
            bool[,] visited = new bool[arr.GetLength(0), arr.GetLength(1)];
            WordSearch(arr, visited, "oath", 0, 0, dict, ref found);
        }

        private DirectionString WordSearch(char[,] arr, bool[,] visited, string word, int row, int col, Dictionary<Pair, DirectionString> dict, ref bool found)
        {
            if (arr == null || row > arr.GetLength(0) - 1 || col > arr.GetLength(1) - 1 || col < 0 || row < 0 || found)
            {
                return null;
            }

            char c = arr[row, col];

            Pair p = new Pair(row, col);

            if (visited[row, col])
            {
                return dict.ContainsKey(p) ? dict[p] : null;
            }

            visited[row, col] = true;

            DirectionString str = new DirectionString();
            str.Str = c.ToString();

            var top = WordSearch(arr, visited, word, row - 1, col, dict, ref found);
            str.Left = top != null ?
                top.Str + c.ToString() :
                null;

            var left = WordSearch(arr, visited, word, row, col - 1, dict, ref found);
            str.Left = left != null ?
                left.Str + c.ToString() :
                null;

            var bottom = WordSearch(arr, visited, word, row + 1, col, dict, ref found);
            str.Bottom = bottom != null ?
                bottom.Str + c.ToString() :
                null;

            var right = WordSearch(arr, visited, word, row, col + 1, dict, ref found);
            str.Right = right != null ?
                right.Str + c.ToString() :
                null;


            if (str.Top == word || str.Bottom == word || str.Left == word || str.Right == word)
            {
                Console.WriteLine($"found word {word}");
                found = true;
            }

            if (!dict.ContainsKey(p))
            {
                dict.Add(p, str);
            }

            return str;
        }

        public class PairComparer : IEqualityComparer<Pair>
        {
            public bool Equals(Pair x, Pair y)
            {
                if (x.X == y.X && y.X == y.Y)
                {
                    return true;
                }

                return false;
            }

            public int GetHashCode(Pair obj)
            {
                return obj.GetHashCode();
            }
        }

        internal class DirectionString
        {
            public string Top;
            public string Bottom;
            public string Left;
            public string Right;
            public string Str;
        }

        public void FindCherry()
        {
            int[,] arr = new int[,]
            {
                { 0, 1, -1},
                { 1, 0, -1},
                { 1, 1, 1}
            };

            int max = 0;
            Console.WriteLine(FindCherry(arr, 0, 0, 0, ref max));
        }

        private int FindCherry(int[,] arr, int row, int col, int count, ref int max)
        {
            if (row >= arr.GetLength(0) || col >= arr.GetLength(1) || row < 0 || col < 0)
            {
                return 0;
            }

            if (arr[row, col] == -1)
            {
                return -1;
            }
            else if (arr[row, col] == 0)
            {
                return 0;
            }
            else if (arr[row, col] == 1)
            {
                arr[row, col] = 0;
                return 1;
            }

            int top = FindCherry(arr, row + 1, col, count, ref max);

            int bottom = 0;

            if (top != -1)
            {
                count += top;
                bottom = FindCherry(arr, row, col + 1, count, ref max);
                if (bottom > 0)
                {
                    count += bottom;
                }
            }

            return count;

        }

        // https://leetcode.com/problems/reaching-points/discuss/114856/Easy-and-Concise-2-line-SolutionPythonC++Java
        public void ReachingPoints()
        {
            Console.WriteLine($"Solution : {ReachingPoints(1, 1, 2, 2)}");
        }

        private bool ReachingPoints(int sx, int sy, int tx, int ty)
        {
            while (sx < tx && sy < ty)
            {
                if (tx < ty)
                {
                    ty %= tx;
                }
                else
                {
                    tx %= ty;
                }
            }

            return sx == tx && (ty - sy) % sx == 0 || sy == ty && (tx - sx) % sy == 0;
        }

        private bool CreReachingPoints(int sx, int sy, int tx, int ty)
        {
            Queue<Pair> queue = new Queue<Pair>();

            Pair origin = new Pair(sx, sy);
            Pair dest = new Pair(tx, ty);
            HashSet<Pair> visited = new HashSet<Pair>();
            queue.Enqueue(origin);
            visited.Add(origin);
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (item.Equals(dest))
                {
                    return true;
                }

                if (item.X > dest.X || item.Y > dest.Y)
                {
                    continue;
                }

                var left = new Pair(item.X + item.Y, item.Y);
                var right = new Pair(item.X, item.Y + item.X);

                if (!visited.Contains(left))
                {
                    queue.Enqueue(left);
                    visited.Add(left);
                }

                if (!visited.Contains(right))
                {
                    queue.Enqueue(right);
                    visited.Add(right);
                }
            }

            return false;
        }

        // https://www.geeksforgeeks.org/water-jug-problem-using-bfs/
        public void WaterJug()
        {
            WaterJug(4, 3, 2);
        }

        private void WaterJug(int a, int b, int target)
        {
            Tuple<int, int> tuple = new Tuple<int, int>(0, 0);

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(tuple);
            HashSet<Tuple<int, int>> hash = new HashSet<Tuple<int, int>>();

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (item.Item1 == target || item.Item2 == target)
                {
                    Console.WriteLine("solvable");
                }

                if (hash.Contains(item))
                {
                    continue;
                }
                else
                {
                    hash.Add(item);
                }

                int c, d = 0;

                queue.Enqueue(new Tuple<int, int>(item.Item1, b));
                queue.Enqueue(new Tuple<int, int>(a, item.Item2));

                for (int ctr = 1; ctr <= Math.Max(a, b); ctr++)
                {
                    c = ctr + item.Item1;
                    d = item.Item2 - ctr;

                    if (c == a || d == 0)
                    {
                        tuple = new Tuple<int, int>(c, d);
                        queue.Enqueue(tuple);
                    }


                    c = item.Item1 - ctr;
                    d = ctr + item.Item2;

                    if (c == 0 || d == b)
                    {
                        tuple = new Tuple<int, int>(c, d);
                        queue.Enqueue(tuple);
                    }
                }

                queue.Enqueue(new Tuple<int, int>(a, 0));
                queue.Enqueue(new Tuple<int, int>(0, b));
            }
        }

        public void FindIslands()
        {
            int[,] arr = new int[,]
            {
                { 1, 1, 1, 1, 0},
                { 1, 1, 0, 1, 0},
                { 1, 1, 0, 0, 0},
                { 0, 0, 0, 0, 0}
                //{ 1, 1, 1, 0 },
                //{ 1, 1, 0, 0},
                //{ 0, 0, 1, 0}
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

            int count = 0;
            Queue<Pair> queue = new Queue<Pair>();


            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == 1)
                    {
                        queue.Enqueue(new Pair(row, col));
                        count += FindIslands(arr, row, col, queue, pairs);
                    }
                }
            }

            Console.WriteLine("no of Islands:" + count);
        }

        private int FindIslands(int[,] arr, int row, int col, Queue<Pair> queue, List<Pair> pairs)
        {
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                arr[cur.X, cur.Y] = 0;

                foreach (Pair pair in pairs)
                {
                    var r = cur.X + pair.X;
                    var c = cur.Y + pair.Y;

                    if (!ValidBounds(arr, r, c))
                    {
                        continue;
                    }

                    if (arr[r, c] == 1)
                    {
                        queue.Enqueue(new Pair(r, c));
                        arr[r, c] = 0;
                    }
                }
            }

            return 1;
        }

        private bool ValidBounds(int[,] arr, int row, int col)
        {
            if (row >= arr.GetLength(0) || col >= arr.GetLength(1) || row < 0 || col < 0)
            {
                return false;
            }

            return true;
        }

        public bool WordExist()
        {
            char[,] board = new char[,]
            {
              { 'A', 'B', 'C', 'E' },
              { 'S','F','C','S' },
              { 'A','D','E','E' }
            };

            List<Pair> pairs = new List<Pair>();
            Pair p1 = new Pair(-1, 0);
            Pair p2 = new Pair(1, 0);
            Pair p3 = new Pair(0, -1);
            Pair p4 = new Pair(0, 1);

            pairs.Add(p1);
            pairs.Add(p2);
            pairs.Add(p3);
            pairs.Add(p4);
            Queue<Pair> queue = new Queue<Pair>();
            string word = "ABCCED";

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row,col] == word[0])
                    {
                        queue.Enqueue(new Pair(row, col));
                        if (WordExist(board, word, pairs, row, col, queue))
                        {
                            return true;
                        }
                        queue.Clear();
                    }
                }
            }

            return false;
        }

        private bool WordExist(char[,] board, string word, List<Pair> pairs, int row, int col, Queue<Pair> queue)
        {
            int idx = 1;

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                foreach (Pair pair in pairs)
                {
                    var r = cur.X + pair.X;
                    var c = cur.Y + pair.Y;

                    if (r == row && c == col || !ValidBounds(board, r, c))
                    {
                        continue;
                    }

                    if (board[r, c] == word[idx])
                    {
                        idx++;

                        if (idx == word.Length-1)
                        {
                            return true;
                        }

                        queue.Enqueue(new Pair(r, c));
                    }
                }
            }

            return false;
        }

        private bool ValidBounds(char[,] board, int r, int c)
        {
            if (r >= board.GetLength(0) || c > board.GetLength(1) || r < 0 || c < 0)
            {
                return false;
            }

            return true;
        }
    }
}
