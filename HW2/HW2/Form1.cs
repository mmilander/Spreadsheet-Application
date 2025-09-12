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
            RunDistinctIntegers();
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
        private void RunDistinctIntegers() // this is your method
        {
            //method 1,
            //method 2,
            //method 3,
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
        public int MethodTwo() { //Check every number that comes before it to see if duplicate
            int count = 0;
            int indexFirstItr = 0;
            int indexSecondItr = 0;
            bool flag = false;
            foreach (var outerNum in list)
            {
                foreach(var innerNum in list)
                {
                    if(outerNum == innerNum && indexFirstItr != indexSecondItr) // find duplicate (excluding itself)
                    {
                        flag = true;
                        break;
                    }
                    indexSecondItr++;
                }
                if(flag == false)
                {
                    count++;
                }
                indexSecondItr = 0;
            }
            indexFirstItr++;
            return 0;
        }

       
        /// <summary> uses sort method to determine unqiue elements
        /// <returns></int>
        public int MethodThree() //count number of times a new number appears
        {
            return 0;
        }


        private void textBoxTextChanged(object sender, EventArgs e)
        {

        }
    }
}
