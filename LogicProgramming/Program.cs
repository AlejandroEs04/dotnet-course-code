using System;

namespace Conditionals {
    internal class Program {
        static void Main(string[] args) {
            // int myInt = 5;
            // int mySecondInt = 10;

            // if(myInt < mySecondInt) {
            //     myInt += 10;
            // }

            // Console.WriteLine(myInt);
            
            // string myCow = "cow";
            // string myCapitalizedCow = "Cow";

            // /** If, Else if, Else **/
            // if(myCow == myCapitalizedCow) {
            //     Console.WriteLine("It's equal");
            // } else if(myCow == myCapitalizedCow.ToLower()) {
            //     Console.WriteLine("It's equal without case sensitivity");
            // } else {
            //     Console.WriteLine("It's not equal");
            // }

            // /** SWITCH **/
            // switch(myCow) {
            //     case "cow":
            //         Console.WriteLine("Lowercase");
            //         break;

            //     case "Cow":
            //         Console.WriteLine("Capitalized");
            //         break;
                
            //     default:
            //         Console.WriteLine("Default ran");
            //         break;
            // }

            int [] intsToCompress = new int[] { 10, 15, 20, 25, 30, 12, 34 };

            int totalValue = 0;

            Console.WriteLine(2%2);

            foreach(int intForCompression in intsToCompress) {
                if( intForCompression > 20 ) {
                    totalValue += intForCompression;
                }
            } 

            Console.WriteLine(totalValue);

            // DateTime startTime = DateTime.Now;

            // int totalValue = intsToCompress[0] + intsToCompress[1] + intsToCompress[2] + intsToCompress[3] + intsToCompress[4] + intsToCompress[5] + intsToCompress[6];

            // // Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            // Console.WriteLine(totalValue);

            // totalValue = 0;
            // startTime = DateTime.Now;

            // for(int i = 0; i < intsToCompress.Length;i++) {
            //     totalValue += intsToCompress[i];
            // }

            // // Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            // Console.WriteLine(totalValue);

            // totalValue = 0;
            // startTime = DateTime.Now;

            // foreach(int intForCompression in intsToCompress) {
            //     totalValue += intForCompression;
            // } 

            // // Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            // Console.WriteLine(totalValue);

            // totalValue = 0;
            // startTime = DateTime.Now;
            // int index = 0;

            // while(index < intsToCompress.Length) {
            //     totalValue += intsToCompress[index];
            //     index++;
            // }

            // // Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            // Console.WriteLine(totalValue);

            // totalValue = 0;
            // startTime = DateTime.Now;
            // index = 0;

            // do
            // {
            //     totalValue += intsToCompress[index];
            //     index++;
            // } while (index < intsToCompress.Length);

            // // Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            // Console.WriteLine(totalValue);

            // totalValue = 0;
            // totalValue = intsToCompress.Sum();

            // Console.WriteLine(totalValue);
        }
    }
}
