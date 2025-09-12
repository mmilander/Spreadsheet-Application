using System;
using System.Text;
using System.Collections.Generic;
using System.Xml;
namespace HW2
{
    public partial class Form1 : Form
    {
        public List<int> list;
        public int methodOneResult;
        public int methodTwoResult;
        public int methodThreeResult;
        public Form1()
        {
            InitializeComponent();
            list = new List<int>();
            methodOneResult = 0;
            methodTwoResult = 0;
            methodThreeResult = 0;
            LoadArray();
            methodOneResult = MethodOne();
            methodTwoResult = MethodTwo();
            methodThreeResult = MethodThree();
            Output();
        }

        //Fill array with random nums
        private void LoadArray()
        {
            var rand = new Random();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(rand.Next(20001));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary> uses a hash set to determine unqiue elements
        /// <returns></returns>int> # unique nums
        public int MethodOne()
        {
            HashSet<int> numSet = new HashSet<int>(list);

            return numSet.Count;
        }


        /// <summary> uses brute-force method to determine unqiue elements>
        /// <returns></int>
        public int MethodTwo()
        { //Check every number that comes before it to see if duplicate
            int count = 0;
            bool dupFound = false;
            for(int i = 0; i < 10000; i++)
            {
                int store = list[i];
                for(int j = 0; j < i; j++)
                {
                    if (list[j] == list[i] && j != i)
                    {
                        dupFound = true;
                    }
                }
                if (!dupFound)
                {
                    count++;
                }
                dupFound = false;
            }
            return count;
        }

       
        /// <summary> uses sort method to determine unqiue elements
        /// <returns></int>
        public int MethodThree() //count number of times a new number appears
        {
            list.Sort();
            int count = 1;
            int tempNumStore = list[0];
            for(int i = 0; i < 10000; i++)
            {
                if (list[i] != tempNumStore)
                {
                    count++;
                    tempNumStore = list[i];
                }

            }
            return count;
        }
        /// <summary> Use string builder to organize text and send to TextBox
        /// <return></void>
        public void Output()
        {
             StringBuilder stringObj = new StringBuilder("", 500);
            stringObj.Append("1. HashMethod: " + methodOneResult.ToString() + " unique numbers\r\n");
            stringObj.Append("The time complexity of the HashMethod is O(n) since under the hood\n it takes n operations" +
                " to copy elements from the list over to the hashset.\r\n");
            stringObj.Append("2. O(n^2) BruteForce Method: " + methodTwoResult.ToString() + " unique numbers\r\n");
            stringObj.Append("3. Sorted method: " + methodThreeResult.ToString() + " unique numbers\r\n");
            setTextBox(stringObj.ToString());
        }

        private void textBoxTextChanged(object sender, EventArgs e)
        {

        }
    }
}
