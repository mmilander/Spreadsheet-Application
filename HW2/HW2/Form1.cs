using System;
using System.Text;
using System.Collections.Generic;
namespace HW2
{
    public partial class Form1 : Form
    {
        public List<int> list;
        public int[] array;
        public Form1()
        {
            InitializeComponent();
            list = new List<int>();
            LoadArray();
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
            int count = 1;
            int tempNumStore = list[0];
            list.Sort();
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


        private void textBoxTextChanged(object sender, EventArgs e)
        {

        }
    }
}
