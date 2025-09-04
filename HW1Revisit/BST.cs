using System;

namespace HW1Revisit;

class BST
{
    private Node root;
    private int count;

   public BST(){
        root = null;
        count = 0;
    }
  
    //attach node to tree
    public void Insert(int value)
    {
        Node temp = new Node(value);
        if(root == null)
        {
            root = temp;
            count++;
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
            return;
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
                    count++;
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
                    count++;
                }
            }
        }
    }

    //retrieve number of nodes
    public int getCount()
    {
        return count;
    }

    //Retrieve number of levels in tree
    public int getHeight()
    {
        if(root == null)
        {
            return 0;
        }
        return getHeightHelper(root);
    }
    private int getHeightHelper(Node rootNode)
    {
        if(rootNode == null)
        {
            return -1;
        }
        int leftHeight = getHeightHelper(rootNode.NextLeft);
        int rightHeight = getHeightHelper(rootNode.NextRight);

        if(leftHeight >= rightHeight)
        {
            return leftHeight + 1;
        }
        else
        {
            return rightHeight + 1;
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
            Console.Write(rec.Data + " ");
            printTreeHelper(rec.NextRight);
          }
    }
}
