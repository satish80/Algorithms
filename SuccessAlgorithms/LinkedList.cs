using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class LinkedList
    {
        public void CloneWithRandomPointers()
        {
            LinkedListNode node = new LinkedListNode(1);
            LinkedListNode node2 = new LinkedListNode(2);
            LinkedListNode node3 = new LinkedListNode(3);

            node.Next = node2;
            node.Random = node3;
            node2.Next = node3;
            node2.Random = node;
            node3.Random = node;
            CloneWithRandomPointers(node);
        }

        private LinkedListNode CloneWithRandomPointers(LinkedListNode head)
        {
            if (head == null)
            {
                return null;
            }

            Dictionary<LinkedListNode, LinkedListNode> sourceMap = new Dictionary<LinkedListNode, LinkedListNode>();
            Dictionary<LinkedListNode, LinkedListNode> targetMap = new Dictionary<LinkedListNode, LinkedListNode>();

            LinkedListNode clone = null;
            LinkedListNode cloneHead = null;

            while (head!= null)
            {
                sourceMap.Add(head, head.Random);

                if (clone == null)
                {
                    clone = new LinkedListNode(head.Value);
                    cloneHead = clone;
                }
                else
                {
                    clone.Next = new LinkedListNode(head.Value);
                    clone = clone.Next;
                }

                targetMap.Add(head, clone);
                head = head.Next;
            }

            foreach(LinkedListNode node in sourceMap.Keys)
            {
                var SourceRandom = sourceMap[node];
                var cloneNode = targetMap[node];
                cloneNode.Random = targetMap[SourceRandom];
            }

            return cloneHead;
        }

        public void ReverseList()
        {
            LinkedListNode node = new LinkedListNode(1);
            node.Next = new LinkedListNode(2);
            node.Next.Next = new LinkedListNode(3);
            var reverseList = Reverse(node);
        }

        private LinkedListNode Reverse(LinkedListNode node)
        {
            if (node == null)
            {
                return null;
            }

            LinkedListNode prev = null, temp = null;

            while (node != null)
            {
                temp = node.Next;
                node.Next = prev;
                prev = node;
                node = temp;
            }

            return prev;
        }

        public void ReorderList()
        {
            LinkedListNode node = new LinkedListNode(1);
            node.Next = new LinkedListNode(2);
            node.Next.Next = new LinkedListNode(3);
            node.Next.Next = new LinkedListNode(4);
            node.Next.Next = new LinkedListNode(5);

            Reorder(node, node);
        }

        private void Reorder(LinkedListNode node, LinkedListNode last)
        {
            if (last == null)
            {
                return;
            }

            Reorder(node, last.Next);

            if (node != last)
            {
                LinkedListNode temp = node.Next;
                node.Next = last;
                node.Next.Next = temp;
                node = temp;
            }
        }

        //https://leetcode.com/problems/merge-k-sorted-lists/description/
        public void MergeKList()
        {
            LinkedListNode node1 = new LinkedListNode(1);
            node1.Next = new LinkedListNode(3);
            node1.Next.Next = new LinkedListNode(4);

            LinkedListNode node2 = new LinkedListNode(1);
            node2.Next = new LinkedListNode(4);
            node2.Next.Next = new LinkedListNode(5);

            LinkedListNode node3 = new LinkedListNode(2);
            node3.Next = new LinkedListNode(6);

            LinkedListNode sort = Partition(new[] { node1, node2, node3}, 0, 2);
        }


        public void SwapAlternateNodes()
        {
            LinkedListNode node = new LinkedListNode(1);
            node.Next = new LinkedListNode(2);
            node.Next.Next = new LinkedListNode(3);
            node.Next.Next.Next = new LinkedListNode(4);
            LinkedListNode head = null;

            var res = SwapAlternateNodes(node, ref head);
        }

        private LinkedListNode SwapAlternateNodes(LinkedListNode node, ref LinkedListNode head)
        {
            if (node == null)
            {
                return null;
            }

            if (head == null)
            {
                head = node.Next;
            }

            LinkedListNode rNode = DoSwap(ref node);
            if (rNode!= null && rNode.Next != null && rNode.Next.Next != null)
            {
                rNode.Next.Next = SwapAlternateNodes(rNode.Next.Next, ref head);
            }

            return rNode;
        }

        private LinkedListNode DoSwap(ref LinkedListNode node)
        {
            LinkedListNode next = node.Next;
            if (next != null)
            {
                LinkedListNode temp = node.Next.Next;

                next.Next = node;
                node.Next = temp;
            }
            return node;
        }

        public void RotateList()
        {
            LinkedListNode node = new LinkedListNode(1);
            node.Next = new LinkedListNode(2);
            node.Next.Next = new LinkedListNode(3);
            node.Next.Next.Next = new LinkedListNode(4);
            node.Next.Next.Next.Next = new LinkedListNode(5);

            LinkedListNode rotatedList = RotateList(node, 2);
        }

        private LinkedListNode RotateList(LinkedListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var PreKNode = FindPrekNode(head, k);

            LinkedListNode temp = PreKNode.Next;
            PreKNode.Next = null;
            var lastNode = FindLastNode(temp);
            lastNode.Next = head;

            return temp;
        }

        private LinkedListNode FindPrekNode(LinkedListNode head, int k)
        {
            int count = 0;
            LinkedListNode node = head;

            while (node != null)
            {
                count++;
                node = node.Next;
            }

            int idx = 1;
            node = head;

            while(idx <= count)
            {
                if (idx == count - k)
                {
                    return node;
                }

                idx++;
                node = node.Next;
            }

            return node;
        }

        private LinkedListNode FindLastNode(LinkedListNode node)
        {
            while(node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }

        private LinkedListNode Partition(LinkedListNode[] lists, int s, int e)
        {
            if (s == e)
            {
                return lists[s];
            }

            int q = (s + e) / 2;
            LinkedListNode node1 = Partition(lists, s, q);
            LinkedListNode node2 = Partition(lists, q + 1, e);

            return MergeKList(node1, node2);
        }

        private LinkedListNode MergeKList(LinkedListNode node1, LinkedListNode node2)
        {
            if (node1 == null)
            {
                return node2;
            }

            if (node2 == null)
            {
                return node1;
            }

            if (node1.Value < node2.Value)
            {
                node1.Next = MergeKList(node1.Next, node2);
                return node1;
            }
            else
            {
                node2.Next = MergeKList(node2.Next, node1);
                return node2;
            }
        }

        /*
         Given a string with repeated characters, rearrange the string so that no two adjacent characters are the same. If this is not possible, return None.
        For example, given "aaabbc", you could return "ababac". Given "aaab", return None.
         */
        public void ReturnUniqueAdjacentChars()
        {
            //TODO
        }

        //private string ReturnUniqueAdjacentChars(int[] arr)
        //{
        //    Dictionary<int, DLL> dict = new Dictionary<int, DLL>();
        //    DLL prev = null;
        //    DLL cur = null;
        //    DLL head = null;

        //    for(int idx = 0; idx < arr.Length; idx ++)
        //    {
        //        if (dict.ContainsKey(idx+1))
        //        {
        //            var item = dict[idx + 1];
        //            item.Value += 1;
        //        }
        //        else
        //        {
        //            cur = new DLL(1);
        //            head = head ?? cur;

        //            dict.Add(idx + 1, cur);
        //            prev.Next = cur;
        //            cur.Prev = prev;
        //            cur = prev;
        //        }
        //    }
        //}

        // https://www.geeksforgeeks.org/add-two-numbers-represented-by-linked-lists/
        public void AddLinkedLists()
        {
            LinkedListNode first = new LinkedListNode(2);
            first.Next = new LinkedListNode(4);

            LinkedListNode second = new LinkedListNode(5);
            second.Next = new LinkedListNode(6);
            second.Next.Next = new LinkedListNode(4);

            var res = AddLinkedLists(first, second);
        }

        private LinkedListNode AddLinkedLists(LinkedListNode first, LinkedListNode second)
        {
            LinkedListNode res = null;

            int carry = 0;
            int value = 0;


            while(first != null || second != null)
            {
                if (first != null)
                {
                    value = first.Value;
                }
                if (second != null)
                {
                    value += second.Value;
                }

                value += carry;

                if (value > 9)
                {
                    carry = value / 10;
                    value = value % 10;
                }
                else
                {
                    carry = 0;
                }

                if (res == null)
                {
                    res = new LinkedListNode(value);
                }
                else
                {
                    var latest = new LinkedListNode(value);
                    latest.Next = res;
                    res = latest;
                }


                first = first?.Next;
                second = second?.Next;
                value = 0;
            }

            return res;
        }

        public void Palindrome()
        {
            LinkedListNode node = new LinkedListNode(1);
            node.Next = new LinkedListNode(2);
            node.Next.Next = new LinkedListNode(2);
            node.Next.Next.Next = new LinkedListNode(1);
            LinkedListNode newNode = null;
            LinkedListNode headRevnode = null;
            var revNode = Reverse(node, ref newNode, ref headRevnode);
            Console.WriteLine(IsPalindrome(node, headRevnode));
        }

        private LinkedListNode Reverse(LinkedListNode node, ref LinkedListNode newNode, ref LinkedListNode headRevNode)
        {
            if (node.Next == null)
            {
                newNode = new LinkedListNode(node.Value);
                headRevNode = newNode;
                return newNode;
            }

            Reverse(node.Next, ref newNode, ref headRevNode);
            newNode.Next = new LinkedListNode(node.Value);
            newNode = newNode.Next;
            return newNode;
        }

        private bool IsPalindrome(LinkedListNode node, LinkedListNode original)
        {
            while (node.Next != null)
            {
                if (node.Value != original.Value)
                {
                    return false;
                }
                node = node.Next;
                original = original.Next;
            }

            if (original.Next != null)
            {
                return false;
            }

            return true;
        }
    }

    public class DLL
    {
        public DLL(int value)
        {
            this.Value = value;
        }

        public DLL Next;

        public DLL Prev;

        public int Value;
    }

    public class LinkedListNode
    {
        public LinkedListNode(int value)
        {
            this.Value = value;
        }

        public int Value;

        public LinkedListNode Next;

        public LinkedListNode Random;

    }
}
