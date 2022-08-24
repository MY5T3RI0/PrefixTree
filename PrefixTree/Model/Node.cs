using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree.Model
{
    /// <summary>
    /// Узел.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        /// <summary>
        /// Данные
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Символ.
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Флаг конечного узла в слове.
        /// </summary>
        public bool IsWord = false;

        /// <summary>
        /// Список дочерних узлов.
        /// </summary>
        public Dictionary<char, Node<T>> Items { get; set; }

        /// <summary>
        /// Создать новый узел.
        /// </summary>
        public Node()
        {
            Symbol = '\0';
            Items = new Dictionary<char, Node<T>>();
        }

        /// <summary>
        /// Создать новый узел.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="symbol">Символ.</param>
        public Node(T data, char symbol)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Данные не могут быть null");
            }

            if (symbol == '\0')
            {
                throw new ArgumentNullException(nameof(symbol), "Символ не может быть пустым");
            }

            Data = data; ;
            Symbol = symbol;
            Items = new Dictionary<char, Node<T>>();
        }

        /// <summary>
        /// Поиск дочернего узла с указанным символом.
        /// </summary>
        /// <param name="symbol">Символ.</param>
        /// <returns>Дочерний узел с указанным символом.</returns>
        public Node<T> TryFind(char symbol)
        {
            if (symbol == '\0')
            {
                throw new ArgumentNullException(nameof(symbol), "Символ не может быть пустым");
            }

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
