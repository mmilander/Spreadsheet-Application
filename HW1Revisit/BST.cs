using System;

namespace HW1Revisit;

class BST
{
    private Node root;

   public BST(){
        root = null;
    }
  
    public void Insert(int value)
    {
        Node temp = new Node(value);
        if(root == null)
        {
            root = temp;
        }
        else
        {  
            InsertNodeHelper(root, value);
        }
    }
    private void InsertNodeHelper(Node rootNode, int value)
    {
        if(rootNode == null)
        {
            Node temp = new Node(value);
            rootNode = temp;
        }
        else
        { 
            if (value > rootNode.Data)
            {
                if (rootNode.NextRight != null)
                {
                    InsertNodeHelper(rootNode.NextRight, value);
                }
                else
                {
                    Node temp = new Node(value);
                    rootNode.NextRight = temp;
                }
            }
            else if(value < rootNode.Data)  
            {
                if (rootNode.NextLeft != null)
                {
                    InsertNodeHelper(rootNode.NextLeft, value);
                }
                else
                {
                    Node temp = new Node(value);
                    rootNode.NextLeft = temp;
                }
            }
        }
    }

    //in-order print
    public void printTree()
    {
        printTreeHelper(root);
    }
    private void printTreeHelper(Node rec) {
          if(rec != null)
          {
              printTreeHelper(rec.NextLeft);
            Console.WriteLine(rec.Data);
            printTreeHelper(rec.NextRight);
          }
    }
}
