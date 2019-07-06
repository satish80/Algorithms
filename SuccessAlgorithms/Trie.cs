using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class Trie
    {
        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
            public bool IsEndOfWord = false;

            public TrieNode()
            {
            }
        }

        private TrieNode root = null;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = root;
            foreach(char ch in word)
            {
                if (current.Children.ContainsKey(ch))
                {
                    current = current.Children[ch];
                }
                else
                {
                    var node = new TrieNode();
                    current.Children.Add(ch, node);
                }
            }

            current.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            bool found = false;
            TrieNode current = root;

            foreach(char ch in word)
            {
                if (current.Children.ContainsKey(ch))
                {
                    current = current.Children[ch];
                }
                else
                {
                    return false;
                }

                return current.IsEndOfWord;
            }

            return found;
        }
    }
}
