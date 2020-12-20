using System;

namespace ConsoleApp1.Model
{
    public class MyBinaryTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node _root;
        private Node _currentNode; // internal 
        private Node _previosNode; // internal

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

        /*
         проверяю ключи узлов до тех пор, пока ключ текущего узла не совпадет искомым
         Есть 3 случая удаления узла из дерева. Мною пока рассмотреть 1-й.
         Удаляемый узел не имеет правого потомка (узел 93 подходит)
         Для того, чтобы удалить такой узел, необходимо переместить на его место левого потомка.
        */

        public void Remove(TKey key)
        {
            if (key.CompareTo(_currentNode.key) == 0)
            {
                if (_currentNode.RightChild == null && _currentNode.LeftChild == null)
                {
                    if (_currentNode == _previosNode.LeftChild)
                    {
                        _previosNode.LeftChild = null;
                    }
                    else
                    {
                        _previosNode.RightChild = null;
                    }

                    ResetCurrAndPrev();
                }

                // If one of the children == null -> another child become parent node
                else if (_currentNode.RightChild == null)
                {
                    if (_currentNode.key.CompareTo(_previosNode.key) > 0)
                    {
                        _previosNode.RightChild = _currentNode.LeftChild;
                    }
                    else
                    {
                        _previosNode.LeftChild = _currentNode.LeftChild;
                    }

                    ResetCurrAndPrev();
                }

                else if (_currentNode.LeftChild == null)
                {
                    if (_currentNode.key.CompareTo(_previosNode.key) > 0)
                    {
                        _previosNode.RightChild = _currentNode.RightChild;
                    }
                    else
                    {
                        _previosNode.LeftChild = _currentNode.RightChild;
                    }

                    ResetCurrAndPrev();
                }

                else if (_currentNode.RightChild != null && _currentNode.LeftChild != null)
                {
                    var mostLeftSuccessor = FindMostLeftSuccessor(_currentNode.RightChild);

                    if (_previosNode == null)
                    {
                        _root = mostLeftSuccessor;
                    }
                    else
                    {
                        if (_currentNode == _previosNode.RightChild)
                        {
                            _previosNode.RightChild = mostLeftSuccessor;
                        }
                        else
                        {
                            _previosNode.LeftChild = mostLeftSuccessor;
                        }
                    }

                    mostLeftSuccessor.LeftChild = _currentNode.LeftChild;
                    mostLeftSuccessor.RightChild = _currentNode.RightChild;
                    ResetCurrAndPrev();
                }
            }

            else if (key.CompareTo(_currentNode.key) > 0) // go to right child
            {
                _previosNode = _currentNode;
                _currentNode = _currentNode.RightChild;
                Remove(key);
            }
            else // go to left child
            {
                _previosNode = _currentNode;
                _currentNode = _currentNode.LeftChild;
                Remove(key);
            }
        }

        private Node FindMostLeftSuccessor(Node node)
        {
            Node parent = null;
            while (node.LeftChild != null)
            {
                parent = node;
                node = node.LeftChild;
            }

            parent.LeftChild = node.RightChild;
            return node;
        }

        private void ResetCurrAndPrev()
        {
            _currentNode = _root;
            _previosNode = null;
        }
    }
}