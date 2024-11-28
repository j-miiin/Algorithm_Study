using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class BinarySearchTree_2
    {
        class TreeNode
        {
            public int value;
            public TreeNode leftChild;
            public TreeNode rightChild;

            public TreeNode (int value)
            {
                this.value = value;
            }
        }

        class BinaryTree
        {
            private TreeNode root;

            public void Add(TreeNode node)
            {
                if (root == null)
                {
                    root = node;
                    return;
                }

                TreeNode curNode = root;
                while (curNode != null)
                {
                    if (node.value < curNode.value)
                    {
                        if (curNode.leftChild == null)
                        {
                            curNode.leftChild = node;
                            break;
                        } else
                        {
                            curNode = curNode.leftChild;
                        }
                    } else
                    {
                        if (curNode.rightChild == null)
                        {
                            curNode.rightChild = node;
                            break;
                        }
                        else
                        {
                            curNode = curNode.rightChild;
                        }
                    }
                }
            }

            public void PostorderTraversal()
            {
                StringBuilder sb = new StringBuilder();
                PostorderSearch(root, sb);
                Console.WriteLine(sb.ToString());   
            }

            private void PostorderSearch(TreeNode node, StringBuilder sb)
            {
                if (node == null)
                {
                    return;
                }

                PostorderSearch(node.leftChild, sb);
                PostorderSearch(node.rightChild, sb);
                sb.Append(node.value).Append("\n");
            }
        }

        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            while (true)
            {
                string s = Console.ReadLine();

                if (s == null)
                {
                    break;
                }

                //if (s.Length == 0)
                //{
                //    break;
                //}

                tree.Add(new TreeNode(int.Parse(s)));
            }

            tree.PostorderTraversal();
        }
    }
}
