using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class Tree
    {
        // https://practice.geeksforgeeks.org/problems/connect-nodes-at-same-level/1
        public void ConnectNodesAtSameLevel()
        {
            TreeNode root = new TreeNode(10);
            root.Left = new TreeNode(3);
            root.Right = new TreeNode(5);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(1);
            root.Right.Right = new TreeNode(2);

            ConnectNodesAtSameLevel(root);
        }

        private void ConnectNodesAtSameLevel(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode cur = null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int count = 0;
            TreeNode Prev = null;

            while (queue.Count > 0)
            {
                cur = queue.Dequeue();

                if (cur.Left != null)
                {
                    queue.Enqueue(cur.Left);
                }

                if (cur.Right != null)
                {
                    queue.Enqueue(cur.Right);
                }

                if (count > 0)
                {
                    if (Prev != null)
                    {
                        Prev.NextRight = cur;
                    }
                    
                    count--;
                    if (count == 0)
                    {
                        Prev = null;
                    }
                    else
                    {
                        Prev = cur;
                    }
                }
                else
                {
                    count = queue.Count;
                    Prev = cur;
                }
            }
        }

        /*
         This problem was asked by Google.

        Given the root of a binary tree, return a deepest node. For example, in the following tree, return d.
            a
           / \
          b   c
         /
        d
       */
        public void DeepestNode()
        {
            TreeNode node = new TreeNode(3);
            node.Left = new TreeNode(1);
            node.Left.Right = new TreeNode(4);
            node.Right = new TreeNode(5);

            int count = 0;
            TreeNode deepNode = null;

            var result = DeepestNode(node, 0, ref count, ref deepNode);
        }

        private TreeNode DeepestNode(TreeNode node, int level, ref int count, ref TreeNode deepNode)
        {
            if (node == null)
            {
                return deepNode;
            }

            if (level == count)
            {
                deepNode = node;
            }

            if (node.Left != null)
            {
                count++;
                DeepestNode(node.Left, level + 1, ref count, ref deepNode);
            }

            if (node.Right != null)
            {
                count++;
                DeepestNode(node.Right, level + 1, ref count, ref deepNode);
            }

            return deepNode;
        }

        //https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/discuss/252232/JavaC%2B%2BPython-O(N)-Solution
        public void bstFromPreorder()
        {
            int i = 0;
            int[] arr = new int[] { 8, 5, 1, 7, 10, 12 };
            var tree = bstFromPreorder(arr, Int32.MaxValue, ref i);
        }

        public TreeNode bstFromPreorder(int[] arr, int bound, ref int i)
        {
            if (i == arr.Length || arr[i] > bound)
            {
                return null;
            }

            TreeNode root = new TreeNode(arr[i++]);
            root.Left = bstFromPreorder(arr, root.Value.Value, ref i);
            root.Right = bstFromPreorder(arr, bound, ref i);
            return root;
        }

        public void RightSideView()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Left.Right = new TreeNode(5);
            node.Right = new TreeNode(3);
            node.Right.Left = new TreeNode(4);

            int cur = 0;
            RightSideView(node, 0, ref cur);
        }

        private TreeNode RightSideView(TreeNode node, int level, ref int cur)
        {
            if (node == null)
            {
                return null;
            }

            if (cur == level)
            {
                Console.WriteLine(node.Value.Value);
            }

            cur++;

            var right = RightSideView(node.Right, level +1, ref cur);
            var left = RightSideView(node.Left, level + 1, ref cur);

            return node;
        }

        public void IsValidBST()
        {
            TreeNode node = new TreeNode(1);
            node.Right = new TreeNode(1);

            TreeNode prev = null;
            Console.WriteLine(IsValidBST(node, ref prev));
        }

        private bool IsValidBST(TreeNode node, ref TreeNode prev)
        {
            bool result = true;

            if (node == null)
            {
                return result;
            }

            result = IsValidBST(node.Left, ref prev);

            if ((prev != null && node.Value < prev.Value) || !result)
            {
                return false;
            }

            prev = node;

            if (result)
            {
                result = IsValidBST(node.Right, ref prev);
            }

            return result;
        }

        // https://practice.geeksforgeeks.org/problems/count-bst-nodes-that-lie-in-a-given-range/1
        public void BSTNodesWithinRange()
        {
            TreeNode root = new TreeNode(10);
            root.Left = new TreeNode(5);
            root.Left.Left = new TreeNode(1);
            root.Right = new TreeNode(50);
            root.Right.Left = new TreeNode(40);
            root.Right.Right = new TreeNode(100);

            BSTNodesWithinRangeOptimized(root, 5, 45);
        }

        private void BSTNodesWithinRangeOptimized(TreeNode node, int left, int right)
        {
            if (node == null )
            {
                return;
            }

            if (node.Value >= left && node.Value <= right)
            {
                Console.WriteLine(node.Value);
            }

            if (node.Value >= left && node.Value <= right)
            {
                BSTNodesWithinRange(node.Left, left, right);
                BSTNodesWithinRange(node.Right, left, right);
            }
            else if (node.Value > right)
            {
                BSTNodesWithinRange(node.Left, left, right);
            }
            else if (node.Value < left)
            { 
                BSTNodesWithinRange(node.Right, left, right);
            }
        }

        private void BSTNodesWithinRange(TreeNode node, int left, int right)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value >= left && node.Value <= right)
            {
                Console.WriteLine(node.Value);
            }

                BSTNodesWithinRange(node.Left, left, right);
                BSTNodesWithinRange(node.Right, left, right);
            
        }

        public void MirrorTree()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(3);
            node.Right = new TreeNode(2);
            node.Right.Left = new TreeNode(5);
            node.Right.Right = new TreeNode(4);

            var res = MirrorTree(node);
        }

        private TreeNode MirrorTree(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            TreeNode left = MirrorTree(node.Left);
            TreeNode right = MirrorTree(node.Right);

            TreeNode temp = node.Left;
            node.Left = right;
            node.Right = temp;

            return node;
        }

        //https://leetcode.com/problems/path-sum-iii/description/
        public void PathSum()
        {
            /*
                        10
                  5             -3
             4(3)        6(2)               11
         3      2   1
          */

            TreeNode node = new TreeNode(10);
            node.Left = new TreeNode(5);
            node.Right = new TreeNode(-3);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(6);
            node.Left.Right.Left = new TreeNode(1);
            node.Left.Left.Left = new TreeNode(3);
            node.Left.Left.Right = new TreeNode(2);
            node.Left.Right.Right = new TreeNode(1);
            node.Right.Right = new TreeNode(11);

            Console.WriteLine(PathSum(node, 8));
        }

        internal int PathSum(TreeNode root, int sum)
        {
            Dictionary<int, int> preSum = new Dictionary<int, int>();
            preSum.Add(0, 1);
            int count = 0;
            return Helper(root, 0, sum, preSum, ref count);
        }

        internal int Helper(TreeNode root, int currSum, int target, Dictionary<int, int> preSum, ref int count)
        {
            if (root == null)
            {
                return count;
            }

            currSum += root.Value.Value;

            if (preSum.ContainsKey(currSum - target))
            {
                count += preSum[currSum - target];
            }

            if (!preSum.ContainsKey(currSum))
            {
                preSum.Add(currSum, 1);
            }
            else
            {
                preSum[currSum] = preSum[currSum] + 1;
            }

            Helper(root.Left, currSum, target, preSum, ref count);
            Helper(root.Right, currSum, target, preSum, ref count);

            preSum[currSum] = preSum[currSum] - 1;

            return count;
        }

        public void RootPathSum()
        {
            TreeNode node = new TreeNode(5);
            node.Left = new TreeNode(4);
            node.Right = new TreeNode(8);
            node.Left.Left = new TreeNode(11);
            node.Left.Left.Left = new TreeNode(7);
            node.Left.Left.Right = new TreeNode(2);
            node.Right.Left = new TreeNode(13);
            node.Right.Right = new TreeNode(4);
            node.Right.Right.Right = new TreeNode(1);
            node.Right.Right.Left = new TreeNode(5);

            var res = RootPathSum(node, 0, 22, new List<List<int>>(), new List<int>());
        }

        private List<List<int>> RootPathSum(TreeNode node, int sum, int target, List<List<int>> lists, List<int> list)
        {
            if (sum == target)
            {
                lists.Add(new List<int>(list));
                return lists;
            }

            if (node == null)
            {
                return lists;
            }

            list.Add(node.Value.Value);

            RootPathSum(node.Left, sum + node.Value.Value, target, lists, list);
            RootPathSum(node.Right, sum + node.Value.Value, target, lists, list);

            list.RemoveAt(list.Count-1);

            return lists;
        }

        public void HasDuplicateSubTree()
        {
            TreeNode node = new TreeNode(10);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);

            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Left.Left.Left = new TreeNode(6);
            node.Left.Left.Right = new TreeNode(7);

            node.Right.Left = new TreeNode(2);
            node.Right.Left.Left = new TreeNode(4);
            node.Right.Left.Right = new TreeNode(5);
            node.Right.Left.Left.Left = new TreeNode(6);
            node.Right.Left.Left.Right = new TreeNode(7);

            bool hasDupe = false;
            Console.WriteLine(HasDuplicateSubTree(node, new Dictionary<int, List<TreeNode>>(), ref hasDupe));
        }

        private bool HasDuplicateSubTree(TreeNode node, Dictionary<int, List<TreeNode>> dict, ref bool hasDuplicates)
        {
            if (node == null)
            {
                return hasDuplicates;
            }

            if (dict.ContainsKey(node.Value.Value))
            {
                foreach (var treeNode in dict[node.Value.Value])
                {
                    int count = 4;
                    var res = CheckDuplicates(treeNode, node, ref count);

                    if (res && count == 0)
                    {
                        return true;
                    }
                }
                dict[node.Value.Value].Add(node);
            }
            else
            {
                dict.Add(node.Value.Value, new List<TreeNode>() { node });
            }

            if (!hasDuplicates)
            {
                hasDuplicates = HasDuplicateSubTree(node.Left, dict, ref hasDuplicates);
            }

            if (!hasDuplicates)
            {
                hasDuplicates = HasDuplicateSubTree(node.Right, dict, ref hasDuplicates);
            }

            return hasDuplicates;
        }

        private bool CheckDuplicates(TreeNode first, TreeNode second, ref int count)
        {
            bool res = true;

            if (first != null && second == null || first == null && second != null)
            {
                count--;
                return false;
            }
            else if (first == null && second == null)
            {
                return true;
            }
            else if(first.Value == second.Value && res)
            {
                count--;

                res = CheckDuplicates(first.Left, second.Left, ref count);
                if (res)
                {
                    res = CheckDuplicates(first.Right, second.Right, ref count);
                }

                return res;
            }
            else if(first.Value != second.Value)
            {
                count--;
                return false;
            }
            else
            {
                return res;
            }
        }

        // https://leetcode.com/problems/boundary-of-binary-tree/discuss/101280/Java(12ms)-left-boundary-left-leaves-right-leaves-right-boundary
        public void Boundary()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Left.Right.Left = new TreeNode(7);
            node.Left.Right.Right = new TreeNode(8);

            node.Right = new TreeNode(3);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(5);
            node.Right.Left.Left = new TreeNode(9);
            node.Right.Left.Right = new TreeNode(10);

            List<int> res = new List<int>() { node.Value.Value};
            res = LeftBoundary(node.Left, res);
            Leaves(node.Left, res);
            Leaves(node.Right, res);
            res = RightBoundary(node.Right, res);
        }
        
        private List<int> LeftBoundary(TreeNode node, List<int> res)
        {
            if (node == null || node.Left == null && node.Right == null)
            {
                return res;
            }

            res.Add(node.Value.Value);
            res = node.Left == null ? LeftBoundary(node.Right, res) : LeftBoundary(node.Left, res);

            return res;
        }

        private List<int> RightBoundary(TreeNode node, List<int> res)
        {
            if (node == null || node.Left == null && node.Right == null)
            {
                return res;
            }

            if (node.Right == null)
            {
                RightBoundary(node.Left, res);
            }
            else
            {
                RightBoundary(node.Right, res);
            }

            res.Add(node.Value.Value);

            return res;
        }

        private  void Leaves(TreeNode root, List<int> res)
        {
            if (root == null) return;
            if (root.Left == null && root.Right == null)
            {
                res.Add(root.Value.Value);
                return;
            }
            Leaves(root.Left, res);
            Leaves(root.Right, res);
        }

        //https://leetcode.com/problems/binary-tree-maximum-path-sum/
        public void MaxPathSum()
        {
            TreeNode node = new TreeNode(2);
            node.Left = new TreeNode(-1);

            int max = 0;
            var res = MaxPathSum(node, ref max);
        }

        private int MaxPathSum(TreeNode root, ref int max)
        {
            if (root == null)
            {
                return 0;
            }

            int left = 0; int right = 0;

            if (root.Left != null)
            {
                left = Math.Max(0, MaxPathSum(root.Left, ref max));
            }

            if (root.Right != null)
            {
                right = Math.Max(0, MaxPathSum(root.Right, ref max));
            }

            max = Math.Max(max, root.Value.Value + left + right);

            return root.Value.Value + (left > right ? left : right);
        }

        // https://practice.geeksforgeeks.org/problems/left-view-of-binary-tree/1
        public void LeftTree()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = new TreeNode(4);
            node.Left.Left.Left = new TreeNode(5);
            node.Left.Left.Right = new TreeNode(8);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(7);
            int count = 0;

            LeftTree(node, 0, ref count);
        }

        private void LeftTree(TreeNode node, int level, ref int count)
        {
            if (node == null)
            {
                return;
            }

            if (count == level)
            {
                Console.WriteLine(node.Value.Value);
            }

            count++;
            LeftTree(node.Left, level + 1, ref count);
            LeftTree(node.Right, level + 1, ref count);

            return;
        }

        public void DeleteTeeeNodeGreaterThan()
        {
            TreeNode node = new TreeNode(8);
            node.Left = new TreeNode(4);
            node.Right = new TreeNode(10);
            node.Left.Left = new TreeNode(3);
            node.Left.Right = new TreeNode(5);
            node.Right.Left = new TreeNode(9);
            node.Right.Right = new TreeNode(11);

            var res = DeleteTreeNodeGreaterThan(node, 5);
        }

        private TreeNode DeleteTreeNodeGreaterThan(TreeNode node, int Value)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value >= Value)
            {
                return node.Left;
            }

            node.Left = DeleteTreeNodeGreaterThan(node.Left, Value);
            node.Right = DeleteTreeNodeGreaterThan(node.Right, Value);

            return node;
        }

        //https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
        public void DistanceK()
        {
            int tcount = -1;

            TreeNode node = new TreeNode(3);
            node.Left = new TreeNode(5);
            node.Right = new TreeNode(1);
            node.Left.Left = new TreeNode(6);
            node.Left.Right = new TreeNode(2);
            node.Left.Right.Left = new TreeNode(7);
            node.Left.Right.Right = new TreeNode(4);
            node.Right.Left = new TreeNode(0);
            node.Right.Right = new TreeNode(8);

            var res =  DistanceK(node, node.Left, 2, new List<int>(), 0, ref tcount);
        }

        private IList<int> DistanceK(TreeNode root, TreeNode target, int k, IList<int> list, int count, ref int tcount)
        {
            if (root == null)
            {
                return list;
            }

            if (tcount > -1 && (count - tcount == k || tcount + count == k))
            {
                list.Add(root.Value.Value);
            }

            DistanceK(root.Left, target, k, list, count + 1, ref tcount);

            if (root == target)
            {
                tcount = count;
            }

            DistanceK(root.Right, target, k, list, count + 1, ref tcount);

            return list;
        }

        // https://practice.geeksforgeeks.org/problems/sum-tree/1
        public void SumTree()
        {
            TreeNode root = new TreeNode(26);
            root.Left = new TreeNode(10);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(6);

            root.Right.Left = new TreeNode(1);
            root.Right.Right = new TreeNode(2);

            Console.WriteLine(SumTree(root));
        }

        // https://practice.geeksforgeeks.org/problems/print-all-nodes-that-dont-have-sibling/1
        public void Siblings()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Right = new TreeNode(4);
            root.Right.Left = new TreeNode(5);
            root.Right.Left.Left = new TreeNode(6);

            FindSiblings(root);
        }

        private TreeNode FindSiblings(TreeNode current)
        {
            if (current == null)
            {
                return null;
            }

            TreeNode left = null, right = null;

            if (current.Left != null)
            {
                left = FindSiblings(current.Left);
            }

            if (current.Right != null)
            {
                right = FindSiblings(current.Right);
            }

            if (left != null && right == null)
            {
                Console.WriteLine(left.Value);
            }
            else if(left == null && right != null)
            {
                Console.WriteLine(right.Value);
            }

            return current;
        }


        private bool SumTree(TreeNode root)
        {
            bool ret = true;

            if (root == null || root.Left == null || root.Right == null)
            {
                return true;
            }

            if (root.Left != null && ret)
            {
                ret = SumTree(root.Left);
            }

            if (root.Right != null && ret)
            {
                ret = SumTree(root.Right);
            }

            if (! ret)
            {
                return false;
            }

            if ((root.Left.Left == null && root.Left.Right == null) || (root.Right.Left == null && root.Right.Right == null))
            {
                ret = root.Value == root.Left.Value + root.Right.Value;
            }
            else
            {
                ret = root.Value == root.Left.Value * 2 + root.Right.Value * 2;
            }

            return ret;
        }

        public void DelNodes()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right = new TreeNode(3);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(7);

            int[] to_delete = new int[] { 3, 5};
            HashSet<int> map = new HashSet<int>();

            foreach (int i in to_delete)
            {
                map.Add(i);
            }

            var nodes = DelNodes(node, map, new List<TreeNode>());
        }

        private IList<TreeNode> DelNodes(TreeNode root, HashSet<int> del, IList<TreeNode> list)
        {

            if (root == null)
            {
                return list;
            }

            DelNodes(root.Left, del, list);
            DelNodes(root.Right, del, list);

            if (del.Contains(root.Value.Value))
            {
                del.Remove(root.Value.Value);
                root = null;
            }
            else
            {
                if (root != null)
                {
                    list.Add(root);
                }
            }

            return list;
        }

        public void FindLCA()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(7);
            root.Left.Right.Left = new TreeNode(8);
            root.Left.Right.Right = new TreeNode(9);

            TreeNode parent = FindLCA(root, 2, 4);
            Console.WriteLine(parent.Value);
        }

        private TreeNode FindLCA(TreeNode node, int leftValue, int rightValue)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value == leftValue ||
                node.Value == rightValue)
            {
                return node;
            }

            TreeNode left = null, right = null;

            if (node.Left != null)
            {
                left = FindLCA(node.Left, leftValue, rightValue);
            }

            if (node.Right != null)
            {
                right = FindLCA(node.Right, leftValue, rightValue);
            }

            if (left != null && right != null)
            {
                return node;
            }

            return left != null ? left : right;
        }

        /*
         This problem was asked by Google.

Given a binary search tree and a range [a, b] (inclusive), return the sum of the elements of the binary search tree within the range.

For example, given the following tree:

    5
   / \
  3   8
 / \ / \
2  4 6  10
and the range [4, 9], return 23 (5 + 4 + 6 + 8).
         */
        public void SumOfRangeInBST()
        {
            TreeNode node = new TreeNode(5);
            node.Left = new TreeNode(3);
            node.Left.Left = new TreeNode(2);
            node.Left.Right = new TreeNode(4);
            node.Right = new TreeNode(8);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(10);

            Console.WriteLine(SumOfRangeInBST(node, 4, 9));
        }

        private int SumOfRangeInBST(TreeNode node, int left, int right)
        {
            int res = 0;

            if (node == null || node.Value.Value >= right)
            {
                return res;
            }

            if (node.Left != null && node.Value >= left)
            {
                res += SumOfRangeInBST(node.Left, left, right);
            }

            if (node.Value.Value >= left && node.Value.Value <= right)
            {
                res += node.Value.Value;
            }

            if (node.Right != null && node.Value <= right)
            {
                res += SumOfRangeInBST(node.Right, left, right);
            }
            return res;
        }

        public void FlattenBST()
        {
            TreeNode node = new TreeNode(5);
            node.Left = new TreeNode(2);
            node.Left.Left = new TreeNode(1);
            node.Left.Right = new TreeNode(3);
            node.Left.Right.Right = new TreeNode(4);
            node.Right = new TreeNode(7);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(8);

            TreeNode prev = null;
            TreeNode head = null;
            var res = FlattenBST(node, ref prev, ref head);
        }

        private TreeNode FlattenBST(TreeNode node, ref TreeNode prev, ref TreeNode head)
        {
            TreeNode res;

            if (node == null)
            {
                return null;
            }

            res = FlattenBST(node.Left, ref prev, ref head);

            if (node.Left == null && head == null)
            {
                head = node;
            }

            if (prev != null)
            {
                prev.Right = node;
                node.Left = null;
            }

            prev = node;

            res = FlattenBST(node.Right, ref prev, ref head);

            return head;

        }

        public void IsSymmetric()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(2);
            node.Left.Left = new TreeNode(3);
            node.Left.Right = new TreeNode(4);
            node.Right.Left = new TreeNode(4);
            node.Right.Right = new TreeNode(3);

            Console.WriteLine(IsSymmetric(node.Left, node.Right));
        }

        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            bool res = true;

            if (left == null && right == null)
            {
                return true;
            }

            if (left!= null && right == null || left == null && right != null || 
                left.Value != right.Value)
            {
                return false;
            }

            if (res)
            {
                res = IsSymmetric(left.Left, right.Right);
            }
            if (res)
            {
                res = IsSymmetric(left.Right, right.Left);
            }

            return res;
        }

        public void ConstructTreeFromInorderPreOrder()
        {
            int[] pre = new int[] { 3, 9, 4, 1, 20, 15, 7};
            int[] inorder = new int[] { 4, 9, 1, 3, 15, 20, 7};

            int idx = 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for(int i = 0; i < inorder.Length; i ++)
            {
                dict[inorder[i]] = i;
            }

            var res = ConstConstructTreeFromInorderPreOrder(pre, inorder, 0, inorder.Length-1, dict, ref  idx);
        }

        private TreeNode ConstConstructTreeFromInorderPreOrder(int[] pre, int[] inorder, 
            int start, int end,Dictionary<int, int> dict, ref int idx)
        {
            if (pre == null || inorder == null)
            {
                return null;
            }

            if (idx >= pre.Length || start > end)
            {
                return null;
            }

            int cur = dict[pre[idx++]];

            TreeNode node = new TreeNode(inorder[cur]);

            node.Left = ConstConstructTreeFromInorderPreOrder(pre, inorder, start, cur-1, dict, ref idx);

            node.Right = ConstConstructTreeFromInorderPreOrder(pre, inorder, cur+1, end, dict, ref idx);

            return node;
        }

        //https://www.geeksforgeeks.org/convert-ternary-expression-binary-tree/
        public void TernaryTree()
        {
            int idx = 0;
            string str = "1?2?3:4:5";
            var res = TernaryTree(str, ref idx);
        }

        private TreeNode TernaryTree(string str, ref int idx)
        {
            if (idx == str.Length)
            {
                return null;
            }

            var node = new TreeNode((int)(str[idx]));
            
            if (idx + 1 < str.Length && str[idx+1] == '?')
            {
                idx += 2;
                node.Left = TernaryTree(str, ref idx);
            
                idx += 2;
                node.Right = TernaryTree(str, ref idx);
            }

            return node;
        }

        public int MaxAncestorDiff()
        {
            TreeNode node = new TreeNode(8);
            node.Left = new TreeNode(3);
            node.Right = new TreeNode(10);
            node.Left.Left = new TreeNode(1);
            node.Left.Right = new TreeNode(6);
            node.Left.Right.Left = new TreeNode(4);
            node.Left.Right.Right = new TreeNode(7);
            node.Right.Right = new TreeNode(11);
            node.Right.Right.Left = new TreeNode(13);

            int diff = 0;

            return MaxAncestorDiff(node, int.MinValue, int.MaxValue, ref diff);
        }

        private int MaxAncestorDiff(TreeNode root, int max, int min, ref int diff)
        {
            if (diff < max - min)
            {
                diff = max - min;
            }

            if (root == null)
            {
                return diff;
            }

            MaxAncestorDiff(root.Left, Math.Max(max, root.Value.Value), Math.Min(min, root.Value.Value), ref diff);

            MaxAncestorDiff(root.Right, Math.Max(max, root.Value.Value), Math.Min(min, root.Value.Value), ref diff);

            return max - min;

        }

        //https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/
        public void SubtreeWithAllDeepest()
        {
            int max = -1;

            TreeNode node = new TreeNode(3);
            node.Left = new TreeNode(5);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(2);
            node.Left.Right.Left = new TreeNode(9);
            node.Left.Right.Right = new TreeNode(5);
            node.Right = new  TreeNode(7);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(8);

            var res = SubtreeWithAllDeepest(node, 0, ref max);
        }

        private TreeNode SubtreeWithAllDeepest(TreeNode node, int level, ref int max)
        {
            TreeNode res = null;

            if (node == null)
            {
                return null;
            }

            if (max <= level && (node.Left != null && node.Left.Left == null && node.Left.Right == null || 
                node.Right != null && node.Right.Left == null && node.Right.Right == null))
            {
                if (max < level)
                {
                    max = level;
                }

                res =  node;
            }

            TreeNode left = SubtreeWithAllDeepest(node.Left, level + 1, ref max);
            TreeNode right = SubtreeWithAllDeepest(node.Right, level + 1, ref max);

            if (left != null || right != null)
            {
                res = left != null ? left : right;
            }

            return res;
        }

        //https://leetcode.com/problems/diameter-of-binary-tree/
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int max = 0;
            DiameterOfBinaryTreeInternal(root, ref max);
            return max;
        }

        private int DiameterOfBinaryTreeInternal(TreeNode root, ref int max)
        {
            if (root == null)
            {
                return 0;
            }

            int left = DiameterOfBinaryTreeInternal(root.Left, ref max);
            int right = DiameterOfBinaryTreeInternal(root.Right, ref max);

            max = Math.Max(max, left + right);

            return Math.Max(left, right) + 1;
        }

        public void ArrayToBST()
        {
            int[] arr = new int[] { -10, -3, 0, 5, 9 };

            var res = ArrayToBST(arr, 0, arr.Length);
        }

        private TreeNode ArrayToBST(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return null;
            }

            int mid = (start + end) / 2;

            TreeNode root = new TreeNode(arr[mid]);
            root.Left = ArrayToBST(arr, start, mid);
            root.Right = ArrayToBST(arr, mid + 1, end);

            return root;
        }

        public void CountInversions()
        {
            List<int> list = new List<int>();
            list.Add(2);
            list.Add(37);
            list.Add(3);
            list.Add(67);
            list.Add(82);
            list.Add(19);
            list.Add(97);
            list.Add(91);

            Console.WriteLine(CountInversions(list));
        }

        public void ConstructTreeFromSortedArray()
        {
            int[] arr = new int[] { 3, 4, 5, 6, 7, 8, 10};

            var node = ConstructTreeFromSortedArray(arr, 0, 6, 4);
        }

        private TreeNode ConstructTreeFromSortedArray(int[] arr , int start, int end, int initMid)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start == 0 && end == arr.Length-1) ? initMid : (start + end ) / 2;

            TreeNode node = new TreeNode(arr[mid]);
            node.Left = ConstructTreeFromSortedArray(arr, start, mid-1, initMid);
            node.Right = ConstructTreeFromSortedArray(arr, mid + 1, end, initMid);

            return node;
        }

        public void DeSerialize()
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(4);
            TreeNode node3 = new TreeNode(6);
            TreeNode node4 = new TreeNode(2);
            TreeNode node5 = new TreeNode(3);
            TreeNode node6 = new TreeNode(5);

            TreeNode[] nodes = new TreeNode[9]
            {
                node2, node3, null, null, null, node4, node5, null, node6
            };

            //queue.Enqueue(node);
            queue.Enqueue(node2);
            queue.Enqueue(node3);
            queue.Enqueue(null);
            queue.Enqueue(null);
            queue.Enqueue(node4);
            queue.Enqueue(null);
            queue.Enqueue(null);
            queue.Enqueue(node5);

            node1.Left = node2;
            node2.Left = node3;
            node1.Right = node4;
            node4.Left = node5;
            node5.Right = node6;

            int idx = 0;
            TreeNode[] output = new TreeNode[10];
            var res = Serialize(node1, output, ref idx);
            idx = 0;
            var deserialized = DeSerialize(output);

        }

        private TreeNode Serialize(TreeNode node, TreeNode[] output, ref int idx)
        {
            if (node == null)
            {
                return null;
            }

            if (idx == 0)
            {
                output[idx++] = node;
            }

            if (idx < output.Length)
            {
                output[idx++] = Serialize(node.Left, output, ref idx);
            }

            if (idx < output.Length)
            {
                output[idx++] = Serialize(node.Right, output, ref idx);
            }

            return node;
        }

        private TreeNode DeSerialize(TreeNode[] nodes)
        {
            int idx = 0;
            return DeSerialize(nodes[idx], nodes, ref idx);
        }

        private TreeNode DeSerialize(TreeNode node, TreeNode[] nodes, ref int idx)
        {
            if (node == null || idx >= nodes.Length )
            {
                return node;
            }

            if (idx < nodes.Length)
            {
                node.Left = nodes[idx++];

                DeSerialize(node.Left, nodes, ref idx);
            }

            if (idx < nodes.Length)
            { 
                node.Right = nodes[idx++];

                DeSerialize(node.Right, nodes, ref idx);
            }

            return node;
        }

        private TreeNode DeSerialize(TreeNode node, Queue<TreeNode> queue)
        {
            if (node == null || queue.Count == 0)
            {
                return node;
            }

            node.Left = queue.Dequeue();
            node.Right = queue.Dequeue();

            DeSerialize(node.Left, queue);
            DeSerialize(node.Right, queue);

            return node;
        }

        public void CountCombinationsOfTree()
        {
            int maxCount = 0;
            CountCombinationsOfTree(new TreeNode(null),3, ref maxCount);
            Console.WriteLine(maxCount);
        }

        private TreeNode CountCombinationsOfTree(TreeNode node, int nodeCount, ref int maxCount)
        {

            if (nodeCount == 0)
            {
                maxCount++;
                return node;
            }

            var newNode = new TreeNode(null);
            node.Left = CountCombinationsOfTree(newNode, nodeCount -1, ref maxCount);

            if (nodeCount == 1)
            {
                return node;
            }

            node.Right = CountCombinationsOfTree(newNode, nodeCount -1, ref maxCount);

            return node;
        }

        public void PostOrderTraversal()
        {
            TreeNode node = new TreeNode(3);
            node.Right = new TreeNode(1);
            node.Right.Left = new TreeNode(2);

            var res = PostorderTraversal(node);
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();

            if (root == null)
            {
                return res;
            }

            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);
            TreeNode cur = root;
            TreeNode prev = null;

            while (stk.Count > 0)
            {
                cur = stk.Peek();

                while (cur.Left != null && cur.Left != prev)
                {
                    cur = cur.Left;
                    stk.Push(cur);
                }

                if (stk.Count == 0)
                {
                    return res;
                }

                if (stk.Peek().Right != null && stk.Peek().Right != prev)
                {
                    cur = cur.Right;
                    stk.Push(cur);
                }
                else
                {
                    prev = stk.Pop();
                    res.Add(prev.Value.Value);
                }
            }

            return res;
        }

        public int CountInversions(List<int> A)
        {
            TreeNode node = new TreeNode(A[0]);
            int count = 0;
            bool insert = false;

            for (int idx = 1; idx < A.Count; idx++)
            {
                ConstructBST(node, A, idx, A[idx-1], ref insert);
                insert = false;
            }

            bool traverse = false;

            for (int idx = 0; idx < A.Count; idx++)
            {
                count += SearchBST(node, A, idx, ref traverse);
                traverse = false;
            }

            return count;
        }

        private int SearchBST(TreeNode node, List<int> A, int idx, ref bool traverse)
        {
            int count = 0;

            if (node == null)
            {
                return 0;
            }

            if (node.Value == A[idx])
            {
                traverse = true;
            }

            if (traverse)
            {
                if (node.Value < A[idx])
                {
                    count = 1;
                }

                count += SearchBST(node.Left, A, idx, ref traverse);
                count += SearchBST(node.Right, A, idx, ref traverse);
            }
            else
            {
                count += SearchBST(node.Left, A, idx, ref traverse);
                count += SearchBST(node.Right, A, idx, ref traverse);
            }

            return count;
        }

        private void ConstructBST(TreeNode node, List<int> A, int idx, int nodeValue, ref bool Insert)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value == nodeValue)
            {
                Insert = true;
            }

            if (Insert)
            {
                if (A[idx] < node.Value)
                {
                    if (node.Left == null && Insert)
                    {
                        node.Left = new TreeNode(A[idx]);
                    }
                    else
                    {
                        ConstructBST(node.Left, A, idx, nodeValue, ref Insert);
                    }
                }
                else
                {
                    if (node.Right == null && Insert)
                    {
                        node.Right = new TreeNode(A[idx]);
                    }
                    else
                    {
                        ConstructBST(node.Right, A, idx, nodeValue, ref Insert);
                    }
                }
            }
            else
            {
                ConstructBST(node.Left, A, idx, nodeValue, ref Insert);
                ConstructBST(node.Right, A, idx, nodeValue, ref Insert);
            }
        }

        // https://leetcode.com/problems/binary-tree-cameras/
        public void BinaryTreeCamera()
        {
            TreeNode node = new TreeNode(0);
            node.Left = new TreeNode(0);
            node.Left.Left = new TreeNode(0);
            //node.Left.Right = new TreeNode(0);
            //node.Left.Left.Left = new TreeNode(0);
            //node.Left.Left.Right = new TreeNode(0);
            //node.Left.Left.Left.Left = new TreeNode(0);
            //node.Left.Left.Left.Right = new TreeNode(0);
            //node.Left.Left.Left.Right.Left = new TreeNode(0);
            //node.Left.Left.Left.Right.Right = new TreeNode(0);

            Console.WriteLine(BinaryTreeCamera(node, 0, null));
        }

        private int BinaryTreeCamera(TreeNode node, int count, TreeNode parent)
        {
            if (node == null)
            {
                return count;
            }

            if (node.Left != null && node.Right != null)
            {
                node.Value = 1;
                count++;
            }
            else
            {
                if (parent?.Value == 0)
                {
                    node.Value = 1;
                    count++;
                }
            }

            count = BinaryTreeCamera(node.Left, count, node);
            count = BinaryTreeCamera(node.Right, count, node);

            return count;
        }

        // https://www.interviewbit.com/problems/min-depth-of-binary-tree/
        public void MinDepth()
        {
            TreeNode node = new TreeNode(10);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(5);
            node.Left.Right = new TreeNode(12);
            int min = Int32.MaxValue;
            Console.WriteLine(MinDepth(node,0, ref min));
        }

        private int MinDepth(TreeNode A, int depth, ref int min)
        {
            if (A == null)
            {
                if (min > depth)
                {
                    min = depth;
                }

                return min;
            }

            MinDepth(A.Left, depth + 1, ref min);
            MinDepth(A.Right, depth + 1, ref min);


            return min;
        }

        public void IterativePreOrder()
        {
            TreeNode node = new TreeNode(1);
            node.Right = new TreeNode(3);
            node.Right.Left = new TreeNode(4);

            IterativePreOrder(node);
        }

        private void IterativePreOrder(TreeNode node)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            AddToStack(stk, node);

            while(stk.Count > 0)
            {
                while (node.Left!= null)
                {
                    node = node.Left;
                    AddToStack(stk, node);
                }

                var item = stk.Pop();

                while (item.Right == null && stk.Count >0)
                {
                    item = stk.Pop();
                }

                if (item.Right != null)
                {
                    node = item.Right;
                    AddToStack(stk, node);
                }
            }
        }

        private void AddToStack(Stack<TreeNode> stk, TreeNode node)
        {
            Console.WriteLine(node.Value);
            stk.Push(node);
        }

        public void RootToLeafPath()
        {
            TreeNode root = new TreeNode(10);
            root.Left = new TreeNode(8);
            root.Right = new TreeNode(2);
            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(5);
            root.Right.Left = new TreeNode(2);

            RootToLeafPath(root, 14, 10);
        }

        private void RootToLeafPath(TreeNode node, int desiredSum, int? sum)
        {
            if (node == null)
            {
                return;
            }

            if (sum == desiredSum)
            {
                Console.WriteLine("Desired sum {0}", sum);
            }

            if (node.Left != null)
            {
                RootToLeafPath(node.Left, desiredSum, sum + node.Left.Value);
            }

            if (node.Right != null)
            {
                RootToLeafPath(node.Right, desiredSum, sum + node.Right.Value);
            }
        }

        public void Inorder()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(7);

            PrintInOrder(root);
        }

        public void PostOrderIteratively()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(7);

            var list = PostOrderIteratively(node);
        }

        private List<TreeNode> PostOrderIteratively(TreeNode node)
        {
            TreeNode prev = null;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            List<TreeNode> list = new List<TreeNode>();
            stk.Push(node);

            while (stk.Count > 0)
            {
                while(node.Left != null)
                {
                    stk.Push(node.Left);
                    node = node.Left;
                }

                var item = stk.Peek();

                if (item.Right != null)
                {
                    if (item.Right == prev)
                    {
                        prev = stk.Pop();
                        list.Add(prev);
                    }
                    else
                    {
                        stk.Push(item.Right);
                        prev = item.Right;
                        node = prev;
                    }
                }
                else
                {
                    prev = stk.Pop();
                    list.Add(prev);
                }
            }

            return list;
        }

        public void MaxPath()
        {
            TreeNode node = new TreeNode(-10);
            node.Left = new TreeNode(9);
            node.Right = new TreeNode(20);
            node.Right.Left = new TreeNode(15);
            node.Right.Right = new TreeNode(7);

            int max = 0;
            MaxPath(node, ref max);
            Console.WriteLine(max);
        }

        private int MaxPath(TreeNode node, ref int max)
        {
            if (node == null)
            {
                return 0;
            }

            int leftValue = 0;
            int rightValue = 0;

            leftValue += MaxPath(node.Left, ref max);
            rightValue += MaxPath(node.Right, ref max);

            max = Math.Max(max, leftValue + rightValue + node.Value.Value);
            return Math.Max(leftValue, rightValue) + node.Value.Value;
        }

        public void PostorderIterative()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right = new TreeNode(3);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(7);

            List<int> postOrder = PostorderIterative(node);
        }

        private List<int> PostorderIterative(TreeNode node)
        {
            TreeNode prev = null;
            List<int> postOrderList = new List<int>();
            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(node);

            while(stk.Count > 0)
            {
                var cur = stk.Peek();

                while (prev != cur.Left && prev != cur.Right && cur.Left != null)
                {
                    cur = cur.Left;
                    stk.Push(cur);
                }

                prev = stk.Pop();
                postOrderList.Add(prev.Value.Value);

                if (prev.Right!= null && stk.Peek().Left == prev)
                {
                    stk.Push(stk.Peek().Right);
                }
            }

            return postOrderList;
        }


        // https://leetcode.com/problems/recover-binary-search-tree/description/
        public void RecoverBST()
        {
            TreeNode node = new TreeNode(3);
            node.Left = new TreeNode(1);
            node.Right = new TreeNode(6);
            node.Right.Left = new TreeNode(5);
            node.Right.Left.Left = new TreeNode(2);

            RecoverBST(node);
        }

        private void RecoverBST(TreeNode root)
        {
            TreeNode firstElement = null;
            TreeNode secondElement = null;
            // The reason for this initialization is to avoid null pointer exception in the first comparison when prevElement has not been initialized
            TreeNode prevElement = new TreeNode(Int32.MinValue);

            // In order traversal to find the two elements
            Traverse(root, ref firstElement, ref secondElement, ref prevElement);

            // Swap the values of the two nodes
            int temp = firstElement.Value.Value;
            firstElement.Value = secondElement.Value;
            secondElement.Value = temp;
        }

        private void Traverse(TreeNode root, ref TreeNode firstElement, ref TreeNode secondElement, ref TreeNode prevElement)
        {
            if (root == null)
                return;

            Traverse(root.Left, ref firstElement, ref secondElement, ref prevElement);

            // Start of "do some business", 
            // If first element has not been found, assign it to prevElement (refer to 6 in the example above)
            if (firstElement == null && prevElement.Value >= root.Value)
            {
                firstElement = prevElement;
            }

            // If first element is found, assign the second element to the root (refer to 2 in the example above)
            if (firstElement != null && prevElement.Value >= root.Value)
            {
                secondElement = root;
            }

            prevElement = root;

            // End of "do some business"

            Traverse(root.Right, ref firstElement, ref secondElement, ref prevElement);
        }

        // https://www.geeksforgeeks.org/construct-a-special-tree-from-given-preorder-traversal/
        public void ConstructPreOrderTree()
        {
            int[] arr = new int[] { 10, 30, 20, 5, 15};
            char[] ch = new char[] { 'N', 'N', 'L', 'L', 'L'};

            TreeNode result = ConstructPreOrderTree(arr, ch, new Index(), 5);
            PrintInOrder(result);
        }

        private TreeNode ConstructPreOrderTree(int[] pre, char[] preLN, Index index, int n)
        {
            int idx = index.Value;

            if (idx >= n)
            {
                return null;
            }

            TreeNode node = new TreeNode(pre[idx]);
            (index.Value)++;

            if (preLN[idx] == 'N')
            {
                node.Left = ConstructPreOrderTree(pre, preLN, index, n);
                node.Right = ConstructPreOrderTree(pre, preLN, index, n);
            }

            return node;
        }

        private void PrintInOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }


            PrintInOrder(node.Left);

            Console.WriteLine(node.Value);

            PrintInOrder(node.Right);
        }

        // https://www.geeksforgeeks.org/difference-between-sums-of-odd-and-even-levels/
        public void DiffOddAndEven()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(7);

            Console.WriteLine(DiffOddAndEven(node));
        }

        private int DiffOddAndEven(TreeNode node)
        {
            if (node == null)
            {
                return -1;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(node);
            int? oCount = 0;
            int? eCount = 0;
            bool isOdd = true;
            int qSize = 1;

            while (qSize > 0)
            {
                var item = queue.Dequeue();
                qSize--;

                if (isOdd)
                {
                    oCount += item.Value;
                }
                else
                {
                    eCount += item.Value;
                }

                if (item.Left != null)
                {
                    queue.Enqueue(item.Left);
                }

                if (item.Right != null)
                {
                    queue.Enqueue(item.Right);
                }

                if (qSize == 0)
                {
                    isOdd = !isOdd;
                    qSize = queue.Count;
                }
            }

            return Math.Abs(oCount.Value - eCount.Value);
        }

        //https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
        public void Serialize()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = null;
            node.Left.Right = null;
            node.Right.Left = new TreeNode(4);
            node.Right.Right = new TreeNode(5);

            int idx = 0;
            var outList = new List<int?>();
            var output = Serialize(node, outList);

            var deserializedOutput = DeSerialize(outList, ref idx);
        }

        private List<int?> Serialize(TreeNode node, List<int?> output)
        {
            if (node == null)
            {
                output.Add(null);
                return output;
            }

            output.Add(node.Value);

            output = Serialize(node.Left, output);
            output = Serialize(node.Right, output);

            return output;
        }

        private TreeNode DeSerialize(List<int?> arr, ref int idx)
        {
            if (idx == arr.Count || arr[idx] == null)
            {
                return null;
            }

            TreeNode root = new TreeNode(arr[idx]);
            idx++;
            root.Left = DeSerialize(arr, ref idx);
            idx++;
            root.Right = DeSerialize(arr, ref idx);

            return root;
        }

        public void PostOrder()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right.Left = null;
            node.Right.Right = new TreeNode(6);

            PostOrder(node);
        }

        private void PostOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.Left);
            PostOrder(node.Right);

            Console.WriteLine(node.Value);
        }

        public void ConstructBinaryTreeFromPreOrder()
        {
            int[] arr = new int[] { 9, 3, 15, 20, 7};
            var node = ConstructBinaryTreeFromPreOrder(arr, 0, 4);
        }

        private TreeNode ConstructBinaryTreeFromPreOrder(int[] arr, int start, int end)
        {
            TreeNode node = null;

            if (start >= end)
            {
                return node;
            }

            int mid = (start + end-1) / 2 ;

            node = new TreeNode(arr[mid]);
            node.Left = ConstructBinaryTreeFromPreOrder(arr, start, mid);
            node.Right = ConstructBinaryTreeFromPreOrder(arr, mid+1, end);

            return node;
        }

        public void BinaryTreeFromPreInorder()
        {

        }

        private TreeNode BinaryTreeFromPreInooder(TreeNode node, Dictionary<int, int> inorder, int[] preorder, int inStart, int inEnd, int preIdx)
        {
            if (node == null)
            {
                return node;
            }

            var cur = preorder[preIdx];
            var inIdx = inorder[cur];

            TreeNode child = new TreeNode(cur);

            if (inStart == inEnd)
            {
                return node;
            }

            child.Left = BinaryTreeFromPreInooder(child, inorder, preorder, inStart, inIdx-1, ++preIdx);
            child.Right = BinaryTreeFromPreInooder(child, inorder, preorder, inIdx + 1, inEnd, ++preIdx);

            return child;
        }

        // https://www.geeksforgeeks.org/find-median-bst-time-o1-space/
        public void BSTMedian()
        {
            TreeNode node = new TreeNode(20);
            node.Left = new TreeNode(8);
            node.Right = new TreeNode(22);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(12);
            node.Left.Right.Left = new TreeNode(10);
            node.Left.Right.Right = new TreeNode(14);

            TreeIterator iterator = new TreeIterator(node);

            int idx;

            for (idx = 1; iterator.Next() != null; idx ++)
            {
                
            }

            // Console.WriteLine(BSTMedian(node, 0, nodeCount / 2));
        }

        public void KthSmallestInBST()
        {
            TreeNode node = new TreeNode(10);
            node.Left = new TreeNode(3);
            node.Left.Left = new TreeNode(1);
            node.Left.Right = new TreeNode(2);
            node.Right = new TreeNode(12);
            node.Right.Left = new TreeNode(11);

            int k = 3;
            Console.WriteLine(KthSmallest(node, ref k));
        }

        private int KthSmallest(TreeNode A, ref int k)
        {
            int smallest = Int32.MinValue;

            if (A == null)
            {
                return smallest;
            }

            smallest = KthSmallest(A.Left, ref k);

            k -= 1;

            if (k == 0)
            {
                return A == null ? 0 : A.Value.Value;
            }

            if (k > 0 && A.Right != null)
            {
                smallest = KthSmallest(A.Right, ref k);
            }


            return smallest;
        }

        public void InorderSuccessor()
        {
            TreeNode node = new TreeNode(10);
            node.Left = new TreeNode(5);
            node.Right = new TreeNode(30);
            node.Right.Left = new TreeNode(22);
            node.Right.Right = new TreeNode(35);

            Console.WriteLine(InorderSuccessor(node, 22).Value);
        }

        private TreeNode InorderSuccessor(TreeNode node, int value)
        {
            TreeNode successor = null;

            if (node == null)
            {
                return successor;
            }

            successor = InorderSuccessor(node.Left, value);

            if (node.Left?.Value.Value == value || node.Right?.Value.Value == value)
            {
                successor = node;
                return successor;
            }

            if (successor == null)
            {
                successor = InorderSuccessor(node.Right, value);
            }

            return successor;
        }

        public void ConstructExpressionTree()
        {
            TreeNode node = new TreeNode(5);
            TreeNode node2 = new TreeNode(Operators.Multiplication);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(Operators.Division);
            TreeNode node5 = new TreeNode(3);
            TreeNode node6 = new TreeNode(Operators.Division);
            TreeNode node7 = new TreeNode(2);
            TreeNode node8 = new TreeNode(Operators.Multiplication);
            TreeNode node9 = new TreeNode(6);
            TreeNode node10 = new TreeNode(Operators.Add);
            TreeNode node11 = new TreeNode(1);

            TreeNode[] arr = new TreeNode[] {node, node2, node3, node4, node5, node6, node7, node8, node9, node10, node11};

            var res = ConstructExpressionTree(arr, 0, arr.Length-1);
        }

        private TreeNode ConstructExpressionTree(TreeNode[] nodes, int start, int end)
        {
            if (start == end)
            {
                return nodes[start];
            }

            int pos;
            TreeNode node = FindSmallestOperatorNode(nodes, start, end, out pos);

            node.Left = ConstructExpressionTree(nodes, start, pos-1);
            node.Right = ConstructExpressionTree(nodes, pos + 1, end);

            return node;
        }

        private TreeNode FindSmallestOperatorNode(TreeNode[] nodes, int start, int end, out int pos)
        {
            if (start == end)
            {
                pos = start;
                return nodes[start];
            }

            if (nodes[start].Operator == 0)
            {
                start++;
            }

            pos = start;

            while (start < end)
            {
                pos = (nodes[start].Operator < nodes[pos].Operator) ? start : pos;

                if (start + 2 < nodes.Length && nodes[start + 2].Operator > 0)
                {
                    start += 2;
                }
                else
                {
                    break;
                }
            }

            return nodes[pos];
        }

        public enum Operators
        {
            Minus = 1,
            Add,
            Multiplication,
            Division
        };

        // https://www.geeksforgeeks.org/check-binary-tree-contains-duplicate-subtrees-size-2/
        public void HasDuplicateNodes()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right.Right = new TreeNode(2);
            node.Right.Right.Left = new TreeNode(4);
            node.Right.Right.Right = new TreeNode(5);

            var map = new Dictionary<int, TreeNode>();
            var dupe = HasDuplicateNodes(node, map);

            if (dupe != null)
            {
                Console.WriteLine("Has Duplicates {0}", IsDupeNodeNested(dupe, map[dupe.Value.Value]));
            }
        }

        private TreeNode HasDuplicateNodes(TreeNode node, Dictionary<int, TreeNode> map)
        {
            TreeNode dupeNode = null;

            if (node == null)
            {
                return dupeNode;
            }

            if (map.ContainsKey(node.Value.Value))
            {
                dupeNode = node;
            }
            else
            {
                map.Add(node.Value.Value, node);
            }

            if (dupeNode == null)
            {
                dupeNode = HasDuplicateNodes(node.Left, map);
            }

            if (dupeNode == null)
            {
                dupeNode = HasDuplicateNodes(node.Right, map);
            }

            return dupeNode;
        }

        private bool IsDupeNodeNested(TreeNode dupe, TreeNode node)
        {
            bool result = true;

            if (dupe == null && node == null)
            {
                return true;
            }
            else if (dupe == null && node != null || dupe != null && node == null)
            {
                result = false;
            }

            if (dupe.Value != node.Value)
            {
                result = false;
            }

            if (result)
            {
                result = IsDupeNodeNested(dupe.Left, node.Left);
            }

            if (result)
            {
                result = IsDupeNodeNested(dupe.Right, node.Right);
            }

            return result;
        }

        // Remove the left nodes and point before the right node
        public void FlattenTree()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(7);
            TreeNode prev = null;
            var result = FlattenTree(node, ref prev);
        }
        
        private TreeNode FlattenTree(TreeNode node, ref TreeNode prev)
        {
            if (node == null)
            {
                return null;
            }

            TreeNode left = FlattenTree(node.Left, ref prev);

            if (left != null)
            {
                TreeNode temp = node.Right;
                node.Right = left;
                node.Left = null;

                if (prev == null || prev == node)
                {
                    left.Right = temp;
                }
                else
                {
                    prev.Right = temp;
                }

                prev = temp;
            }

            TreeNode right = FlattenTree(node.Right, ref prev);

            return node;
        }

        /*
         Given a binary tree where all nodes are either 0 or 1, prune the tree so that subtrees containing 
         all 0s are removed. 
         For example, given the following tree:
   0
  / \
 1   0
    / \
   1   0
  / \
 0   0


should be pruned to:
   0
  / \
 1   0
    /
   1

         */
        public void PruneTree()
        {
            TreeNode node = new TreeNode(0);
            node.Left = new TreeNode(1);
            node.Right = new TreeNode(0);
            node.Right.Left = new TreeNode(1);
            //node.Right.Left.Left = new TreeNode(0);
            //node.Right.Left.Right = new TreeNode(0);
            node.Right.Right = new TreeNode(0);

            var res = PruneTree(node);
        }

        private bool PruneTree(TreeNode node)
        {

            if (node == null)
            {
                return true;
            }

            bool left = PruneTree(node.Left);

            if (node.Value == 0 && left)
            {
                node.Left = null;
            }
            else
            {
                left = false;
            }

            bool right = PruneTree(node.Right);

            if (node.Value == 0 && right)
            {
                node.Right = null;
            }
            else
            {
                right = false;
            }

            return left && right;
        }

        /* Recall that a full binary tree is one in which each node is either a leaf node, or has two children. 
         * Given a binary tree, convert it to a full one by removing nodes with only one child.
            For example, given the following tree:
                     0
                  /     \
                1         2
              /            \
            3                 4
              \             /   \
                5          6     7
            You should convert it to:

                 0
              /     \
            5         4
                    /   \
                   6     7  */
        public void FullTree()
        {
            TreeNode node = new TreeNode(0);
            node.Left = new TreeNode(1);
            node.Left.Left = new TreeNode(3);
            node.Left.Left.Right = new TreeNode(5);
            node.Right = new TreeNode(2);
            node.Right.Right = new TreeNode(4);
            node.Right.Right.Left = new TreeNode(6);
            node.Right.Right.Right = new TreeNode(7);

            TreeNode prev = null;

            var res = FullTree(node, ref prev);
        }

        private TreeNode FullTree(TreeNode node, ref TreeNode orphanNode)
        {
            if (node == null)
            {
                return null;
            }

            TreeNode left = FullTree(node.Left, ref orphanNode);
            TreeNode right = FullTree(node.Right, ref orphanNode);

            node.Left = left;
            node.Right = right;

            if (left == null && right == null)
            {
                orphanNode = node;
            }
            else if ((left!= null && right == null)
                || (left == null && right != null))
            {
                node = orphanNode;
                orphanNode = node;
            }
            else
            {
                orphanNode = node;
            }

            return node;
        }

        // https://leetcode.com/problems/count-of-smaller-numbers-after-self/description/
        public void SmallerNosThanSelf()
        {
            int[] arr = new int[] { 3, 2, 2, 6, 1 };
            SmallerNosThanSelf(arr, 6);
        }

        private void SmallerNosThanSelf(int[] arr, int n)
        {
            int sequence = 0;

            var pair = new Pair(sequence, 1);
            TreeNode node = new TreeNode(arr[arr.Length-1], pair);

            for (int idx = arr.Length - 2; idx >= 0; idx--)
            {
                ConstructPairTree(node, arr[idx], idx, sequence);
            }
        }

        private void ConstructPairTree(TreeNode node, int value, int idx, int sequence)
        {
            if (node == null)
            {
                return;
            }

            if (value > node.Value)
            {
                if (node.Right == null)
                {
                    var pair = new Pair(sequence + 1, 1);
                    TreeNode newNode = new TreeNode(value, pair);
                    node.Right = newNode;
                    return;
                }

                ConstructPairTree(node.Right, value, idx, sequence + 1);
            }
            else if (value < node.Value)
            {
                if (node.Left == null)
                {
                    var pair = new Pair(sequence, 1); 
                    TreeNode newNode = new TreeNode(value, pair);
                    node.Left = newNode;
                    return;
                }

                ConstructPairTree(node.Left, value, idx, sequence);
            }
            else
            {
                var dupCount = node.Pair.Y;
                node.Pair = new Pair(sequence, dupCount);
            }
        }

        public void DiameterOfTree()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Left.Left = new TreeNode(3);
            node.Left.Left.Left = new TreeNode(4);
            node.Left.Left.Left.Left = new TreeNode(5);
            node.Left.Right = new TreeNode(6);
            node.Left.Right.Left = new TreeNode(7);
            node.Left.Right.Left.Left = new TreeNode(8);
            node.Left.Right.Left.Left.Right = new TreeNode(9);

            int max = 0;
            DiameterOfTree(node, 0, ref max);
            Console.WriteLine(max);
        }

        private int DiameterOfTree(TreeNode node, int sum, ref int max)
        {
            if (node == null)
            {
                return -1;
            }

            int left = DiameterOfTree(node.Left, sum + 1, ref max) + 1;
            int right = DiameterOfTree(node.Right, sum + 1, ref max) + 1;

            int cSum = left + right;

            if (max < cSum)
            {
                max = cSum;
            }

            if (max < sum)
            {
                max = sum;
            }

            return left > right ? left : right;
        }

        public void IterativePreOrderTraversal()
        {
            TreeNode node = new TreeNode(10);
            node.Left = new TreeNode(8);
            node.Right = new TreeNode(2);
            node.Left.Left = new TreeNode(3);
            node.Left.Right = new TreeNode(5);
            node.Right.Left = new TreeNode(2);

            IterativePreOrderTraversal(node);
        }

        private void IterativePreOrderTraversal(TreeNode node)
        {
            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(node);

            while (stk.Count > 0)
            {
                var item = stk.Pop();
                Console.WriteLine(item.Value.Value);

                if (item.Right != null)
                {
                    stk.Push(item.Right);
                }
                if (item.Left != null)
                {
                    stk.Push(item.Left);
                }
            }
        }

        public void RecoverBinarySearchTree()
        {
            TreeNode node = new TreeNode(3);
            node.Left = new TreeNode(1);
            node.Right = new TreeNode(8);
            node.Right.Left = new TreeNode(5);
            node.Right.Right = new TreeNode(10);
            node.Right.Left.Left = new TreeNode(2);
            node.Right.Left.Right = new TreeNode(6);
            TreeNode prev = null;
            RecoverBinarySearchTree(node, ref prev);
        }

        private void RecoverBinarySearchTree(TreeNode node, ref TreeNode prev)
        {
            if (node == null)
            {
                return;
            }

            RecoverBinarySearchTree(node.Left, ref prev);

            if (node != null && prev != null && node.Value <= prev.Value)
            {
                SwapNodeValues(node, prev);
            }

            prev = node;

            RecoverBinarySearchTree(node.Right, ref prev);

            return;
        }

        private void SwapNodeValues(TreeNode node1, TreeNode node2)
        {
            int temp = node2.Value.Value;
            node2.Value = node1.Value;
            node1.Value = temp;
        }

        // https://www.geeksforgeeks.org/find-closest-element-binary-search-tree/
        public void CloserBSTValue()
        {
            TreeNode node = new TreeNode(9);
            node.Left = new TreeNode(4);
            node.Left.Left = new TreeNode(3);
            node.Left.Right = new TreeNode(6);
            node.Left.Right.Left = new TreeNode(5);
            node.Left.Right.Right = new TreeNode(7);
            node.Right = new TreeNode(17);
            node.Right.Right = new TreeNode(22);
            node.Right.Right.Left = new TreeNode(20);
            int closer = int.MaxValue;

            Console.WriteLine(CloserBSTValue(node, 18, ref closer));
        }

        private int CloserBSTValue(TreeNode node, int value, ref int closer)
        {
            if (node == null)
            {
                return closer;
            }

            int ret = closer;

            if (Math.Abs(node.Value.Value - value) < Math.Abs(closer - value))
            {
                closer = node.Value.Value;
            }

            if (node.Value.Value < value)
            {
                ret = CloserBSTValue(node.Right, value, ref closer);
            }
            else if (node.Value.Value > value)
            {
                ret = CloserBSTValue(node.Left, value, ref closer);
            }
            else
            {
                ret = node.Value.Value;
            }

            return ret;
        }

        public void CorrectBST()
        {
            TreeNode node = new TreeNode(10);
            node.Left = new TreeNode(5);
            node.Left.Left = new TreeNode(2);
            node.Left.Right = new TreeNode(20);
            node.Right = new TreeNode(8);

            TreeNode prev = null;

            // CorrectBST(node, ref prev, ref node1, ref node2);

            CorrectBST1(node, ref prev);
        }

        private void CorrectBST(TreeNode node, ref TreeNode prev, ref TreeNode node1, ref TreeNode node2)
        {
            if (node == null)
            {
                return;
            }

            CorrectBST(node.Left, ref prev, ref node1, ref node2);

            if (prev != null && node.Value < prev.Value)
            {
                if (node1 == null && node2 == null)
                {
                    node1 = node;
                }
                else
                {
                    node2 = node;
                }
            }

            if (node1 != null && node2 != null)
            {
                if (node1.Left.Value > node1.Value)
                {
                    TreeNode temp = node1.Left;
                    if (node2.Left.Value > node2.Value)
                    {
                        node1.Left = node2.Left;
                        node2.Left = temp;
                    }
                    else
                    {
                        node1.Left = node2.Right;
                        node2.Right = temp;
                    }
                }
                else
                {
                    TreeNode temp = node1.Right;
                    if (node2.Left.Value > node2.Value)
                    {
                        node1.Right = node2.Left;
                        node2.Left = temp;
                    }
                    else
                    {
                        node1.Right = node2.Right;
                        node2.Right = temp;
                    }
                }
            }

            prev = node;

            CorrectBST(node.Right, ref prev, ref node1, ref node2);
        }

        private TreeNode CorrectBST1(TreeNode node, ref TreeNode prev)
        {
            if (node == null)
            {
                return null;
            }

            CorrectBST1(node.Left, ref prev);

            if (prev != null)
            {
                if (node.Value < prev.Value && node.Right != null && node.Right.Value < node.Value)
                {
                    SwapNodeValues(prev, node.Right);
                }
                else if (node.Value < prev.Value)
                {
                    SwapNodeValues(node, prev);
                }
            }

            prev = node;

            CorrectBST1(node.Right, ref prev);

            return node;
        }

        public void DeleteBSTNode()
        {
            TreeNode node = new TreeNode(11);
            node.Left = new TreeNode(7);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(9);
            node.Left.Right.Left = new TreeNode(8);
            node.Left.Right.Right = new TreeNode(10);
            node.Left.Left.Left = new TreeNode(2);
            node.Left.Left.Right = new TreeNode(5);
            node.Right = new TreeNode(12);
            node.Right.Right = new TreeNode(15);

            DeleteNode(node, 7);
        }

        private TreeNode DeleteNode(TreeNode node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value < key)
            {
                node.Right = DeleteNode(node.Right, key);
            }
            else if (node.Value > key)
            {
                node.Left = DeleteNode(node.Left, key);
            }
            else
            {
                var minNode = FindMinNode(node.Right);
                minNode.Left = node.Left;
                return node.Right;
            }

            return node;
        }

        private TreeNode FindMinNode(TreeNode node)
        {
            while (node.Left!= null)
            {
                node = node.Left;
            }

            return node;
        }

        public void CousinNode()
        {
            TreeNode node = new TreeNode(1);
            node.Left = new TreeNode(2);
            node.Right = new TreeNode(3);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(5);
            node.Right.Left = new TreeNode(6);
            node.Right.Right = new TreeNode(7);

            CousinNode(node, node.Left.Right);
        }

        private void CousinNode(TreeNode node, TreeNode desiredNode)
        {
            int nodeLevel = -1;
            int level = FindLevel(node, desiredNode, 0, ref nodeLevel);
            DisplayCousins(node, 0, level, node.Left);
            Console.WriteLine($"Level is {level}");
        }

        private int FindLevel(TreeNode node, TreeNode desiredNode, int level, ref int nodeLevel)
        {
            if (node == null)
            {
                return level;
            }

            if (node == desiredNode)
            {
                nodeLevel = level;

                return nodeLevel;
            }

            if (nodeLevel == -1)
            {
                FindLevel(node.Left, desiredNode, level + 1, ref nodeLevel);
            }
            if (nodeLevel == -1)
            {
                FindLevel(node.Right, desiredNode, level + 1, ref nodeLevel);
            }

            return nodeLevel;
        }

        private void DisplayCousins(TreeNode node, int curLevel, int level, TreeNode parentNode)
        {
            if (node == null)
            {
                return;
            }

            if (curLevel == level && parentNode.Left != node && parentNode.Right!= node)
            {
                Console.WriteLine(node.Value.Value);
            }

            DisplayCousins(node.Left, curLevel + 1, level, parentNode);
            DisplayCousins(node.Right, curLevel + 1, level, parentNode);
        }

        public void TrimTree()
        {
            TreeNode node = new TreeNode(9);
            node.Left = new TreeNode(6);
            node.Left.Left = new TreeNode(2);
            node.Left.Right = new TreeNode(7);
            node.Right = new TreeNode(11);
            node.Right.Left = new TreeNode(10);
            node.Right.Right = new TreeNode(12);
            node.Right.Right.Right = new TreeNode(15);

            TrimTree(node, 2, 12, null, null);
        }

        private void TrimTree(TreeNode node, int min, int max, TreeNode prev, TreeNode maxNode)
        {
            if (node == null)
            {
                return;
            }

            if (node.Left?.Value == min)
            {
                node.Left.Left = null;
            }
            else if (node.Right?.Value == min)
            {
                node.Right.Left = null;
            }
            else if (node.Right?.Value == max)
            {
                maxNode = node.Right;
                node.Right.Right = null;
            }
            else if(node.Left?.Value == max)
            {
                maxNode = node.Left;
                node.Left.Right = null;
            }

            if (node.Value > max)
            {
                prev.Right = maxNode;
                return;
            }

            prev = node;

            TrimTree(node.Left, min, max, prev, maxNode);
            TrimTree(node.Right, min, max, prev, maxNode);
        }

        public void PreOrderSuccessor()
        {
            TreeNode node = new TreeNode(20);
            node.Left = new TreeNode(10);
            node.Right = new TreeNode(26);
            node.Left.Left = new TreeNode(4);
            node.Left.Right = new TreeNode(18);
            node.Right.Left = new TreeNode(24);
            node.Right.Right = new TreeNode(27);
            node.Left.Right.Left = new TreeNode(14);
            node.Left.Right.Right = new TreeNode(19);
            node.Left.Right.Left.Left = new TreeNode(13);
            node.Left.Right.Left.Right = new TreeNode(15);
            bool found = false;
            PreOrderSuccessor(node, node.Left.Left, ref found);
        }

        private void PreOrderSuccessor(TreeNode node, TreeNode givenNode, ref bool found)
        {
            if (node == null)
            {
                return;
            }

            if (node.Left == givenNode || node.Right == givenNode)
            {
                found = true;
                Console.WriteLine(node.Value);
            }

            if (!found)
            {
                PreOrderSuccessor(node.Left, givenNode, ref found);
            }

            if (!found)
            {
                PreOrderSuccessor(node.Right, givenNode, ref found);
            }
        }

        public void PrintBSTIterator()
        {
            TreeNode node = new TreeNode(7);
            node.Left = new TreeNode(3);
            node.Left.Right = new TreeNode(6);
            node.Left.Right.Left = new TreeNode(5);
            node.Right = new TreeNode(15);
            node.Right.Left = new TreeNode(9);

            BSTIterator bSTIterator = new BSTIterator(node);
            TreeNode cur = bSTIterator.PrintNext();

            while(cur != null)
            {
                Console.WriteLine(cur.Value);
                cur = bSTIterator.PrintNext();
            }
        }

        //https://leetcode.com/problems/serialize-and-deserialize-n-ary-tree/
        public void SerializeNAryTree()
        {
            NAryTreeNode node = new NAryTreeNode(1);
            node.Children = new NAryTreeNode[3];
            node.Children[0] = new NAryTreeNode(3);
            node.Children[1] = new NAryTreeNode(2);
            node.Children[2] = new NAryTreeNode(4);

            node.Children[0].Children = new NAryTreeNode[2];
            node.Children[0].Children[0] = new NAryTreeNode(5);
            node.Children[0].Children[1] = new NAryTreeNode(6);

            Console.WriteLine(SerializeNAryTree(node, new StringBuilder()));
        }

        private string SerializeNAryTree(NAryTreeNode treeNode, StringBuilder sb)
        {
            if (treeNode.Children == null)
            {
                return string.Empty;
            }

            sb.Append(treeNode.Value.ToString());
            sb.Append("[");

            foreach (NAryTreeNode child in treeNode.Children)
            {
                sb.Append(SerializeNAryTree(child, sb));
            }

            sb.Append("]");

            return sb.ToString();
        }

        public class NAryTreeNode
        {
            public NAryTreeNode(int value)
            {
                this.Value = value;
            }

            public NAryTreeNode[] Children;
            public int Value;
        }


        public class BSTIterator
        {
            private Stack<TreeNode> stk = new Stack<TreeNode>();
            private TreeNode cur;

            public BSTIterator(TreeNode node)
            {
                cur = node;
                stk.Push(cur);
            }

            public TreeNode PrintNext()
            {
                TreeNode ret = null;

                while(stk.Count > 0)
                {
                    while (cur.Left != null)
                    {
                        cur = cur.Left;
                        stk.Push(cur);
                    }

                    ret = stk.Pop();

                    if (ret.Right != null)
                    {
                        stk.Push(ret.Right);
                        cur = ret.Right;
                    }

                    return ret;
                }

                return null;
            }
        }

        private class TreeIterator
        {
            private Stack<TreeNode> stk = new Stack<TreeNode>();

            public TreeIterator(TreeNode node)
            {
                PushAll(node);
            }

            public bool HasNext()
            {
                return stk.Count > 0;
            }

            public int NodeCount
            {
                get;
                private set;
            }

            public int? Next()
            {
                TreeNode node = null;

                if (stk.Count > 0)
                {
                    node = stk.Pop();
                    PushAll(node.Right);

                    if (node != null)
                    {
                        NodeCount++;
                    }
                }

                return node?.Value;
            }

            private void PushAll(TreeNode node)
            {
                while (node != null)
                {
                    stk.Push(node);
                    node = node.Left;
                }
            }
        }

        private class Index
        {
            public int Value;
        }

        public class TreeNode
        {
            public TreeNode(int Value)
            {
                this.Value = (int)Value;
            }

            public TreeNode(int? Value)
            {
                this.Value = Value;
            }

            public TreeNode(Operators op)
            {
                this.Operator = op;
            }

            public TreeNode(int? Value, Pair pair)
            {
                this.Value = Value;
                this.Pair = pair;
            }

            public Operators Operator;
            public int? Value;
            public Pair Pair;
            public TreeNode Left;
            public TreeNode Right;
            public TreeNode NextRight;
            public TreeNode Suffix;
        }
    }
}
