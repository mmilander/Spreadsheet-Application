using System;
using System.Text;
namespace HW2
{
    public partial class Form1 : Form
    {
        public int[] array;
        public Form1()
        {
            InitializeComponent();
            RunDistinctIntegers();
            array = new int[10000];
            loadArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Fill array with random nums
        private void loadArray()
        {
            var rand = new Random();
            for (int i = 0; i < 10000; i++)
            {
                array[i] = rand.Next(20001);
            }
        }
        private void RunDistinctIntegers() // this is your method
        {
            //method 1,
            //method 2,
            //method 3,
        }

        
        /// <summary> uses a hash set to determine unqiue elements
        /// <returns></returns>int>
        public int MethodOne()
        {

        }

     
        /// <summary> uses brute-force method to determine unqiue elements>
        /// <returns></int>
        public int MethodTwo() { //Check every number that comes before it to see if duplicate

        }

       
        /// <summary> uses sort method to determine unqiue elements
        /// <returns></int>
        public int MethodThree() //count number of times a new number appears
        {

         }


        private void textBoxTextChanged(object sender, EventArgs e)
        {

        }
    }
}
