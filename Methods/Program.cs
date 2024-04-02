using System;
using System.Windows.Markup;

namespace Conditionals {
    internal class Program {
        static int accesibleInt = 7;

        void TestMethod() {
            Console.WriteLine(accesibleInt);
        }

        static void Main(string[] args) {
            int[] values = new int[] { 10, 15, 20, 25, 30, 12, 34 };
            int[] values2 = new int[] { 10, 10, 56, 187, 2, 46 , 100};
            Console.WriteLine(accesibleInt);
            int totalValue = GetSum(values);

            Console.WriteLine(totalValue);
            Console.WriteLine(GetSum(values2));
        } 

        static private int GetSum(int[] values) {
            int totalValue = 0;

            foreach (int value in values)
            {
                totalValue += value;
            }

            if(totalValue < 400) {
                return totalValue;
            }

            return 0;
        }
    }
}
