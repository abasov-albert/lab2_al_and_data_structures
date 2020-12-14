using System;

namespace ConsoleApp1.Model
{
    public class MyBinaryTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node _root;
        private Node _currentNode; 

        private class Node
        {
            public TKey key { get; set; }
            public TValue value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public MyBinaryTree()
        {
            _root = null;
        }

        public void Add(TKey key, TValue value)
        {
            Node newNode = new Node(key, value);
            
            if (_root == null)
            {
                _root = newNode;
                _currentNode = _root;
                return;
            }
            
            if (key.CompareTo(_currentNode.key) > 0) // key > root.key
            {
                if (_currentNode.RightChild == null)
                {
                    _currentNode.RightChild = newNode;
                    _currentNode = _root;
                }
                else
                {
                    _currentNode = _currentNode.RightChild;
                    Add(key, value);
                }
            }
            else if (key.CompareTo(_currentNode.key) < 0)
            {
                if (_currentNode.LeftChild == null)
                {
                    _currentNode.LeftChild = newNode;
                    _currentNode = _root;
                }
                else
                {
                    _currentNode = _currentNode.LeftChild;
                    Add(key, value);
                }
            }
            
        }

        public TValue Get(TKey key)
        {
            if (key.CompareTo(_currentNode.key) == 0)
            {
                return _currentNode.value;
            }
            else if (key.CompareTo(_currentNode.key) > 0)
            {
                _currentNode = _currentNode.RightChild;
                var value = Get(key);
                _currentNode = _root;
                return value;
            }
            else
            {
                _currentNode = _currentNode.LeftChild;
                var value = Get(key);
                _currentNode = _root;
                return value;
            }
        }

        public TValue GetMax()
        {
            if (_currentNode.RightChild == null)
            {
                return _currentNode.value;
            }
            else
            {
                _currentNode = _currentNode.RightChild;
                var value = GetMax();
                _currentNode = _root;
                return value;
            }
        }
    }
}