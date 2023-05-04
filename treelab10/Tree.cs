using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treelab10
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tree<T> : IEnumerable<T>
    {
        private Node<T> root;

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                AddNode(root, newNode);
            }
        }

        private void AddNode(Node<T> currentNode, Node<T> newNode)
        {
            if (Comparer<T>.Default.Compare(newNode.Data, currentNode.Data) < 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                }
                else
                {
                    AddNode(currentNode.Left, newNode);
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                }
                else
                {
                    AddNode(currentNode.Right, newNode);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> current = queue.Dequeue();
                yield return current.Data;

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
