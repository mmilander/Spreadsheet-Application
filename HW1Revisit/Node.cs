namespace HW1Revisit;
class Node {
    private int data;
    private Node next;

    //constructors
    public Node() { }
    public Node(int num)
    {
        this.data = num;
    }

    public Node Next
    {
        get { return next; }
        set { next = value; }
    }

    public int Data
    {
        get { return data; }
        set { data = value; }
    }

 }

