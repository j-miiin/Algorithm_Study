using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class TreeTraversal
    {
        class TreeNode
        {
            public char Data;
            public TreeNode LeftChild;
            public TreeNode RightChild;

            public TreeNode(char data)
            {
                Data = data;
            }
        }

        class BinaryTree
        {
            public TreeNode RootNode = null;

            public void Insert(TreeNode valueNode)
            {
                TreeNode node = RootNode;

                if (node == null)
                {
                    RootNode = valueNode;
                    return;
                }

                InsertRecursive(node, valueNode);
            }

            private void InsertRecursive(TreeNode curNode, TreeNode valueNode)
            {
                if (curNode == null)
                {
                    return;
                }

                if (curNode.Data == valueNode.Data)
                {
                    curNode.LeftChild = valueNode.LeftChild;
                    curNode.RightChild = valueNode.RightChild;
                    return;
                }

                InsertRecursive(curNode.LeftChild, valueNode);
                InsertRecursive(curNode.RightChild, valueNode);
            }

            public void PreOrderTraversal()
            {
                StringBuilder sb = new StringBuilder();
                PreOrderRecursive(RootNode, sb);
                Console.WriteLine(sb.ToString());
            }

            public void InOrderTraversal()
            {
                StringBuilder sb = new StringBuilder();
                InOrderRecursive(RootNode, sb);
                Console.WriteLine(sb.ToString());
            }

            public void PostOrderTraversal()
            {
                StringBuilder sb = new StringBuilder();
                PostOrderRecursive(RootNode, sb);
                Console.WriteLine(sb.ToString());
            }

            private void PreOrderRecursive(TreeNode node, StringBuilder sb)
            {
                if (node == null)
                {
                    return;
                }
                sb.Append(node.Data);
                PreOrderRecursive(node.LeftChild, sb);
                PreOrderRecursive(node.RightChild, sb);
            }
            
            private void InOrderRecursive(TreeNode node, StringBuilder sb)
            {
                if (node == null)
                {
                    return;
                }
                InOrderRecursive(node.LeftChild, sb);
                sb.Append(node.Data);
                InOrderRecursive(node.RightChild, sb);
            }
            
            private void PostOrderRecursive(TreeNode node, StringBuilder sb)
            {
                if (node == null)
                {
                    return;
                }
                PostOrderRecursive(node.LeftChild, sb);
                PostOrderRecursive(node.RightChild, sb);
                sb.Append(node.Data);
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            BinaryTree tree = new BinaryTree();

            string[] str;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                char data = str[0][0];

                TreeNode node = new TreeNode(data);
                char leftChild = str[1][0];
                char rightChild = str[2][0];

                node.LeftChild = (leftChild == '.') ? null : new TreeNode(leftChild);
                node.RightChild = (rightChild == '.') ? null : new TreeNode(rightChild);

                tree.Insert(node);
            }

            tree.PreOrderTraversal();
            tree.InOrderTraversal();
            tree.PostOrderTraversal();
        }
    }
}
