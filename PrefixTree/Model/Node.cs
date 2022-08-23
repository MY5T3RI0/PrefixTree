using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree.Model
{
    class Node<T>
    {
        public T Data { get; set; }

        public char Symbol { get; set; }

        public bool IsWord = false;

        public Dictionary<char, Node<T>> Items { get; set; }

        public Node()
        {
            Symbol = '\0';
            Items = new Dictionary<char, Node<T>>();
        }
        public Node(T data, char symbol)
        {
            Data = data;
            Symbol = symbol;
            Items = new Dictionary<char, Node<T>>();
        }

        public Node<T> TryFind(char symbol)
        {
            if (Items.TryGetValue(symbol, out Node<T> value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return $"{Symbol} {Data} ";
        }
    }
}
