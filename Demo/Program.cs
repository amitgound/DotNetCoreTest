using System;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] Colors = { "Red", "White", "Green" };
            //ref string color = ref getColor(Colors, 2);


            //ref string color = ref Colors[2];
            //Console.WriteLine(string.Join(" ", Colors));
            //Console.WriteLine(color);
            //color = "Yellow";
            //Console.WriteLine(string.Join(" ", Colors));
            //Console.WriteLine(color);
            //color = "Brown";
            //ref string color1 = ref getColor(Colors, 2);
            //Console.WriteLine(color1);

            //int[] arr = { 10,15,30, 45, 60, 90 ,110 ,35, 27, 150, 45, 60};

            //var brr = from i in arr where i > 30 orderby i select i;

            //foreach (int i in brr)
            //{
            //    Console.WriteLine($"{i} ");
            //}

            int temp = test.returnNumber();

            test.num1 = 15;

            Console.ReadLine();

            
        }

        public static ref string getColor(string[] arr, int index)
        {
            return ref arr[index];
        }
    }

    public static  class test
    {
       public static int  num1;
        static test()
        {
             MyProperty = 10;
        }

       public static int returnNumber()
        {
            return num1;
        }

        public static int MyProperty { get; }
    }

    public static class exTest 
    {
      
    }
}
