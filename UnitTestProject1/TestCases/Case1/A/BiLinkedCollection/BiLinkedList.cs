using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BiLinkedCollection
{
    [Serializable]
    public class BiLinkedList<T> : ICollection<T>
    {
        private Node<T> start;
        private Node<T> end;

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public T First
        {
            get
            {
                if (start == null)
                {
                    throw new IndexOutOfRangeException("Cannot get first of empty list.");
                }
                return start.Data;
            }
        }
        public T Last
        {
            get
            {
                if (end == null)
                {
                    throw new IndexOutOfRangeException("Cannot get last of empty list.");
                }
                return end.Data;
            }
        }

        public void Add(T data)
        {
            AddNode(new Node<T>(data));
        }

        public void Clear()
        {
            start = null;
            end = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var result = false;
            foreach (var node in EnumerateNodes())
            {
                if (node.Data.Equals(item))
                {
                    result = true;
                }
            }
            return result;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var node in EnumerateNodes())
            {
                array[arrayIndex++] = node.Data;
            }
        }

        private void AddNode(Node<T> node)
        {
            if (end == null)
            {
                if (start != null)
                {
                    throw new BiLinkedListIntegrityException("End is null when start is not.");
                }
                start = end = node;
            }
            else
            {
                end.Next = node;
                node.Previous = end;
                end = node;
            }

            Count += 1;
        }

        private void RemoveNode(Node<T> node)
        {
            if (node.Previous == null)
            {
                if (node != start)
                {
                    throw new BiLinkedListIntegrityException(
                        "Node without prevoius node is not start.");
                }
                else
                {
                    start = node.Next;
                }
            }
            else
            {
                node.Previous.Next = node.Next;
            }

            if (node.Next == null)
            {
                if (node != end)
                {
                    throw new BiLinkedListIntegrityException(
                        "Node without next node is not end.");
                }
                else
                {
                    end = node.Previous;
                }
            }
            else
            {
                node.Next.Previous = node.Previous;
            }

            Count -= 1;
        }

        public bool Remove(T data)
        {
            foreach (var currentNode in EnumerateNodes())
            {
                if (currentNode.Data.Equals(data))
                {
                    RemoveNode(currentNode);
                    return true;
                }
            }
            return false;
        }

        private IEnumerable<Node<T>> EnumerateNodes()
        {
            for (var node = start; node != null; node = node.Next)
            {
                yield return node;
            }
        }

        private IEnumerable<Node<T>> EnumerateNodesBackwards()
        {
            for (var node = end; node != null; node = node.Previous)
            {
                yield return node;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in EnumerateNodes())
            {
                yield return node.Data;
            }
        }

        public IEnumerable<T> EnumerateBackwards()
        {
            foreach (var node in EnumerateNodesBackwards())
            {
                yield return node.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static void Serialize(string fileName, BiLinkedList<T> collection)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, collection);
            }
        }

        public static BiLinkedList<T> Deserialize(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var bf = new BinaryFormatter();
                return (BiLinkedList<T>)bf.Deserialize(fs);
            }
        }

        [Serializable]
        private class Node<T>
        {
            public T Data;
            public Node<T> Next;
            public Node<T> Previous;

            public Node(T data)
            {
                Data = data;
            }
        }
    }

    public class BiLinkedListIntegrityException : Exception
    {
        public BiLinkedListIntegrityException(string message)
            : base(message)
        {

        }
    }
}
