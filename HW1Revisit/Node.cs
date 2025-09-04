namespace HW1Revisit;
class Node {
    private int data;
    private Node nextRight;//Since we want BST, the node class has right/left
    private Node nextLeft;

    //constructors
    public Node() {
        data = 0;
        nextRight = null;
        nextLeft = null;
    }
    public Node(int num)
    {
        this.data = num;
    }

    
    public Node NextRight
    {
        get { return nextRight; }
        set { nextRight = value; }
    }
    public Node NextLeft
    {
        get { return nextLeft; }
        set { nextLeft = value; }
    }

    public int Data
    {
        get { return data; }
        set { data = value; }
    }

 }

