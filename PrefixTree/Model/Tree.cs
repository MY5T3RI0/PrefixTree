using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree.Model
{
    /// <summary>
    /// Префиксное дерево.
    /// </summary>
    /// <typeparam name="T">Тип данных хранящихся в элементах дерева.</typeparam>
    class Tree<T>
    {
        /// <summary>
        /// Корневой элемент.
        /// </summary>
        private Node<T> Head { get; set; }

        /// <summary>
        /// Создать новое дерево.
        /// </summary>
        public Tree()
        {
            Head = new Node<T>();
        }

        /// <summary>
        /// Добавить новое слово.
        /// </summary>
        /// <param name="word">Слово.</param>
        /// <param name="data">Данные.</param>
        public void Add(string word, T data)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException("Слово не может быть пустым или null", nameof(word));
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Данные не могут быть null");
            }

            Add(word, data, Head);
        }

        /// <summary>
        /// Добавить новое слово.
        /// </summary>
        /// <param name="word">Слово.</param>
        /// <param name="data">Данные.</param>
        /// <param name="node">Корневой узел.</param>
        private void Add(string word, T data, Node<T> node)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Данные не могут быть null");
            }

            if (node is null)
            {
                throw new ArgumentNullException(nameof(node), "Узел не может быть null");
            }

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

        /// <summary>
        /// Удалить слово.
        /// </summary>
        /// <param name="word">Слово.</param>
        public void Remove(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("Слово не может быть пустым или null", nameof(word));
            }

            Remove(word, Head);
        }

        /// <summary>
        /// Удалить слово.
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="node">Корневой узел.</param>
        private void Remove(string word, Node<T> node)
        {
            if (node is null)
            {
                throw new ArgumentNullException(nameof(node), "Узел не может быть null");
            }

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

        /// <summary>
        /// Проверка есть ли такое слово.
        /// </summary>
        /// <param name="word">Искомое слово.</param>
        /// <returns>Результат проверки.</returns>
        public bool TrySearch(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("Слово не может быть пустым или null", nameof(word));
            }

            return TrySearch(word, Head, out T value);
        }

        /// <summary>
        /// Проверка есть ли такое слово.
        /// </summary>
        /// <param name="word">Искомое слово.</param>
        /// <param name="node">Корневой узел.</param>
        /// <param name="value">Данные искомого слова.</param>
        /// <returns>Результат проверки.</returns>
        private bool TrySearch(string word, Node<T> node, out T value)
        {
            if (node is null)
            {
                throw new ArgumentNullException(nameof(node), "Узел не может быть null");
            }

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
