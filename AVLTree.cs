using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPGravFieldV2
{
    public class AVLTree<T> where T : IComparable
    {
        //members
        private Node<T> root;

        //constructor
        public AVLTree()
        {
            root = null;
        }

        //methods
        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null) //if tree is empty
            {
                //Console.WriteLine("Node added");
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Data) < 0) //if item is less than node
            {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) > 0) //if item is greater than node
            {
                insertItem(item, ref tree.Right);
            }

            //AVL Tree rotations to flatten tree. Doesn't work at the moment
            /*
            tree.BalanceFactor = height(ref tree.Left) - height(ref tree.Right);

            if (tree.BalanceFactor <= -2)
            {
                rotateLeft(ref tree);
            }
            
            if (tree.BalanceFactor >= 2)
            {
                rotateRight(ref tree);
            }
            */
        }

        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right.BalanceFactor > 0) //double rotate
            {
                rotateRight(ref tree.Right);
            }

            //old root at top of tree
            Node<T> oldRoot = tree;

            //new root as right subtree of old root
            Node<T> newRoot = tree.Right;

            //tree becomes newRoot
            tree = newRoot;

            //left subtree of new root becomes right subtree of old root
            oldRoot.Right = oldRoot.Left;

            //Putting oldRoot into left subtree
            tree.Left = oldRoot;
        }
        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left.BalanceFactor < 0) //double rotate
            {
                rotateLeft(ref tree.Left);
            }

            //old root at top of tree
            Node<T> oldRoot = tree;

            //new root as left subtree of old root
            Node<T> newRoot = tree.Left;

            tree = newRoot;

            //new root right subtree becomes left subtree of old root
            oldRoot.Left = oldRoot.Right;

            //old root moves to right of new root subtree
            tree.Right = oldRoot;
        }

        public int Height() //returns max level of tree
        {
            return height(ref root);
        }
        private int height(ref Node<T> tree)
        {
            if (tree == null) //if tree is empty
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(height(ref tree.Left), height(ref tree.Right));
            }
        }

        public bool Contains(T item) //true if item is in tree
        {
            return contains(ref root, item);
        }
        private bool contains(ref Node<T> tree, T item)
        {
            if (tree == null)//if tree is empty
            {
                //Console.WriteLine("Tree is null");
                return false;
            }
            else
            {
                //if item is found
                if(item.CompareTo(tree.Data) == 0)
                {
                    return true;
                }

                //if item to find is on left of node
                else if (item.CompareTo(tree.Data) < 0)
                {
                    return contains(ref tree.Left, item);
                }

                //if item to find is on the right
                else if (item.CompareTo(tree.Data) > 0)
                {
                    return contains(ref tree.Right, item);
                }
            }
            return false;
        }

        public T GetBodyFromTree(T word)
        {
            return getBodyFromTree(ref root, word);
        }

        private T getBodyFromTree(ref Node<T> tree, T item)
        {
            if(tree == null) //at end of tree
            {
                return default;
            }
            else
            {
                if (item.CompareTo(tree.Data) == 0) //word object found
                {
                    return tree.Data;
                }
                else if (item.CompareTo(tree.Data) < 0) //if item to find is on left of node
                {
                    return getBodyFromTree(ref tree.Left, item);
                }
                else if (item.CompareTo(tree.Data) > 0) //if item to find is on the right
                {
                    return getBodyFromTree(ref tree.Right, item);
                }
            }
            Console.WriteLine("Body not found");
            return default;
        }

        public void UpdateTree(T item)
        {
            updateTree(ref root, item);
        }

        private void updateTree(ref Node<T> tree, T item) //update tree with new occurance
        {
            if (tree == null) //if tree is empty
            {

            }
            else if (item.CompareTo(tree.Data) < 0) //if item is less than node
            {
                updateTree(ref tree.Left, item);
            }
            else if (item.CompareTo(tree.Data) > 0) //if item is greater than node
            {
                updateTree(ref tree.Right, item);
            }
            else //found node to update
            {
                tree.Data = item;
            }
        }

        public int Count() //Returns number of nodes on tree
        {
            int cnt = 0;
            return count(ref root, ref cnt);
        }
        private int count(ref Node<T> tree, ref int counter)
        {
            if (tree == null)//if tree is empty
            {
                return 0;
            }
            else
            {
                count(ref tree.Left, ref counter);
                count(ref tree.Right, ref counter);
                counter++;
                return counter;
            }
        }

        public List<T> InOrder()
        {
            List<T> buffer = new List<T>();
            inOrder(root, buffer);
            return buffer;
        }

        private List<T> inOrder(Node<T> tree, List<T> buffer)
        {
            if (tree != null)
            {
                inOrder(tree.Left, buffer);
                buffer.Add(tree.Data);
                inOrder(tree.Right, buffer);
            }
            return buffer;
        }

        public void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }
        private void removeItem(T item, ref Node<T> tree)
        {
            //searching for the item
            if(tree == null) //if there is no tree
            {
                
            }
            else if(item.CompareTo(tree.Data) < 0)//if the item is on the left tree
            {
                removeItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) > 0)//if the item is on the right tree
            {
                removeItem(item, ref tree.Right);
            }
            else //removing item
            {
                if (tree.Left == null)//nothing on the left
                {
                    tree = tree.Right;
                }
                else if (tree.Right == null)//nothing on the right
                {
                    tree = tree.Left;
                }
                else
                {
                    T newRoot = leastItem(tree.Right);
                    tree.Data = newRoot;
                    removeItem(newRoot, ref tree.Right);
                }
            }
        }

        private T leastItem(Node<T> tree)//looking for smallest value from right subtree
        {
            if(tree.Left == null)
            {
                return tree.Data;
            }
            return leastItem(tree.Left);
        }
    }
}