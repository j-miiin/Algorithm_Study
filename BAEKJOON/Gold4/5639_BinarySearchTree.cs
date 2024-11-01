using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class BinarySearchTree
    {
        class TreeNode
        {
            public int value;
            public TreeNode leftChild;
            public TreeNode rightChild;

            public TreeNode(int value)
            {
                this.value = value;
            }
        }

        class BinaryTree
        {
            TreeNode root;
            List<TreeNode> tree = new List<TreeNode>();

            public void Add(int value)
            {
                if (root == null)
                {
                    root = new TreeNode(value);
                    return;
                }

                TreeNode curNode = root;
                while (curNode != null)
                {
                    if (value < curNode.value)
                    {
                        if (curNode.leftChild == null)
                        {
                            curNode.leftChild = new TreeNode(value);
                            break;
                        } else
                        {
                            curNode = curNode.leftChild;
                        }
                    } else if (value > curNode.value)
                    {
                        if (curNode.rightChild == null)
                        {
                            curNode.rightChild = new TreeNode(value);
                            break;
                        }
                        else
                        {
                            curNode = curNode.rightChild;
                        }
                    } else
                    {
                        return;
                    }
                }
            }

            public void PostorderTraversal()
            {
                StringBuilder sb = new StringBuilder();
                SearchPostorder(root, sb);
                Console.WriteLine(sb.ToString());
            }

            private void SearchPostorder(TreeNode curNode, StringBuilder sb)
            {
                if (curNode == null)
                {
                    return;
                }

                SearchPostorder(curNode.leftChild, sb);
                SearchPostorder(curNode.rightChild, sb);
                sb.Append(curNode.value).Append("\n");
            }
        }

        static void Main(string[] args)
        {
            BinaryTree bTree = new BinaryTree();

            while (true)
            {
                string s = Console.ReadLine();

                if (s == null)
                {
                    break;
                }

                int cur = int.Parse(s);
                bTree.Add(cur);    
            }

            bTree.PostorderTraversal();
        }
    }
}
