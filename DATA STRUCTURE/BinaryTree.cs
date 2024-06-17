namespace Sparta_CS_Algorithm_Study_2023.DataStructure
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }

        public BinaryTreeNode(T data) 
        {
            Data = data;
        }
    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> Root = null;
        private Comparer<T> comparer = Comparer<T>.Default;

        public void Insert(T value)
        {
            BinaryTreeNode<T> node = Root;

            // 루트 노드가 없다면 새로 생성
            if (node == null)
            {
                Root = new BinaryTreeNode<T>(value);
                return;
            }

            // 루트 노드가 있다면 노드를 추가할 자리를 탐색
            while (node != null)
            {
                int result = comparer.Compare(node.Data, value);
                if (result == 0) return;    // 중복 값이 존재하므로 삽입 불가
                else if (result > 0)    
                {
                    if (node.LeftNode == null)
                    {
                        // 왼쪽 노드가 없다면 왼쪽에 삽입
                        node.LeftNode = new BinaryTreeNode<T>(value);
                        return;
                    } else
                    {
                        // 왼쪽 노드가 존재하면 다음 탐색할 노드로 왼쪽 노드를 선택
                        node = node.LeftNode;
                    }
                }
                else
                {
                    if (node.RightNode == null)
                    {
                        // 오른쪽 노드가 없다면 오른쪽에 삽입
                        node.RightNode = new BinaryTreeNode<T>(value);
                        return;
                    }
                    else
                    {
                        // 오른쪽 노드가 존재하면 다음 탐색할 노드로 오른쪽 노드를 선택
                        node = node.RightNode;
                    }
                }
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderRecursive(Root);
        }

        private void PreOrderRecursive(BinaryTreeNode<T> node)
        {
            if (node == null) return;
            Console.Write(node.Data + " -> ");
            PreOrderRecursive(node.LeftNode);
            PreOrderRecursive(node.RightNode);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(40);
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(97);
            tree.Insert(22);
            tree.Insert(8);
            tree.Insert(16);
            tree.Insert(54);
            tree.Insert(73);
         
            tree.PreOrderTraversal();
        }
    }
}
