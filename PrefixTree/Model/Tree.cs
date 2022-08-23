using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree.Model
{
    class Tree<T>
    {
        private string Key;

        private Node<T> Head { get; set; }

        public Tree()
        {
            Head = new Node<T>();
        }

        public void Add(string word, T data)
        {
            Add(word, data, Head);
        }

        private void Add(string word, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(word))
            {
                if (!node.IsWord)
                {
                    node.IsWord = true;
                }
            }
            else
            {
                var symbol = word[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null)
                {
                    Add(word.Substring(1), data, subnode);
                }
                else 
                {
                    var newNode = new Node<T>(data, word[0]);
                    node.Items.Add(word[0], newNode);
                    Add(word.Substring(1), data, newNode);
                }
                
            }

        }

        public void Remove(string word)
        {
            Remove(word, Head);
        }

        private void Remove(string word, Node<T> node)
        {
            if (string.IsNullOrEmpty(word))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                }
            }
            else
            {
                var subnode = node.TryFind(word[0]);
                if (subnode != null)
                {
                    Remove(word.Substring(1), subnode);
                }

            }

        }

        public bool TrySearch(string word)
        {
            return TrySearch(word, Head, out T value);
        }

        private bool TrySearch(string word, Node<T> node, out T value)
        {
            value = default(T);
            var result = false;
            if (string.IsNullOrEmpty(word))
            {
                if (node.IsWord)
                {
                    value = node.Data;
                    result = true;
                }
            }
            else
            {
                var subnode = node.TryFind(word[0]);
                if (subnode != null)
                {
                    result = TrySearch(word.Substring(1), subnode, out value);
                }

            }

            return result;
        }



    }
}
