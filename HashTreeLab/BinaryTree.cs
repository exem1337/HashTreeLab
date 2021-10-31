using System;

namespace HashTreeLab
{
    class BinaryTree
    {
        public Node root;
        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int i, string data)
        {
            Node newNode = new Node();
            newNode.value = i;
            newNode.data = data;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (i < current.value)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                        else
                        {
                            current = current.right;
                            if (current == null)
                            {
                                parent.right = newNode;
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void Walk(Node theRoot)
        {
            if (!(theRoot == null))
            {
                Walk(theRoot.left);
                theRoot.ShowNode();
                Walk(theRoot.right);
            }
        }
    }
    public class Node
    {
        public int value;
        public string data;
        public Node left;
        public Node right;
        public void ShowNode()
        {
            Console.Write(value + " ");
        }
    }
}
